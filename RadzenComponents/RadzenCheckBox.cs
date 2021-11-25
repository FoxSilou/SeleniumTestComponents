namespace SeleniumTestComponents.RadzenComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class RadzenCheckBox : BaseCheckBox
    {
        protected override By DefaultSelector => By.ClassName("rz-chkbox");

        protected override BaseElement InputElement => this;

        public new void Set(bool value)
        {
            if (value) Check();
            else Uncheck();
        }

        public new void Check()
        {
            if (!Checked) Click();
        }

        public new void Uncheck()
        {
            if (Checked) Click();
        }
    }
}