namespace SeleniumTestComponents.KendoComponents.KendoGrid
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoRow : BaseRow
    {
        protected override TestCollection<Component> Cells => GetChildren<Component>(By.TagName("td"));

        protected override By DefaultSelector => By.TagName("tr");

        public void WriteTextInCell(string columName, string text)
        {
            GetCell(columName).Click();
            BaseElement input = GetCell(columName).GetChild<Component>(By.ClassName("k-textbox"));
            input.WebElement.SendKeys(Keys.Control + "A");
            input.WebElement.SendKeys(Keys.Backspace);
            input.WebElement.SendKeys(text);
        }

        public bool GetCellIsChecked(string columName)
        {
            return GetCell(columName).GetChild<Component>(By.ClassName("chkbx")).WebElement.GetProperty("checked").ToLower() == "true";
        }

        public void CheckInCell(string columName)
        {
            GetCell(columName).Click();
            GetCell(columName). GetChild<Component>(By.ClassName("chkbx")).Click();
        }
    }
}
