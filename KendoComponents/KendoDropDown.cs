namespace SeleniumTestComponents.KendoComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;
    using System.Threading;

    public class KendoDropDown : BaseDropDown
    {
        private string _id;

        public KendoDropDown WithId(string prefix, string id)
        {
            _id = prefix + id;
            WithSelector(By.CssSelector($"span.{id.ToLower()}-dropdown"));
            return this;
        }

        protected override By DefaultSelector => null;
        protected override BaseComponent Select => GetChild<BaseComponent>(By.ClassName("k-select"));
        protected override BaseComponent Icon => Select.GetChild<BaseComponent>(By.ClassName("k-icon"));
        protected override BaseComponent Input => GetChild<BaseComponent>(By.ClassName("k-input"));
        protected override BaseComponent ListContainer => Get<BaseComponent>(By.CssSelector($"#{_id}-list[aria-hidden='false']"));
        protected override BaseCollection<BaseComponent> Items => ListContainer.GetChildren<BaseComponent>(By.ClassName("k-item"));
        protected BaseComponent OptionLabel => ListContainer.GetChild<BaseComponent>(By.ClassName("k-list-optionlabel"));

        protected override bool IsContentReady()
        {
            _longWait.Until(d => !Icon.WebElement.GetAttribute("class").Contains("k-i-loading"));
            Thread.Sleep(500);
            return !Icon.WebElement.GetAttribute("class").Contains("k-i-loading");
        }

        public new void SelectByText(string text)
        {
            if (string.IsNullOrEmpty(text)) SelectOption();
            else base.SelectByText(text);
        }

        protected void SelectOption()
        {
            OpenList();
            OptionLabel.Click();
        }
    }
}