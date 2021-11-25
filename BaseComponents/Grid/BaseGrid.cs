using System;
using System.Linq;
using SeleniumTestComponents.BaseComponents.Base;

namespace SeleniumTestComponents.BaseComponents.Grid
{
    public abstract class BaseGrid<T> : BaseElement where T : BaseRow, new()
    {
        protected string _idColumnName;
        protected Func<BaseElement, string> _columnTextSelector;

        public BaseGrid<T> WithIdColumnName(string idColumnName)
        {
            _idColumnName = idColumnName;
            return this;
        }

        public BaseGrid<T> WithColumnTextSelector(Func<BaseElement, string> textSelector)
        {
            _columnTextSelector = textSelector;
            return this;
        }

        protected abstract BaseComponent Header { get; }
        protected abstract BaseComponent GridHeader { get; }
        protected abstract BaseCollection<BaseComponent> Columns { get; }
        protected abstract BaseComponent GridContent { get; }
        protected abstract BaseCollection<T> Rows { get; }

        protected abstract string IdSelector(BaseElement rowWebElement, int idColumnIndex);

        public int GetRowIndex(string rowId)
        {
            _longWait.Until(d => GridContent.Exists());
            Rows.WaitUntilAny();
            int idColumnIndex = GetColumnIndex(_idColumnName);

            return Rows.GetIndex(rowId, elt => IdSelector(elt, idColumnIndex));
        }

        public int GetColumnIndex(string columnName)
        {
            return Columns.ScrollAndGetIndex(columnName, _columnTextSelector);
        }

        public T GetRow(string rowId)
        {
            return Rows.GetByIndex(GetRowIndex(rowId)).WithColumns(Columns).WithColumnTextSelector(_columnTextSelector) as T;
        }

        public T GetFirstRow()
        {
            return Rows.GetByIndex(0).WithColumns(Columns).WithColumnTextSelector(_columnTextSelector) as T;
        }

        public T GetLastRow()
        {
            return Rows.GetByIndex(Rows.WebElements.Count() - 1).WithColumns(Columns) as T;
        }

        public bool ContainsRowWithId(string text)
        {
            int idColumnIndex = GetColumnIndex(_idColumnName);
            return Rows.ContainsElementWithText(text, elt => IdSelector(elt, idColumnIndex));
        }

        public bool DoesNotContainsRowWithId(string text)
        {
            int idColumnIndex = GetColumnIndex(_idColumnName);
            return Rows.DoesntContainsElementWithText(text, elt => IdSelector(elt, idColumnIndex));
        }

        public int GetRowCount()
        {
            return Rows.WebElements.Count();
        }
    }
}