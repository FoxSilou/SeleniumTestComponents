namespace SeleniumTestComponents.BaseComponents.Base
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;

    public class TestCollection<T> : BaseElement where T : BaseElement, new()
    {
        protected override By DefaultSelector => null;
        public TestCollection(By selector, BaseElement parent, IWebDriver driver) : base()
        {
            WithDriver(driver).WithSelector(selector).WithParent(parent);
        }

        public ReadOnlyCollection<IWebElement> WebElements => Helpers.GetWebElements(_driver, Selector, _parent?.WebElement);

        public bool ContainsElementWithText(string text, Func<IWebElement, string> textSelector = null)
        {
            if (textSelector == null) textSelector = elt => elt.Text;
            Func<IWebElement, bool> itemHasText = it => textSelector(it) == text;
            _wait.Until(d => WebElements.Any());
            return WebElements.Any(itemHasText);
        }

        public int GetIndex(string text, Func<IWebElement, string> textSelector = null)
        {
            int index = -1;
            WaitUntilAnyWithText();
            Action action = () =>
            {
                if (textSelector == null) textSelector = elt => elt.Text;
                Func<IWebElement, bool> itemHasText = it => textSelector(it) == text;
                _wait.Until(d => WebElements.Any(itemHasText));
                index = WebElements.IndexOf(WebElements.First(itemHasText));
            };
            Helpers.RepeatUntilCondition(action, () => index > -1);
            return index;
        }

        public T GetByText(string text, Func<IWebElement, string> textSelector = null)
        {
            return new T()
                .WithDriver(_driver)
                .WithSelector(Selector)
                .WithParent(_parent)
                .WithIndex(GetIndex(text, textSelector)) as T;
        }

        public T GetByIndex(int index)
        {
            _wait.Until(d => WebElements.Count >= index);
            return new T()
                .WithDriver(_driver)
                .WithSelector(Selector)
                .WithParent(_parent)
                .WithIndex(index) as T;
        }

        public void WaitUntilAny()
        {
           _longWait.Until(d => WebElements.Any());
        }

        public void WaitUntilAnyWithText(Func<IWebElement, string> textSelector = null)
        {
            if (textSelector == null) textSelector = elt => elt.Text;
            _longWait.Until(d => WebElements.Any(we => !string.IsNullOrEmpty(textSelector(we))));
        }
    }
}
