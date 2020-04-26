namespace SeleniumTestComponents.BaseComponents
{
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public abstract class BaseDropDown : BaseElement
    {
        protected abstract Component Select { get; }
        protected abstract Component Icon { get; }
        protected abstract Component Input { get; }
        protected abstract Component ListContainer { get; }
        protected abstract TestCollection<Component> Items { get; }
        protected abstract bool IsContentReady();

        #region Values
        public string Text => Input.GetText();
        public bool IsDisabled => IsNotInteractable();
        #endregion Values

        public void OpenList()
        {
            _longWait.Until(d => IsContentReady());
            Click();
        }

        public void SelectByText(string text)
        {
            OpenList();
            Items.GetByText(text).Click();
        }

        public void WaitUntilTextNonEmpty()
        {
            _longWait.Until(d => !string.IsNullOrEmpty(Text));
        }

        public void WaitUntiTextEmpty()
        {
            _longWait.Until(d => string.IsNullOrEmpty(Text));
        }
    }
}
