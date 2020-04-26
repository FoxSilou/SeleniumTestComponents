namespace SeleniumTestComponents.BaseComponents
{
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public abstract class BaseDatePicker : BaseElement
    {
        protected abstract BaseElement Input { get; }
        protected abstract BaseElement Select { get; }
        protected abstract BaseElement Calendar { get; }
        protected abstract string GetDateFromInput(BaseElement put);

        #region Values
        public string Date => GetDateFromInput(Input);
        public bool IsDisabled => Select.IsNotInteractable();
        #endregion Values

        public void SetDate(string date)
        {
            Input.Click();
            Input.WebElement.SendKeys(Keys.Control + "A");
            Input.WebElement.SendKeys(Keys.Backspace);
            Input.WebElement.SendKeys(date);
            _wait.Until(d => !Calendar.Displayed());
        }
    }
}
