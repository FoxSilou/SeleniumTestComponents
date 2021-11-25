using OpenQA.Selenium;
using SeleniumTestComponents.BaseComponents;
using SeleniumTestComponents.BaseComponents.Base;

namespace SeleniumTestComponents.StandardComponent
{
    public class TextArea : BaseTextEditor
    {
        protected override By DefaultSelector => null;
        protected override BaseElement Input => this;

        protected override string GetFormattedText() => Input.GetText();

        public bool Disabled => IsNotInteractable();
    }
}