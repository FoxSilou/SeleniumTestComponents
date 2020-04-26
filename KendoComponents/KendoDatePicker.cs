namespace SeleniumTestComponents.KendoComponents
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoDatePicker : BaseDatePicker
    {
        protected override By DefaultSelector => null;
        protected override BaseElement Input => GetChild<Component>(By.ClassName("k-input"));
        protected override BaseElement Select => GetChild<Component>(By.ClassName("k-select"));
        protected override BaseElement Calendar => Get<Component>(By.ClassName("k-calendar-container"));

        protected override string GetDateFromInput(BaseElement input) => input.WebElement.GetAttribute("value");

        public KendoDatePicker WithId(string id)
        {
            WithSelector(By.CssSelector($"span.{id.ToLower()}-datepicker"));
            return this;
        }
    }
}
