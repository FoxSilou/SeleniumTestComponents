namespace SeleniumTestComponents.BaseComponents
{
    using Base;
    using OpenQA.Selenium;

    public abstract class BasePage : BaseElement
    {
        public string Name { get; set; }

        public BasePage(IWebDriver driver) : base()
        {
            WithDriver(driver);
            WithPage(this);
        }

        public T As<T>() where T : BasePage
        {
            return this as T;
        }
    }
}