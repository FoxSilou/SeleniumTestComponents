using SeleniumTestComponents.BaseComponents.Grid;

namespace SeleniumTestComponents.KendoComponents.Grid
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public abstract class KendoRow : BaseRow
    {
        protected override By DefaultSelector => By.TagName("tr");
        public By CheckBoxSelector => By.CssSelector("input[type='checkbox']");

        protected override BaseCollection<BaseComponent> Cells => GetChildren<BaseComponent>(By.TagName("td"));

        public void WriteTextInCell(int columnIndex, string text)
        {
            GetCell(columnIndex).Click();
            BaseElement input = GetCell(columnIndex).GetChild<BaseComponent>(By.ClassName("k-textbox"));
            input.WebElement.SendKeys(Keys.Control + "a");
            input.WebElement.SendKeys(Keys.Backspace);
            input.WebElement.SendKeys(text);
        }

        public void WriteTextInCell(string columnText, string text)
        {
            GetCell(columnText).Click();
            BaseElement input = GetCell(columnText).GetChild<BaseComponent>(By.ClassName("k-textbox"));
            input.WebElement.SendKeys(Keys.Control + "a");
            input.WebElement.SendKeys(Keys.Backspace);
            input.WebElement.SendKeys(text);
        }

        public void SelectItemInCellByText(int columnIndex, string id, string text)
        {
            GetCell(columnIndex).Click();
            KendoRowDropdown dropdown = GetCell(columnIndex).GetChild<KendoRowDropdown>().WithId(id);
            dropdown.SelectByText(text);
        }

        public void SelectItemInCellByText(string columnText, string id, string text)
        {
            GetCell(columnText).Click();
            KendoRowDropdown dropdown = GetCell(columnText).GetChild<KendoRowDropdown>().WithId(id);
            dropdown.SelectByText(text);
        }

        public bool IsCellChecked(int columnIndex)
        {
            return string.Equals(GetCell(columnIndex).GetChild<BaseComponent>(CheckBoxSelector).WebElement.GetProperty("checked"), "true", System.StringComparison.OrdinalIgnoreCase);
        }

        public bool IsCellChecked(string columnText)
        {
            return string.Equals(GetCell(columnText).GetChild<BaseComponent>(CheckBoxSelector).WebElement.GetProperty("checked"), "true", System.StringComparison.OrdinalIgnoreCase);
        }

        public void CheckInCell(int columnIndex)
        {
            if (!IsCellChecked(columnIndex)) GetCell(columnIndex).Click();
        }

        public void CheckInCell(string columnText)
        {
            if (!IsCellChecked(columnText)) GetCell(columnText).Click();
        }

        private class KendoRowDropdown : BaseDropDown
        {
            private string _id;

            public KendoRowDropdown WithId(string id)
            {
                _id = id;
                return this;
            }

            protected override BaseComponent Select => GetChild<BaseComponent>(By.ClassName("k-select"));
            protected override BaseComponent Icon => GetChild<BaseComponent>(By.ClassName("k-icon"));
            protected override BaseComponent Input => GetChild<BaseComponent>(By.ClassName("k-input"));
            protected override BaseComponent ListContainer => Get<BaseComponent>(By.Id($"{_id}_listbox"));
            protected override BaseCollection<BaseComponent> Items => ListContainer.GetChildren<BaseComponent>(By.ClassName("k-item"));

            protected override By DefaultSelector => By.ClassName("k-dropdown");

            protected override bool IsContentReady() => true;
        }
    }
}