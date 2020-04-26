namespace SeleniumTestComponents.KendoComponents.KendoGrid
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Interactions;
    using System.Threading;

    public class KendoHeaderWithMenu : BaseElement
    {
        protected override By DefaultSelector => null;

        protected Component OpenMoreButton => GetChild<Component>(By.ClassName("k-header-column-menu"));
        protected Component MoreMenu => Get<Component>(By.CssSelector("div.k-column-menu[aria-hidden='false']"));
        protected Component FilterItem => MoreMenu.Get<Component>(By.ClassName("k-filter-item"));
        protected Component FilterItemMenu => FilterItem.GetChild<Component>(By.ClassName("k-filter-menu"));
        protected KendoNumericTextBox FilterNumerictextBox => FilterItemMenu.GetChild<KendoNumericTextBox>(By.ClassName("k-numerictextbox"));
        protected KendoTextBox FilterSearch => FilterItemMenu.GetChild<KendoTextBox>(By.ClassName("k-textbox"));
        protected TestCollection<Component> FilterCheckBoxes => FilterItemMenu.GetChildren<Component>(By.TagName("li"));
        protected Component FilterButton => FilterItemMenu.GetChild<Component>(By.CssSelector("button.k-button[type='submit']"));

        public void OpenMoreMenu()
        {
            OpenMoreButton.Click();
            _wait.Until(d => MoreMenu.Displayed());
            _wait.Until(d => FilterItem.Displayed());
        }

        public void MoreFilterByText(string text)
        {
            OpenMoreMenu();
            Actions actions = new Actions(_driver);
            actions.MoveToElement(FilterItem.WebElement).Build().Perform();
            actions.MoveToElement(FilterItemMenu.WebElement).Build().Perform();
            FilterNumerictextBox.SetText(text);
            FilterButton.Click();
        }

        public void MoreFilterByChoice(string name)
        {
            OpenMoreMenu();
            Actions actions = new Actions(_driver);
            actions.MoveToElement(FilterItem.WebElement).Build().Perform();
            //actions.MoveToElement(FilterItemMenu.WebElement).Build().Perform();
            FilterCheckBoxes.GetByText(name).GetChild<Component>(By.TagName("input")).Click();
            FilterButton.Click();
            Thread.Sleep(500);
        }
    }
}
