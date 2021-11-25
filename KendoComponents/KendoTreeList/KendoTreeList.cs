using OpenQA.Selenium;
using SeleniumTestComponents.BaseComponents.Base;
using SeleniumTestComponents.BaseComponents.Tree;

namespace SeleniumTestComponents.KendoComponents.KendoTreeList
{
    public class KendoTreeList : Tree<KendoTreeListNode>
    {
        protected override By DefaultSelector => null;
        protected override BaseCollection<KendoTreeListNode> Nodes => GetChildren<KendoTreeListNode>(By.CssSelector("tr[role='row']"));

        protected override string TextSelector(BaseElement webElement) => webElement.GetChild<BaseComponent>(By.CssSelector("td.region")).GetText();
    }
}