namespace SeleniumTestComponents.KendoComponents.KendoGrid
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoHeaderWithFilter : BaseElement
    {
        protected override By DefaultSelector => null;

        protected Component OpenFilterButton => GetChild<Component>(By.ClassName("k-grid-filter"));
        protected Component FilterMenu => Get<Component>(By.ClassName("k-filter-menu"));
        protected KendoTextBox FilterTextBox => FilterMenu.GetChild<KendoTextBox>(By.ClassName("k-textbox"));
        protected Component FilterButton => FilterMenu.GetChild<Component>(By.CssSelector("button.k-button[type='submit']"));
        protected Component CancelButton => FilterMenu.GetChild<Component>(By.CssSelector("button.k-button[type='reset']"));

        public void OpenFilter()
        {
            OpenFilterButton.Click();
            _wait.Until(d => FilterMenu.Displayed());
        }

        public void FilterByText(string text)
        {
            OpenFilter();
            FilterTextBox.WriteText(text);
            FilterButton.Click();
        }
    }
}
