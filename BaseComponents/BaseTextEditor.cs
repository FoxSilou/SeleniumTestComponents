namespace SeleniumTestComponents.BaseComponents
{
    using Base;
    using OpenQA.Selenium;

    public abstract class BaseTextEditor : BaseElement
    {
        protected abstract BaseElement Input { get; }

        protected abstract string GetFormattedText();

        #region Values

        public string FormattedText => GetFormattedText();
        public bool IsDisabled => IsNotInteractable();

        #endregion Values

        public void WriteText(string text)
        {
            Input.Click();
            Input.WebElement.SendKeys(Keys.Control + "a");
            Input.WebElement.SendKeys(Keys.Backspace);
            Input.WebElement.SendKeys(text);
        }

        public void WriteTextAndEnter(string text)
        {
            Input.Click();
            Input.WebElement.SendKeys(Keys.Control + "a");
            Input.WebElement.SendKeys(Keys.Backspace);
            Input.WebElement.SendKeys(text);
            Enter();
        }

        public void Enter()
        {
            Input.WebElement.SendKeys(Keys.Enter);
        }
    }
}