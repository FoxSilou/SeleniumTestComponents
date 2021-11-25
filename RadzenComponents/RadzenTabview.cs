namespace SeleniumTestComponents.RadzenComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class RadzenTabview : BaseTabMenu
    {
        protected override By DefaultSelector => By.ClassName("rz-tabview");
        protected BaseElement TabList => GetChild<BaseComponent>(By.ClassName("rz-tabview-nav"));
        protected override BaseCollection<BaseComponent> Items => TabList.GetChildren<BaseComponent>(By.TagName("li"));
        protected BaseElement Panel => GetChild<BaseComponent>(By.ClassName("rz-tabview-panel"));

        public void Navigate(string tab)
        {
            if (!IsCurrentTab(tab)) GoToTab(tab);
        }

        public bool IsCurrentTab(string tab)
        {
            Items.WaitUntilAny();
            return Items.GetByText(tab).WebElement.GetAttribute("class").Contains("rz-tabview-selected");
        }

        public BaseElement GetPanel()
        {
            return Panel;
        }
    }
}