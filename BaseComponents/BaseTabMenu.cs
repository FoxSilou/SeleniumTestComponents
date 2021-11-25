namespace SeleniumTestComponents.BaseComponents
{
    using Base;

    public abstract class BaseTabMenu : BaseElement
    {
        protected abstract BaseCollection<BaseComponent> Items { get; }

        public void GoToTab(string tab)
        {
            Items.WaitUntilAny();
            Items.GetByText(tab).Click();
        }
    }
}