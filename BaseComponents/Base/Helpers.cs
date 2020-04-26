namespace SeleniumTestComponents.BaseComponents.Base
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading;

    public static class Helpers
    {
        public static IWebElement GetWebElement(IWebDriver driver, By selector, IWebElement parent = null)
        {
            if (selector == null) return parent;
            int attempts = 0;
            while (attempts < 2)
            {
                try
                {
                    return parent == null
                        ? driver.FindElement(selector)
                        : parent.FindElement(selector);
                }
                catch
                {
                }
                Thread.Sleep(500);
                attempts++;
            }
            throw new Exception("No web element located");
        }

        public static IWebElement GetWebElement(IWebDriver driver, By selector, int index, IWebElement parent = null)
        {
            int attempts = 0;
            while (attempts < 2)
            {
                try
                {
                    return GetWebElements(driver, selector, parent)[index];
                }
                catch
                {
                }
                Thread.Sleep(500);
                attempts++;
            }
            throw new Exception("No web elements located");
        }

        public static ReadOnlyCollection<IWebElement> GetWebElements(IWebDriver driver, By selector, IWebElement parent = null)
        {
            int attempts = 0;
            while (attempts < 2)
            {
                try
                {
                    var result = parent == null
                        ? driver.FindElements(selector)
                        : parent.FindElements(selector);
                    if (result.Any()) return result;
                }
                catch
                {
                }
                Thread.Sleep(500);
                attempts++;
            }
            throw new Exception("No web elements located");
        }

        public static void RepeatUntilCondition(Action action, Func<bool> condition)
        {
            int attempts = 0;
            while (attempts < 2)
            {
                try
                {
                    action();
                    Thread.Sleep(500);
                    if (condition()) return;
                    Thread.Sleep(1000);
                }
                catch
                {
                    Thread.Sleep(1000);
                }
                attempts++;
            }
            throw new Exception("Condition never reached");
        }
    }
}
