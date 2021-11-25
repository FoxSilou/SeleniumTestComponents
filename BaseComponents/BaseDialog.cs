namespace SeleniumTestComponents.BaseComponents
{
    using Base;

    public abstract class BaseDialog : BaseElement
    {
        protected abstract BaseElement TitleElement { get; }
        protected abstract BaseElement MessageElement { get; }
        protected abstract BaseElement OkButton { get; }
        protected abstract BaseElement CancelButton { get; }

        #region Values

        public string Title => TitleElement.GetText();
        public string Message => MessageElement.GetText();

        #endregion Values

        public void Ok()
        {
            OkButton.Click();
        }

        public void Cancel()
        {
            CancelButton.Click();
        }
    }
}