using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;

namespace SeleniumTestComponents.BaseComponents.Base
{
    public class RobustWebElement : IWebElement
    {
        private IWebElement _originalElement;
        private RobustWebDriver _driver;
        private By _by;
        private const int MAX_RETRIES = 10;

        public RobustWebElement(IWebElement element, By by, RobustWebDriver driver)
        {
            _originalElement = element;
            _by = by;
            _driver = driver;
        }

        public void ScrollIntoView()
        {
            IJavaScriptExecutor js = ((RobustWebDriver)_driver).GetScriptExecutor();
            js.ExecuteScript("arguments[0].scrollIntoView(false);", _originalElement);
        }

        public string TagName => RetryFunction(() => _originalElement.TagName);
        public string Text => RetryFunction(() => _originalElement.Text);
        public bool Enabled => RetryFunction(() => _originalElement.Enabled);
        public bool Selected => RetryFunction(() => _originalElement.Selected);
        public Point Location => RetryFunction(() => _originalElement.Location);
        public Size Size => RetryFunction(() => _originalElement.Size);
        public bool Displayed => RetryFunction(() => _originalElement.Displayed);

        public void Clear() => RetryAction(() => _originalElement.Clear());

        public void SendKeys(string text) => RetryAction(() => _originalElement.SendKeys(text));

        public void Submit() => RetryAction(() => _originalElement.Submit());

        public void Click() => RetryAction(() => _originalElement.Click());

        public string GetAttribute(string attributeName) => RetryFunction(() => _originalElement.GetAttribute(attributeName));

        public string GetProperty(string propertyName) => RetryFunction(() => _originalElement.GetProperty(propertyName));

        public string GetCssValue(string propertyName) => RetryFunction(() => _originalElement.GetCssValue(propertyName));

        public IWebElement FindElement(By by)
        {
            IWebElement webElement = RetryFunction(() => _originalElement.FindElement(by));
            return new RobustWebElement(webElement, by, _driver);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            ReadOnlyCollection<IWebElement> webElements = RetryFunction(() => _originalElement.FindElements(by));

            List<IWebElement> result = new List<IWebElement>();
            foreach (var webElement in webElements) result.Add(new RobustWebElement(webElement, by, _driver));
            return result.AsReadOnly();
        }

        private void RefreshElement()
        {
            _originalElement = _driver.FindElement(_by);
        }

        public void RetryAction(Action action)
        {
            int attempts = 0;
            while (attempts < MAX_RETRIES)
            {
                try
                {
                    action();
                    return;
                }
                catch (StaleElementReferenceException)
                {
                    RefreshElement();
                }
                attempts++;
            }
            throw new StaleElementReferenceException($"Element is still stale after {MAX_RETRIES} retries.");
        }

        public T RetryFunction<T>(Func<T> function)
        {
            int attempts = 0;
            while (attempts < MAX_RETRIES)
            {
                try
                {
                    return function();
                }
                catch (StaleElementReferenceException)
                {
                    RefreshElement();
                }
                attempts++;
            }
            throw new StaleElementReferenceException($"Element is still stale after {MAX_RETRIES} retries.");
        }
    }
}