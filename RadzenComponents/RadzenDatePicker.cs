namespace SeleniumTestComponents.RadzenComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class RadzenDatePicker : BaseDatePicker
    {
        protected override By DefaultSelector => By.ClassName("rz-calendar");
        protected override BaseElement Input => GetChild<BaseComponent>(By.ClassName("rz-inputtext"));
        protected override BaseElement Select => GetChild<BaseComponent>(By.ClassName("rz-datepicker-trigger"));
        protected override BaseElement Calendar => Get<BaseComponent>(By.ClassName("rz-datepicker-calendar-container"));

        protected override string GetDateFromInput(BaseElement input) => input.WebElement.GetAttribute("value");

        public BaseElement GetCalendar() => Calendar;
    }
}