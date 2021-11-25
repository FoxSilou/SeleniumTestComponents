namespace SeleniumTestComponents.RadzenComponents
{
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class RadzenLabel : BaseComponent
    {
        protected override By DefaultSelector => By.TagName("label");
        public string Text => GetText();
    }
}