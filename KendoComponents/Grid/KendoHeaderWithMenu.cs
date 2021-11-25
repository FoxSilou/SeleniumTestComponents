namespace SeleniumTestComponents.KendoComponents.Grid
{
    using BaseComponents.Base;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using System.Threading;

    public class KendoHeaderWithMenu : BaseElement
    {
        protected override By DefaultSelector => null;

        protected BaseComponent OpenMoreButton => GetChild<BaseComponent>(By.ClassName("k-header-column-menu"));
        protected BaseComponent MoreMenu => Get<BaseComponent>(By.CssSelector("div.k-column-menu[aria-hidden='false']"));
        protected BaseComponent FilterItem => MoreMenu.Get<BaseComponent>(By.ClassName("k-filter-item"));
        protected BaseComponent FilterItemMenu => FilterItem.GetChild<BaseComponent>(By.ClassName("k-filter-menu"));
        protected KendoNumericTextBox FilterNumerictextBox => FilterItemMenu.GetChild<KendoNumericTextBox>(By.ClassName("k-numerictextbox"));
        protected KendoTextBox FilterSearch => FilterItemMenu.GetChild<KendoTextBox>(By.ClassName("k-textbox"));
        protected BaseCollection<BaseComponent> FilterCheckBoxes => FilterItemMenu.GetChildren<BaseComponent>(By.TagName("li"));
        protected BaseComponent FilterButton => FilterItemMenu.GetChild<BaseComponent>(By.CssSelector("button.k-button[type='submit']"));
        protected BaseComponent DeleteFilterButton => FilterItemMenu.GetChild<BaseComponent>(By.CssSelector("button.k-button[type='reset']"));

        public void OpenMoreMenu()
        {
            OpenMoreButton.Click();
        }

        public void RemoveFilters()
        {
            OpenMoreMenu();
            Actions actions = new Actions(_driver);
            actions.MoveToElement(FilterItem.WebElement).Build().Perform();
            actions.MoveToElement(FilterItemMenu.WebElement).Build().Perform();
            DeleteFilterButton.Click();
        }

        public void MoreFilterByText(string text)
        {
            OpenMoreMenu();
            Actions actions = new Actions(_driver);
            actions.MoveToElement(FilterItem.WebElement).Build().Perform();
            actions.MoveToElement(FilterItemMenu.WebElement).Build().Perform();
            FilterNumerictextBox.WriteText(text);
            FilterButton.Click();
        }

        public void MoreFilterByChoice(string name)
        {
            OpenMoreMenu();
            Helpers.RepeatUntilCondition(() => MoveToFilterAndSelectAction(name), () => FilterButton.Exists());
            FilterButton.Click();
            Thread.Sleep(500);
        }

        private void MoveToFilterAndSelectAction(string name)
        {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(FilterItem.WebElement).Build().Perform();
            FilterCheckBoxes.GetByText(name).GetChild<BaseComponent>(By.TagName("input")).Click();
        }
    }
}