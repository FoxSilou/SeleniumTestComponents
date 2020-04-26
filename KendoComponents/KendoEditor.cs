namespace SeleniumTestComponents.KendoComponents
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoEditor : BaseTextEditor
    {
        protected override By DefaultSelector => null;
        protected override BaseElement Input => this;

        protected override string GetFormattedText() => WebElement.GetAttribute("value");
    }
}
