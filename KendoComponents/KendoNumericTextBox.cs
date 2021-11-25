namespace SeleniumTestComponents.KendoComponents
{
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoNumericTextBox : BaseElement
    {
        public KendoNumericTextBox WithId(string id)
        {
            WithSelector(By.CssSelector($".k-numerictextbox.{id.ToLower()}-numerictextbox"));
            return this;
        }

        protected override By DefaultSelector => null;

        protected BaseElement Input => GetChild<BaseComponent>(By.ClassName("k-formatted-value"));
        protected BaseElement HiddenInput => GetChild<BaseComponent>(By.CssSelector("input[data-role='numerictextbox']"));

        #region Values

        public string Number => HiddenInput.WebElement.GetAttribute("value");
        public bool IsDisabled => Input.IsNotInteractable();

        #endregion Values

        public void WriteText(string text)
        {
            Helpers.RepeatUntilCondition(() => Input.Click(), () => !HiddenInput.IsNotInteractable());
            HiddenInput.WebElement.SendKeys(Keys.Control + "a");
            HiddenInput.WebElement.SendKeys(Keys.Backspace);
            HiddenInput.WebElement.SendKeys(text);
        }
    }
}