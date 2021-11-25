using OpenQA.Selenium;
using SeleniumTestComponents.BaseComponents;
using SeleniumTestComponents.BaseComponents.Base;

namespace SeleniumTestComponents.StandardComponent
{
    public class CheckBox : BaseCheckBox
    {
        protected override By DefaultSelector => null;
        protected override BaseElement InputElement => this;
    }
}