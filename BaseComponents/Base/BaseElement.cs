namespace SeleniumTestComponents.BaseComponents.Base
{
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Threading;

    public abstract class BaseElement
    {
        public By Selector { get; set; }

        protected IWebDriver _driver;
        protected WebDriverWait _wait;
        protected WebDriverWait _longWait;
        protected BaseElement _parent;
        protected int? _index;

        protected abstract By DefaultSelector { get; }

        public BaseElement WithDriver(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            _longWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            return this;
        }

        public BaseElement WithSelector(By selector)
        {
            if (selector != null) Selector = selector;
            else if (DefaultSelector != null) Selector = DefaultSelector;
            return this;
        }

        public BaseElement WithParent(BaseElement parent)
        {
            if (parent != null) _parent = parent;
            return this;
        }

        public BaseElement WithIndex(int index)
        {
            _index = index;
            return this;
        }

        public IWebElement WebElement
        {
            get
            {
                return _index == null
                        ? Helpers.GetWebElement(_driver, Selector, _parent?.WebElement) // Si un parent est précisé sans index
                        : Helpers.GetWebElements(_driver, Selector, _parent?.WebElement)[_index.Value]; // Si un parent est précisé avec index
            }
        }

        public T Get<T>(By selector = null) where T : BaseElement, new()
        {
            return new T().WithDriver(_driver).WithSelector(selector) as T;
        }

        public T GetChild<T>(By selector = null) where T : BaseElement, new()
        {
            return new T().WithDriver(_driver).WithParent(this).WithSelector(selector) as T;
        }

        public TestCollection<T> GetChildren<T>(By selector) where T : BaseElement, new()
        {
            return new TestCollection<T>(selector, this, _driver);
        }

        public bool Exists()
        {
            try
            {
                return WebElement != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Displayed()
        {
            return Exists() && WebElement.Displayed;
        }

        public void Click()
        {
            int attempts = 0;
            while(attempts < 3)
            {
                try
                {
                    WebElement.Click();
                    return;
                }
                catch (ElementClickInterceptedException)
                {
                }
                catch (ElementNotInteractableException)
                {
                }
                catch (ElementNotSelectableException)
                {
                }
                Thread.Sleep(500);
                attempts++;
            }
        }

        public bool IsNotInteractable()
        {
            try
            {
                WebElement.Click();
                return false;
            }
            catch(ElementClickInterceptedException)
            {
                return true;
            }
            catch (ElementNotInteractableException)
            {
                return true;
            }
            catch (ElementNotSelectableException)
            {
                return true;
            }
        }

        public string GetText()
        {
            return WebElement.Text;
        }

        public void ScrollIntoView()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].scrollIntoView(false);", WebElement);
            Thread.Sleep(500);
        }
    }
}