namespace SeleniumTestComponents.KendoComponents.Grid
{
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoHeaderWithFilter : BaseElement
    {
        protected override By DefaultSelector => null;

        protected BaseComponent OpenFilterButton => GetChild<BaseComponent>(By.ClassName("k-grid-filter"));
        protected BaseComponent FilterMenu => Get<BaseComponent>(By.ClassName("k-filter-menu"));
        protected KendoTextBox FilterTextBox => FilterMenu.GetChild<KendoTextBox>(By.ClassName("k-textbox"));
        protected KendoNumericTextBox FilterNumericTextBox => FilterMenu.GetChild<KendoNumericTextBox>(By.ClassName("k-numerictextbox"));
        protected BaseComponent FilterButton => FilterMenu.GetChild<BaseComponent>(By.CssSelector("button.k-button[type='submit']"));
        protected BaseComponent CancelButton => FilterMenu.GetChild<BaseComponent>(By.CssSelector("button.k-button[type='reset']"));

        public void OpenFilter()
        {
            OpenFilterButton.Click();
        }

        public void FilterByText(string text)
        {
            OpenFilter();
            FilterTextBox.WriteText(text);
            FilterButton.Click();
        }

        public void FilterByNumber(string number)
        {
            OpenFilter();
            FilterNumericTextBox.WriteText(number);
            FilterButton.Click();
        }
    }
}