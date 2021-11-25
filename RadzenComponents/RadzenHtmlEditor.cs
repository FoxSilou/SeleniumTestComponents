namespace SeleniumTestComponents.RadzenComponents
{
    using BaseComponents;
    using BaseComponents.Base;
    using OpenQA.Selenium;

    public class RadzenHtmlEditor : BaseTextEditor
    {
        protected override By DefaultSelector => null;
        protected override BaseElement Input => GetChild<BaseComponent>(By.ClassName("rz-html-editor-content"));

        private BaseCollection<BaseComponent> Paragraphs => Input.GetChildren<BaseComponent>(By.TagName("p"));

        protected override string GetFormattedText()
        {
            var result = string.Empty;
            foreach (var paragraph in Paragraphs.WebElements)
            {
                result += ("<p>" + paragraph.GetText() + "</p>");
            }
            return result;
        }
    }
}