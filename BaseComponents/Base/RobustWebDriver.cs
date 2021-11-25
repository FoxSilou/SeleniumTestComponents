using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace SeleniumTestComponents.BaseComponents.Base
{
    public class RobustWebDriver : IWebDriver
    {
        private IWebDriver _originalWebDriver;

        public RobustWebDriver(IWebDriver webDriver)
        {
            _originalWebDriver = webDriver;
        }

        public IJavaScriptExecutor GetScriptExecutor()
        {
            return (IJavaScriptExecutor)_originalWebDriver;
        }

        public string Url
        {
            get => _originalWebDriver.Url;
            set => _originalWebDriver.Url = value;
        }

        public string Title => _originalWebDriver.Title;
        public string PageSource => _originalWebDriver.PageSource;
        public string CurrentWindowHandle => _originalWebDriver.CurrentWindowHandle;
        public ReadOnlyCollection<string> WindowHandles => _originalWebDriver.WindowHandles;

        public void Close() => _originalWebDriver.Close();

        public void Dispose() => _originalWebDriver.Dispose();

        public IOptions Manage() => _originalWebDriver.Manage();

        public INavigation Navigate() => _originalWebDriver.Navigate();

        public void Quit() => _originalWebDriver.Quit();

        public ITargetLocator SwitchTo() => _originalWebDriver.SwitchTo();

        public IWebElement FindElement(By by)
        {
            return new RobustWebElement(_originalWebDriver.FindElement(by), by, this);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            List<IWebElement> elements = new List<IWebElement>();
            foreach (IWebElement element in _originalWebDriver.FindElements(by)) elements.Add(new RobustWebElement(element, by, this));
            return elements.AsReadOnly();
        }
    }
}