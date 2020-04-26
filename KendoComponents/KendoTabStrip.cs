namespace SeleniumTestComponents.KendoComponents
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;
    using System;

    public class KendoTabStrip : BaseTabMenu
    {
        protected override By DefaultSelector => null;
        protected Component ItemsContainer => GetChild<Component>(By.ClassName("k-tabstrip-items"));
        protected override TestCollection<Component> Items => ItemsContainer.GetChildren<Component>(By.ClassName("k-item"));
    }
}
