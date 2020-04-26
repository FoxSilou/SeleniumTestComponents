namespace SeleniumTestComponents.StandardComponents
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public class TextArea : BaseTextEditor
    {
        protected override By DefaultSelector => null;
        protected override BaseElement Input => null;

        protected override string GetFormattedText() => Input.GetText();
        public bool Disabled => IsNotInteractable();
    }
}
