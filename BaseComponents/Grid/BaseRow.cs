using System;
using SeleniumTestComponents.BaseComponents.Base;

namespace SeleniumTestComponents.BaseComponents.Grid
{
    public abstract class BaseRow : BaseElement
    {
        protected BaseCollection<BaseComponent> _columns;
        protected Func<BaseElement, string> _columnTextSelector;

        public BaseRow WithColumns(BaseCollection<BaseComponent> columns)
        {
            _columns = columns;
            return this;
        }

        public BaseRow WithColumnTextSelector(Func<BaseElement, string> textSelector)
        {
            _columnTextSelector = textSelector;
            return this;
        }

        protected abstract BaseCollection<BaseComponent> Cells { get; }

        public BaseComponent GetCell(int columnIndex)
        {
            return Cells.GetByIndex(columnIndex);
        }

        public string GetCellText(int columnIndex)
        {
            return GetCell(columnIndex).GetText();
        }

        public BaseComponent GetCell(string columnText)
        {
            var index = _columns.ScrollAndGetIndex(columnText, _columnTextSelector);
            return Cells.GetByIndex(index);
        }

        public string GetCellText(string columnText)
        {
            return GetCell(columnText).GetText();
        }

        public bool IsCellTextEmpty(string columnText)
        {
            return GetCell(columnText).IsTextEmpty();
        }
    }
}