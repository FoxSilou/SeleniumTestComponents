namespace SeleniumTestComponents.StandardComponents
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public class CheckBox : BaseCheckBox
    {
        protected override By DefaultSelector => null;
        protected override BaseElement InputElement => this;
    }
}
