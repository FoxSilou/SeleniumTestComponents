using OpenQA.Selenium;
using SeleniumTestComponents.BaseComponents.Base;
using SeleniumTestComponents.BaseComponents.Tree;

namespace SeleniumTestComponents.RadzenComponents.RadzenTree
{
    public class RadzenTreeNode : Node<RadzenTreeNode>
    {
        protected override By DefaultSelector => By.ClassName("rz-treenode");
        protected override BaseElement NameElement => GetChild<BaseComponent>(By.ClassName("label"));
        protected override BaseElement CollapseIcon => GetChild<BaseComponent>(By.ClassName("rz-tree-toggler"));
        protected BaseElement CheckBox => GetChild<BaseComponent>(By.ClassName("rz-chkbox-box"));
        protected override BaseCollection<RadzenTreeNode> SubNodes => Children.GetChildren<RadzenTreeNode>(By.ClassName("rz-treenode"));

        protected BaseElement Children => GetChild<BaseComponent>(By.ClassName("rz-treenode-children"));

        protected override bool IsExpanded() => CollapseIcon.WebElement.GetAttribute("class").Contains("rzi-caret-down");

        public bool Checked => CheckBox.WebElement.GetAttribute("class").Contains("rz-state-active");

        public void Check()
        {
            if (!Checked) CheckBox.Click();
        }

        public void UnCheck()
        {
            if (Checked) CheckBox.Click();
        }
    }
}