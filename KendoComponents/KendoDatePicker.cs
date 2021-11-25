namespace SeleniumTestComponents.KendoComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoDatePicker : BaseDatePicker
    {
        protected override By DefaultSelector => null;
        protected override BaseElement Input => GetChild<BaseComponent>(By.ClassName("k-input"));
        protected override BaseElement Select => GetChild<BaseComponent>(By.ClassName("k-select"));
        protected override BaseElement Calendar => Get<BaseComponent>(By.ClassName("k-calendar-container"));

        protected override string GetDateFromInput(BaseElement input) => input.WebElement.GetAttribute("value");

        public KendoDatePicker WithId(string id)
        {
            WithSelector(By.CssSelector($"span.{id.ToLower()}-datepicker"));
            return this;
        }

        public BaseElement GetCalendar() => Calendar;
    }
}