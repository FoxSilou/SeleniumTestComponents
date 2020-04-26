namespace SeleniumTestComponents.KendoComponents
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoCheckBox : BaseCheckBox
    {
        protected override By DefaultSelector => By.ClassName("k-checkbox");

        protected override BaseElement InputElement => this;

        public new void Set(bool value)
        {
            Click();
        }

        public new void Click()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("arguments[0].click();", WebElement);
        }
    }
}
