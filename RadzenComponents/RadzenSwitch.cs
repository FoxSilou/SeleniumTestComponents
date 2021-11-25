namespace SeleniumTestComponents.RadzenComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class RadzenSwitch : BaseCheckBox
    {
        protected override By DefaultSelector => By.ClassName("rz-switch");

        protected override BaseElement InputElement => this;

        public bool SwitchedOn => InputElement.WebElement.GetAttribute("class").Contains("rz-switch-checked");

        public new void Set(bool value)
        {
            if (value) Check();
            else Uncheck();
        }

        public new void Check()
        {
            if (!SwitchedOn) Click();
        }

        public new void Uncheck()
        {
            if (SwitchedOn) Click();
        }
    }
}