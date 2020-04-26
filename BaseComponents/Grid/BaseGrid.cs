namespace SeleniumTestComponents.BaseComponents
{
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public abstract class BaseGrid<T> : BaseElement where T : BaseRow, new()
    {
        protected string _idColumnName; 
        public BaseGrid<T> WithIdColumnName(string idColumnName)
        {
            _idColumnName = idColumnName;
            return this;
        }

        protected abstract Component Header { get; }
        protected abstract Component GridHeader { get; }
        protected abstract TestCollection<Component> Columns { get; }
        protected abstract Component GridContent { get; }
        protected abstract TestCollection<T> Rows { get; }
        protected abstract string IdSelector(IWebElement rowWebElement);

        public int GetRowIndex(string rowId)
        {
            _longWait.Until(d => GridContent.Exists());
            Rows.WaitUntilAny();
            int idColumnIndex = GetColumnIndex(_idColumnName);
            return Rows.GetIndex(rowId, IdSelector);
        }

        public int GetColumnIndex(string columnName)
        {
            return Columns.GetIndex(columnName);
        }

        public T GetRow(string rowId)
        {
            return Rows.GetByIndex(GetRowIndex(rowId)).WithColumns(Columns) as T;
        }

        public T GetFirstRow()
        {
            return Rows.GetByIndex(0).WithColumns(Columns) as T;
        }
    }
}
