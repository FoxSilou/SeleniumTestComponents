namespace SeleniumTestComponents.BaseComponents
{
    using SeleniumTestComponents.BaseComponents.Base;

    public abstract class BaseRow : BaseElement
    {
        protected TestCollection<Component> _columns;
        public BaseRow WithColumns(TestCollection<Component> columns)
        {
            _columns = columns;
            return this;
        }

        protected abstract TestCollection<Component> Cells { get; }

        protected Component GetCell(string columName)
        {
            return Cells.GetByIndex(_columns.GetIndex(columName));
        }

        public string GetCellText(string columName)
        {
            return GetCell(columName).GetText();
        }
    }
}
