namespace SeleniumTestComponents.KendoComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoAlert : BaseAlert
    {
        protected override By DefaultSelector => By.ClassName("k-alert");

        protected override BaseElement TitleElement => GetChild<BaseComponent>(By.ClassName("k-dialog-title"));
        protected override BaseElement MessageElement => GetChild<BaseComponent>(By.ClassName("k-dialog-content"));
        protected override BaseElement Button => GetChild<BaseComponent>(By.ClassName("k-button"));
    }
}