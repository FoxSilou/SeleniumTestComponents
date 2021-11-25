namespace SeleniumTestComponents.RadzenComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class RadzenDropDown : BaseDropDown
    {
        protected override By DefaultSelector => By.ClassName("rz-dropdown");
        protected override BaseComponent Select => GetChild<BaseComponent>(By.ClassName("rz-dropdown-trigger"));
        protected override BaseComponent Icon => Select.GetChild<BaseComponent>(By.ClassName("rz-dropdown-trigger-icon"));
        protected override BaseComponent Input => GetChild<BaseComponent>(By.ClassName("rz-inputtext"));
        public string Id => WebElement.GetAttribute("id");
        protected override BaseComponent ListContainer => Get<BaseComponent>(By.Id($"popup{Id}"));
        protected override BaseCollection<BaseComponent> Items => ListContainer.GetChildren<BaseComponent>(By.ClassName("rz-dropdown-item"));

        protected override bool IsContentReady()
        {
            return true;
        }

        public new void SelectByText(string text)
        {
            base.SelectByText(text);
        }
    }
}