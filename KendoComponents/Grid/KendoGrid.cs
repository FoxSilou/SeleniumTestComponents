namespace SeleniumTestComponents.KendoComponents.Grid
{
    using SeleniumTestComponents.BaseComponents.Grid;
    using OpenQA.Selenium;
    using BaseComponents.Base;

    public class KendoGrid<T> : BaseGrid<T> where T : KendoRow, new()
    {
        protected override By DefaultSelector => null;

        protected override BaseComponent Header => GetChild<BaseComponent>(By.ClassName("k-header"));
        protected override BaseComponent GridHeader => GetChild<BaseComponent>(By.ClassName("k-grid-header"));
        protected override BaseCollection<BaseComponent> Columns => GetChildren<BaseComponent>(By.TagName("th"));
        protected override BaseComponent GridContent => GetChild<BaseComponent>(By.ClassName("k-grid-content"));
        protected override BaseCollection<T> Rows => GridContent.GetChildren<T>(By.TagName("tr"));

        protected override string IdSelector(BaseElement rowWebElement, int idColumnIndex) =>
            rowWebElement.GetChildren<BaseComponent>(By.TagName("td")).GetByIndex(idColumnIndex).GetText();
    }
}