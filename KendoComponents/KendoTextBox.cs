﻿namespace SeleniumTestComponents.KendoComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoTextBox : BaseTextEditor
    {
        protected override By DefaultSelector => null;
        protected override BaseElement Input => this;

        protected override string GetFormattedText() => GetText();

        protected new string GetText() => Input.WebElement.GetAttribute("value");

        public void WaitUntilTextNonEmpty()
        {
            _longWait.Until(d => !string.IsNullOrEmpty(GetText()));
        }
    }
}