namespace SeleniumTestComponents.KendoComponents
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoContextMenu : BaseContextMenu
    {
        protected override By DefaultSelector => null;
        protected override TestCollection<Component> Items => GetChildren<Component>(By.ClassName("k-item"));

        protected override bool IsItemDisabled(Component item)
        {
            return item.WebElement.GetAttribute("aria-disabled") == "true";
        }
    }
}
