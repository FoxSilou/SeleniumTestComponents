namespace SeleniumTestComponents.RadzenComponents.Grid
{
    using BaseComponents;
    using BaseComponents.Base;
    using SeleniumTestComponents.BaseComponents.Grid;
    using OpenQA.Selenium;

    public abstract class RadzenRow : BaseRow
    {
        protected override By DefaultSelector => By.TagName("tr");

        protected override BaseCollection<BaseComponent> Cells => GetChildren<BaseComponent>(By.XPath("./td"));

        public void WriteTextInCell(int columnIndex, string text)
        {
            GetCell(columnIndex).Click();
            BaseElement input = GetCell(columnIndex).GetChild<BaseComponent>(By.ClassName("rz-textbox"));
            input.WebElement.SendKeys(Keys.Control + "a");
            input.WebElement.SendKeys(Keys.Backspace);
            input.WebElement.SendKeys(text);
        }

        public void WriteTextInCell(string columnText, string text)
        {
            GetCell(columnText).Click();
            BaseElement input = GetCell(columnText).GetChild<BaseComponent>(By.ClassName("rz-textbox"));
            input.WebElement.SendKeys(Keys.Control + "a");
            input.WebElement.SendKeys(Keys.Backspace);
            input.WebElement.SendKeys(text);
        }

        public void SelectItemInCellByText(int columnIndex, string id, string text)
        {
            GetCell(columnIndex).Click();
            RadzenRowDropdown dropdown = GetCell(columnIndex).GetChild<RadzenRowDropdown>();
            dropdown.SelectByText(text);
        }

        public void SelectItemInCellByText(string columnText, string id, string text)
        {
            GetCell(columnText).Click();
            RadzenRowDropdown dropdown = GetCell(columnText).GetChild<RadzenRowDropdown>();
            dropdown.SelectByText(text);
        }

        public bool IsCellChecked(int columnIndex)
        {
            return GetCell(columnIndex)
                .GetChild<BaseComponent>(By.ClassName("rz-chkbox-box"))
                .WebElement.GetAttribute("class").Contains("rz-state-active");
        }

        public bool IsCellChecked(string columnText)
        {
            return GetCell(columnText)
                .GetChild<BaseComponent>(By.ClassName("rz-chkbox-box"))
                .WebElement.GetAttribute("class").Contains("rz-state-active");
        }

        public void CheckOrUncheckCell(bool checkValue, int columnIndex)
        {
            if (IsCellChecked(columnIndex) != checkValue) GetCell(columnIndex).Click();
        }

        public void CheckOrUncheckCell(bool checkValue, string columnText)
        {
            if (IsCellChecked(columnText) != checkValue) GetCell(columnText).Click();
        }

        private class RadzenRowDropdown : BaseDropDown
        {
            protected override BaseComponent Select => GetChild<BaseComponent>(By.ClassName("rz-dropdown-trigger"));
            protected override BaseComponent Icon => Select.GetChild<BaseComponent>(By.ClassName("rz-dropdown-trigger-icon"));
            protected override BaseComponent Input => GetChild<BaseComponent>(By.ClassName("rz-inputtext"));
            public string Id => WebElement.GetAttribute("id");
            protected override BaseComponent ListContainer => Get<BaseComponent>(By.Id($"popup{Id}"));
            protected override BaseCollection<BaseComponent> Items => ListContainer.GetChildren<BaseComponent>(By.ClassName("rz-dropdown-item"));

            protected override By DefaultSelector => By.ClassName("rz-dropdown");

            protected override bool IsContentReady() => true;
        }
    }
}