namespace SeleniumTestComponents.KendoComponents.KendoTreeView
{
    using BaseComponents;
    using BaseComponents.Base;
    using BaseComponents.Tree;
    using OpenQA.Selenium;

    public class KendoTreeViewNode : Node<KendoTreeViewNode>
    {
        protected override By DefaultSelector => null;
        protected override BaseElement NameElement => GetChild<BaseComponent>(By.ClassName("k-in"));
        protected override BaseElement CollapseIcon => GetChild<BaseComponent>(By.ClassName("k-icon"));
        protected BaseCheckBox CheckBox => GetChild<KendoCheckBox>(By.ClassName("k-checkbox-wrapper"));
        protected override BaseCollection<KendoTreeViewNode> SubNodes => Group.GetChildren<KendoTreeViewNode>(By.ClassName("k-item"));

        protected BaseElement Group => GetChild<BaseComponent>(By.ClassName("k-group"));

        protected override bool IsExpanded() => CollapseIcon.WebElement.GetAttribute("class").Contains("k-i-collapse");

        public bool Checked => WebElement.GetAttribute("aria-checked") == "true";

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