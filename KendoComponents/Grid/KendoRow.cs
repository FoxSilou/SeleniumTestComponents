namespace SeleniumTestComponents.KendoComponents.KendoGrid
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public abstract class KendoRow : BaseRow
    {
        protected override By DefaultSelector => By.TagName("tr");
        public By CheckBoxSelector => By.CssSelector("input[type='checkbox']");

        protected override TestCollection<Component> Cells => GetChildren<Component>(By.TagName("td"));

        public void WriteTextInCell(string columName, string text)
        {
            GetCell(columName).Click();
            Component input = GetCell(columName).GetChild<Component>(By.ClassName("k-textbox"));
            input.WebElement.SendKeys(Keys.Control + "A");
            input.WebElement.SendKeys(Keys.Backspace);
            input.WebElement.SendKeys(text);
        }

        public void SelectItemInCellByText(string columName, string id, string text)
        {
            GetCell(columName).Click();
            KendoRowDropdown dropdown = GetCell(columName).GetChild<KendoRowDropdown>().WithId(id);
            dropdown.SelectByText(text);
        }

        public bool IsCellChecked(string columName)
        {
            return string.Equals(GetCell(columName).GetChild<Component>(CheckBoxSelector).WebElement.GetProperty("checked"), "true", System.StringComparison.OrdinalIgnoreCase);
        }

        public void CheckInCell(string columName)
        {
            if (!IsCellChecked(columName)) GetCell(columName).Click();
        }

        private class KendoRowDropdown : BaseDropDown
        {
            private string _id;
            public KendoRowDropdown WithId(string id)
            {
                _id = id;
                return this;
            }
            protected override Component Select => GetChild<Component>(By.ClassName("k-select"));
            protected override Component Icon => GetChild<Component>(By.ClassName("k-icon"));
            protected override Component Input => GetChild<Component>(By.ClassName("k-input"));
            protected override Component ListContainer => Get<Component>(By.Id($"{_id}_listbox"));
            protected override TestCollection<Component> Items => ListContainer.GetChildren<Component>(By.ClassName("k-item"));

            protected override By DefaultSelector => By.ClassName("k-dropdown");

            protected override bool IsContentReady() => true;
        }
    }
}
