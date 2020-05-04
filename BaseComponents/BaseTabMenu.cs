namespace SeleniumTestComponents.BaseComponents
{
    using SeleniumTestComponents.BaseComponents.Base;

    public abstract class BaseTabMenu : BaseElement
    {
        protected abstract TestCollection<Component> Items { get; }

        public void GoToTab(string tab)
        {
            Items.WaitUntilAny();
            Items.GetByText(tab).Click();
        }
    }
}
