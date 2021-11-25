namespace SeleniumTestComponents.BaseComponents
{
    using Base;

    public abstract class BaseDropDown : BaseElement
    {
        protected abstract BaseComponent Select { get; }
        protected abstract BaseComponent Icon { get; }
        protected abstract BaseComponent Input { get; }
        protected abstract BaseComponent ListContainer { get; }
        protected abstract BaseCollection<BaseComponent> Items { get; }

        protected abstract bool IsContentReady();

        #region Values

        public string Text => Input.GetText();
        public bool IsDisabled => IsNotInteractable();

        #endregion Values

        public void OpenList()
        {
            _longWait.Until(d => IsContentReady());
            Helpers.RepeatUntilCondition(() => Click(), () => ListContainer.Displayed());
        }

        public void SelectByText(string text)
        {
            OpenList();
            Items.GetByText(text).Click();
        }

        public void WaitUntilTextNonEmpty()
        {
            Input.WaitUntilTextIsNonEmpty();
        }

        public void WaitUntilTextEmpty()
        {
            Input.WaitUntilTextIsEmpty();
        }
    }
}