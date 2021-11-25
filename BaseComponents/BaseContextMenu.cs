namespace SeleniumTestComponents.BaseComponents
{
    using Base;

    public abstract class BaseContextMenu : BaseElement
    {
        protected abstract BaseCollection<BaseComponent> Items { get; }

        protected abstract bool IsItemDisabled(BaseComponent item);

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