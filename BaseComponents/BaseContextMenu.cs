namespace SeleniumTestComponents.BaseComponents
{
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public abstract class BaseContextMenu : BaseElement
    {
        protected abstract TestCollection<Component> Items { get; }
        protected abstract bool IsItemDisabled(Component item);

        public void SelectByIndex(int index)
        {
            Items.GetByIndex(index).Click();
        }

        public bool IsItemDisabled(string text)
        {
            return IsItemDisabled(Items.GetByText(text));
        }

        public void SelectByText(string text)
        {
            Items.GetByText(text).Click();
        }
    }
}
