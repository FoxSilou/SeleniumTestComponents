using OpenQA.Selenium;
using SeleniumTestComponents.BaseComponents.Base;
using SeleniumTestComponents.BaseComponents.Tree;

namespace SeleniumTestComponents.KendoComponents.KendoTreeList
{
    public class KendoTreeListNode : Node<KendoTreeListNode>
    {
        protected override By DefaultSelector => null;
        protected override BaseElement NameElement => GetChild<BaseComponent>(By.CssSelector("td.region"));
        protected override BaseElement CollapseIcon => this;

        protected override BaseCollection<KendoTreeListNode> SubNodes =>
            _parent.GetChildren<KendoTreeListNode>(By.CssSelector("tr[role='row']"));

        protected override bool IsExpanded() => WebElement.GetAttribute("aria-exanded").Contains("true");
    }
}