namespace SeleniumTestComponents.KendoComponents.KendoGrid
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoGrid<T> : BaseGrid<T> where T : KendoRow, new()
    {
        protected override By DefaultSelector => null;

        protected override Component Header => GetChild<Component>(By.ClassName("k-header"));
        protected override Component GridHeader => GetChild<Component>(By.ClassName("k-grid-header"));
        protected override TestCollection<Component> Columns => GetChildren<Component>(By.TagName("th"));
        protected override Component GridContent => GetChild<Component>(By.ClassName("k-grid-content"));
        protected override TestCollection<T> Rows => GridContent.GetChildren<T>(By.TagName("tr"));

        protected override string IdSelector(IWebElement rowWebElement) =>
            Helpers.GetWebElement(_driver, By.TagName("td"), GetColumnIndex(_idColumnName), rowWebElement).Text;
    }
}
