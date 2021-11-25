namespace SeleniumTestComponents.RadzenComponents
{
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class RadzenPanelMenu : BaseElement
    {
        protected override By DefaultSelector => By.ClassName("rz-panel-menu");

        protected BaseCollection<NavigationItem> Items => GetChildren<NavigationItem>(By.ClassName("rz-navigation-item"));

        public BaseCollection<NavigationItem> GetItems()
        {
            return Items;
        }

        public NavigationItem GetItemByText(string text)
        {
            return Items.GetByText(text,
                elt => elt.GetChild<BaseComponent>(By.ClassName("rz-navigation-item-text")).GetText());
        }

        public class NavigationItem : BaseElement
        {
            protected override By DefaultSelector => By.ClassName("rz-navigation-item");
            protected BaseComponent ChildMenu => GetChild<BaseComponent>(By.ClassName("rz-navigation-menu"));

            protected BaseCollection<BaseComponent> ChildItems =>
                GetChildren<BaseComponent>(By.ClassName("rz-navigation-item-link"));

            public BaseComponent GetItemByText(string text)
            {
                return ChildItems.GetByText(text);
            }
        }
    }
}