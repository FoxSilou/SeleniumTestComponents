namespace SeleniumTestComponents.BaseComponents
{
    using SeleniumTestComponents.BaseComponents.Base;

    public abstract class BaseCheckBox : BaseElement
    {
        protected abstract BaseElement InputElement { get; }

        #region Values
        public bool Checked => InputElement.WebElement.GetAttribute("checked") == "true";
        public bool IsDisabled => IsNotInteractable();
        #endregion Values

        public void Set(bool value)
        {
            if (value) Check();
            else Uncheck();
        }

        public void Check()
        {
            if (!Checked) Click();
        }

        public void Uncheck()
        {
            if (Checked) Click();
        }
    }
}
