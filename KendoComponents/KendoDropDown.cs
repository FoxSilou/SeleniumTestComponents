namespace SeleniumTestComponents.KendoComponents
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;
    using System.Threading;

    public class KendoDropDown : BaseDropDown
    {
        private string _id;
        public KendoDropDown WithId(string id)
        {
            _id = id;
            WithSelector(By.CssSelector($"span.{id.ToLower()}-dropdown"));
            return this;
        }

        protected override By DefaultSelector => null;
        protected override Component Select => GetChild<Component>(By.ClassName("k-select"));
        protected override Component Icon => Select.GetChild<Component>(By.ClassName("k-icon"));
        protected override Component Input => GetChild<Component>(By.ClassName("k-input"));
        protected override Component ListContainer => Get<Component>(By.Id($"{_id}_listbox"));
        protected override TestCollection<Component> Items => ListContainer.GetChildren<Component>(By.ClassName("k-item"));

        protected override bool IsContentReady()
        {
            _longWait.Until(d => !Icon.WebElement.GetAttribute("class").Contains("k-i-loading"));
            Thread.Sleep(500);
            return !Icon.WebElement.GetAttribute("class").Contains("k-i-loading");
        }
    }
}
