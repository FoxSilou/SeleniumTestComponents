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
        protected Component PreviousButton => GetChild<Component>(By.ClassName("k-tabstrip-prev"));
        protected Component NextButton => GetChild<Component>(By.ClassName("k-tabstrip-next"));

        public void Navigate(string tab)
        {
            int attempts = 0;
            while (attempts < 10)
            {
                if (Items.ContainsElementWithText(tab)) continue;
                NextButton.Click();
                attempts++;
            }
            GoToTab(tab);
        }
    }
}
