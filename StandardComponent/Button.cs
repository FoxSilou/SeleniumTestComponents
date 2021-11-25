using OpenQA.Selenium;
using SeleniumTestComponents.BaseComponents;

namespace SeleniumTestComponents.StandardComponent
{
    public class Button : BaseButton
    {
        protected override By DefaultSelector => null;
        public bool Disabled => IsNotInteractable();
    }
}