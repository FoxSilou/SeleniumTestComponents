namespace SeleniumTestComponents.KendoComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoCheckBox : BaseCheckBox
    {
        protected override By DefaultSelector => By.ClassName("k-checkbox");

        protected override BaseElement InputElement => this;

        public new void Set(bool value)
        {
            if (value) Check();
            else Uncheck();
        }

        public new void Check()
        {
            if (!Checked) Click();
        }

        public new void Uncheck()
        {
            if (Checked) Click();
        }

        public new void Click()
        {
            // TODO
            //IJavaScriptExecutor js = ((RobustWebDriver)_driver).GetScriptExecutor();
            //js.ExecuteScript("arguments[0].click();", WebElement);
        }
    }
}