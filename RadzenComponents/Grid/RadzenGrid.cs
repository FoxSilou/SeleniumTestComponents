namespace SeleniumTestComponents.RadzenComponents.Grid
{
    using BaseComponents.Base;
    using SeleniumTestComponents.BaseComponents.Grid;
    using OpenQA.Selenium;

    public class RadzenGrid<T> : BaseGrid<T> where T : RadzenRow, new()
    {
        protected override By DefaultSelector => By.ClassName("rz-datatable");

        protected BaseComponent Headers => GetChild<BaseComponent>(By.ClassName("rz-datatable-scrollable-header"));
        protected BaseCollection<BaseComponent> HeaderRows => Headers.GetChildren<BaseComponent>(By.TagName("tr"));
        protected override BaseComponent Header => GridHeader;
        protected override BaseComponent GridHeader => HeaderRows.GetByIndex(0);
        protected BaseComponent FilterRow => HeaderRows.GetByIndex(1);
        protected override BaseCollection<BaseComponent> Columns => GridHeader.GetChildren<BaseComponent>(By.TagName("th"));
        protected BaseCollection<BaseComponent> Filters => FilterRow.GetChildren<BaseComponent>(By.TagName("th"));
        protected override BaseComponent GridContent => GetChild<BaseComponent>(By.ClassName("rz-datatable-scrollable-body"));
        protected  BaseComponent RowsContainer => GridContent.GetChild<BaseComponent>(By.ClassName("rz-datatable-data"));
        protected override BaseCollection<T> Rows => RowsContainer.GetChildren<T>(By.XPath("./tr"));

        protected override string IdSelector(BaseElement rowWebElement, int idColumnIndex)
        {
            return (rowWebElement as T).GetCell(idColumnIndex).GetText();
        }

        public void FilterTextBox(string columName, string valueToFilter)
        {
            int idColumnIndex = GetColumnIndex(columName);
            RadzenTextBox filterTextBox = Filters.GetByIndex(idColumnIndex).GetChild<RadzenTextBox>();
            filterTextBox.WriteText(valueToFilter);
            filterTextBox.Enter();
        }
    }
}