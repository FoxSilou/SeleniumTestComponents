namespace SeleniumTestComponents.BaseComponents
{
    using Base;
    using OpenQA.Selenium;
    using System.Threading;

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
            Helpers.RepeatUntilCondition(ClearInput, () => Input.IsTextEmpty());
            Input.WebElement.SendKeys(date);
            Select.Click();
            Select.Click();
        }

        public void ClearInput()
        {
            Input.WebElement.SendKeys(Keys.End);
            Input.WebElement.SendKeys(Keys.Control + "a");
            Thread.Sleep(100);
            Input.WebElement.SendKeys(Keys.Backspace);
        }

        public void OpenCalendar()
        {
            Calendar.Click();
        }
    }
}