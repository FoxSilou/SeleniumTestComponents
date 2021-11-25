namespace SeleniumTestComponents.BaseComponents.Base
{
    using OpenQA.Selenium;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    public static class Helpers
    {
        public static IWebElement GetWebElement(IWebDriver driver, By selector, IWebElement parent = null)
        {
            if (selector == null) return parent;
            return parent == null
                ? driver.FindElement(selector)
                : parent.FindElement(selector);
        }

        public static IWebElement GetWebElement(IWebDriver driver, By selector, int index, IWebElement parent = null)
        {
            return GetWebElements(driver, selector, parent)[index];
        }

        public static IWebElement[] GetWebElements(IWebDriver driver, By selector, IWebElement parent = null)
        {
            var result = parent == null
                ? driver.FindElements(selector).ToArray()
                : parent.FindElements(selector).ToArray();
            if (result.Any()) return result;
            throw new Exception("La Collection de web elements est vide");
        }

        public static int[] GetIndexes(IWebDriver driver, By selector, IWebElement parent = null)
        {
            List<int> result = new List<int>();
            var elements = parent == null
                ? driver.FindElements(selector).ToArray()
                : parent.FindElements(selector).ToArray();
            if (elements.Any())
            {
                for (int index = 0; index < elements.Count(); index++) result.Add(index);
            }
            return result.ToArray();
        }

        public static bool HasNoElement(IWebDriver driver, By selector, IWebElement parent = null)
        {
            Thread.Sleep(500);
            var elements = parent == null ? driver.FindElements(selector) : parent.FindElements(selector);
            return !elements.Any();
        }

        public static bool ItemHasText(BaseElement element, string text, Func<BaseElement, string> textSelector = null)
        {
            if (!element.Displayed()) return false;
            if (textSelector == null) textSelector = elt => elt.GetText();
            try
            {
                return textSelector(element) == text;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void RepeatUntilCondition(Action action, Func<bool> condition)
        {
            int attempts = 0;
            while (attempts < 4)
            {
                try
                {
                    action();
                    Thread.Sleep(200);
                    if (condition()) return;
                }
                catch
                {
                    Thread.Sleep(500);
                }
                attempts++;
            }
            throw new Exception("Condition never reached");
        }
    }
}