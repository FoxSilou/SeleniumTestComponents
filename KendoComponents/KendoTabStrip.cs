namespace SeleniumTestComponents.KendoComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoTabStrip : BaseTabMenu
    {
        protected override By DefaultSelector => null;
        protected BaseComponent ItemsContainer => GetChild<BaseComponent>(By.ClassName("k-tabstrip-items"));
        protected override BaseCollection<BaseComponent> Items => ItemsContainer.GetChildren<BaseComponent>(By.ClassName("k-item"));
        protected BaseComponent PreviousButton => GetChild<BaseComponent>(By.ClassName("k-tabstrip-prev"));
        protected BaseComponent NextButton => GetChild<BaseComponent>(By.ClassName("k-tabstrip-next"));

        public void Navigate(string tab)
        {
            int attempts = 0;
            while (attempts < 20)
            {
                if (Items.ContainsElementWithText(tab)) break;
                NextButton.Click();
                attempts++;
            }
            GoToTab(tab);
        }
    }
}