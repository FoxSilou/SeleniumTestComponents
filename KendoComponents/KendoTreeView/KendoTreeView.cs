namespace SeleniumTestComponents.KendoComponents.KendoTreeView
{
    using BaseComponents.Base;
    using OpenQA.Selenium;
    using BaseComponents.Tree;

    public class KendoTreeView : Tree<KendoTreeViewNode>
    {
        protected override By DefaultSelector => null;
        protected override BaseCollection<KendoTreeViewNode> Nodes => Group.GetChildren<KendoTreeViewNode>(By.ClassName("k-item"));
        protected BaseElement Group => GetChild<BaseComponent>(By.ClassName("k-group"));

        protected override string TextSelector(BaseElement webElement) => webElement.GetChild<BaseComponent>(By.ClassName("k-in")).GetText();
    }
}