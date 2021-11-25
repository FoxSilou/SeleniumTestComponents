namespace SeleniumTestComponents.BaseComponents.Base
{
    using OpenQA.Selenium;
    using System;
    using System.Linq;

    public class BaseCollection<T> : BaseElement where T : BaseElement, new()
    {
        protected override By DefaultSelector => null;

        public BaseCollection(By selector, BaseElement parent, IWebDriver driver, BasePage page) : base()
        {
            WithDriver(driver).WithSelector(selector).WithParent(parent).WithPage(page);
        }

        //public IWebElement[] WebElements => Helpers.GetWebElements(_driver, Selector, _parent?.WebElement);
        public T[] WebElements
        {
            get
            {
                return Helpers.GetIndexes(_driver, Selector, _parent?.WebElement)
                            .Select(index => new T()
                                .WithDriver(_driver)
                                .WithSelector(Selector)
                                .WithParent(_parent)
                                .WithPage(_page)
                                .WithIndex(index) as T)
                            .ToArray();
            }
        }

        public bool ContainsElementWithText(string text, Func<T, string> textSelector = null)
        {
            if (textSelector == null) textSelector = elt => elt.GetText();
            Func<T, bool> itemHasText = it => textSelector(it) == text;
            _wait.Until(d => WebElements.Any());
            return WebElements.Any(itemHasText);
        }

        public bool DoesntContainsElementWithText(string text, Func<T, string> textSelector = null)
        {
            if (Helpers.HasNoElement(_driver, Selector, _parent?.WebElement)) return true;
            if (textSelector == null) textSelector = elt => elt.GetText();
            Func<T, bool> itemHasText = it => textSelector(it) == text;
            return !WebElements.Any(itemHasText);
        }

        public int ScrollAndGetIndex(string text, Func<BaseElement, string> textSelector = null)
        {
            //int index = -1;
            WaitUntilAnyWithText(textSelector);

            for (int index = 0; index < WebElements.Count(); index++)
            {
                WebElements[index].ScrollIntoView();
                if (Helpers.ItemHasText(WebElements[index], text, textSelector))
                {
                    return index;
                }
            }
            return -1;

            //foreach (IWebElement webElement in WebElements)
            //{
            //    if (textSelector == null) textSelector = elt => elt.Text;
            //    js.ExecuteScript("arguments[0].scrollIntoView(false);", webElement);
            //    if (textSelector(webElement) == text) break;
            //}

            //Action action = () =>
            //{
            //    _wait.Until(d => WebElements.Any(it => Helpers.ItemHasText(it, text, textSelector)));
            //    index = WebElements.IndexOf(WebElements.First(it => Helpers.ItemHasText(it, text, textSelector)));
            //};
            //Helpers.RepeatUntilCondition(action, () => index > -1);
            //return index;
        }

        public int GetIndex(string text, Func<BaseElement, string> textSelector = null)
        {
            //int index = -1;
            WaitUntilAnyWithText(textSelector);

            //Action action = () =>
            //{
            //if (textSelector == null) textSelector = elt => elt.Text;
            //Func<IWebElement, bool> itemHasText = it => textSelector(it) == text;
            //var test = WebElements.Where(elt => !string.IsNullOrEmpty(elt.Text));
            //_wait.Until(d => WebElements.Any(itemHasText));
            //index = WebElements.IndexOf(WebElements.First(itemHasText));
            //};

            for (int index = 0; index < WebElements.Count(); index++)
            {
                if (Helpers.ItemHasText(WebElements[index], text, textSelector))
                {
                    return index;
                }
            }
            return -1;

            //Helpers.RepeatUntilCondition(action, () => index > -1);
            //return index;
        }

        public T GetByText(string text, Func<BaseElement, string> textSelector = null)
        {
            return new T()
                .WithDriver(_driver)
                .WithSelector(Selector)
                .WithParent(_parent)
                .WithPage(_page)
                .WithIndex(GetIndex(text, textSelector)) as T;
        }

        public T GetByIndex(int index)
        {
            _wait.Until(d => WebElements.Count() >= index);
            return new T()
                .WithDriver(_driver)
                .WithSelector(Selector)
                .WithParent(_parent)
                .WithPage(_page)
                .WithIndex(index) as T;
        }

        public void WaitUntilAny()
        {
            _longWait.Until(d => WebElements.Any());
        }

        public void WaitUntilAnyWithText(Func<T, string> textSelector = null)
        {
            if (textSelector == null) textSelector = elt => elt.GetText();
            _longWait.Until(d => WebElements.Any(we => !string.IsNullOrEmpty(textSelector(we))));
        }
    }
}