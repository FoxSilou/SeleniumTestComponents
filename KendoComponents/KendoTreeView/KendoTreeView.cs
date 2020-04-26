namespace SeleniumTestComponents.KendoComponents.KendoTreeView
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;

    public class KendoTreeView : Tree<KendoTreeViewNode>
    {
        protected override By DefaultSelector => null;
        protected override TestCollection<KendoTreeViewNode> Nodes => Group.GetChildren<KendoTreeViewNode>(By.ClassName("k-item"));
        protected BaseElement Group => GetChild<Component>(By.ClassName("k-group"));

        protected override string TextSelector(IWebElement webElement) => webElement.FindElement(By.ClassName("k-in")).Text;
    }
}
