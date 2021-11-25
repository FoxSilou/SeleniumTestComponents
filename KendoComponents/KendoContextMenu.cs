namespace SeleniumTestComponents.KendoComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoContextMenu : BaseContextMenu
    {
        protected override By DefaultSelector => null;
        protected override BaseCollection<BaseComponent> Items => GetChildren<BaseComponent>(By.ClassName("k-item"));

        protected override bool IsItemDisabled(BaseComponent item)
        {
            return item.WebElement.GetAttribute("aria-disabled") == "true";
        }
    }
}