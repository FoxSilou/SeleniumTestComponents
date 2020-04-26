namespace SeleniumTestComponents.BaseComponents
{
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public abstract class BaseAlert : BaseElement
    {
        protected abstract BaseElement TitleElement { get; }
        protected abstract BaseElement MessageElement { get; }
        protected abstract BaseElement Button { get; }

        #region Values
        public string Title => TitleElement.GetText();
        public string Message => MessageElement.GetText();
        #endregion Values

        public void Ok()
        {
            Button.Click();
        }
    }
}
