namespace SeleniumTestComponents.KendoComponents
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoAlert : BaseAlert
    {
        protected override By DefaultSelector => By.ClassName("k-alert");

        protected override BaseElement TitleElement => GetChild<Component>(By.ClassName("k-dialog-title"));
        protected override BaseElement MessageElement => GetChild<Component>(By.ClassName("k-dialog-content"));
        protected override BaseElement Button => GetChild<Component>(By.ClassName("k-button"));
    }
}
