namespace SeleniumTestComponents.KendoComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoConfirm : BaseDialog
    {
        protected override By DefaultSelector => By.ClassName("k-confirm");

        protected override BaseElement TitleElement => GetChild<BaseComponent>(By.ClassName("k-dialog-title"));
        protected override BaseElement MessageElement => GetChild<BaseComponent>(By.ClassName("k-dialog-content"));
        protected override BaseElement OkButton => GetChild<BaseComponent>(By.ClassName("k-primary"));
        protected override BaseElement CancelButton => GetChildren<BaseComponent>(By.ClassName("k-button")).GetByIndex(1);
    }
}