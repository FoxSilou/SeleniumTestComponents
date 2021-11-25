namespace SeleniumTestComponents.RadzenComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class RadzenNotification : BaseAlert
    {
        protected override By DefaultSelector => By.ClassName("rz-notification");

        private BaseElement Container => GetChild<BaseComponent>(By.ClassName("rz-growl-item-container"));
        private BaseElement Panel => GetChild<BaseComponent>(By.ClassName("rz-growl-message"));

        protected override BaseElement TitleElement => Panel.GetChild<BaseComponent>(By.ClassName("rz-growl-title"));
        protected override BaseElement MessageElement => Panel.GetChild<BaseComponent>(By.TagName("p"));
        protected override BaseElement Button => GetChild<BaseComponent>(By.ClassName("rz-growl-icon-close"));

        private bool IsError()
        {
            _longWait.Until(d => Container.Displayed());
            return Container.WebElement.GetAttribute("class").Contains("rz-growl-message-error");
        }

        private bool IsSuccess()
        {
            _longWait.Until(d => Container.Displayed());
            return Container.WebElement.GetAttribute("class").Contains("rz-growl-message-success");
        }

        public void WaitUntilSuccessAndClick()
        {
            _longWait.Until(d => IsSuccess());
            Click();
        }

        public void WaitUntilErrorAndClick()
        {
            _longWait.Until(d => IsError());
            Click();
        }
    }
}