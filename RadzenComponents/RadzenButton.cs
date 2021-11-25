namespace SeleniumTestComponents.RadzenComponents
{
    using BaseComponents;
    using OpenQA.Selenium;

    public class RadzenButton : BaseButton
    {
        protected override By DefaultSelector => By.ClassName("rz-button");
    }
}