namespace SeleniumTestComponents.KendoComponents
{
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoNumericTextBox : BaseElement
    {
        public KendoNumericTextBox WithId(string id)
        {
            WithSelector(By.CssSelector($".k-numerictextbox.{id.ToLower()}-textbox"));
            return this;
        }

        protected override By DefaultSelector => null;

        protected BaseElement Input => GetChild<Component>(By.ClassName("k-formatted-value"));
        protected BaseElement HiddenInput => GetChild<Component>(By.CssSelector("input[data-role='numerictextbox']"));

        #region Values
        public string Number => HiddenInput.WebElement.GetAttribute("value");
        public bool IsDisabled => Input.IsNotInteractable();
        #endregion Values

        public void SetText(string text)
        {
            //Helpers.RepeatUntilCondition(Input.Click, HiddenInput.Displayed);
            Input.Click();
            _wait.Until(d => HiddenInput.Displayed());
            HiddenInput.WebElement.SendKeys(text);
        }
    }
}
