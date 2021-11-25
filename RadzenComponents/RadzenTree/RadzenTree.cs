using OpenQA.Selenium;
using SeleniumTestComponents.BaseComponents.Base;
using SeleniumTestComponents.BaseComponents.Tree;

namespace SeleniumTestComponents.RadzenComponents.RadzenTree
{
    public class RadzenTree : Tree<RadzenTreeNode>
    {
        protected override By DefaultSelector => By.ClassName("rz-tree");
        protected override BaseCollection<RadzenTreeNode> Nodes => Container.GetChildren<RadzenTreeNode>(By.ClassName("rz-treenode"));
        protected BaseElement Container => GetChild<BaseComponent>(By.ClassName("rz-tree-container"));

        protected override string TextSelector(BaseElement webElement) => webElement.GetChild<BaseComponent>(By.ClassName("label")).GetText();
    }
}