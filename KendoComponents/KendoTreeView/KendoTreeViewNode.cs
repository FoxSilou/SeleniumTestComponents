namespace SeleniumTestComponents.KendoComponents.KendoTreeView
{
    using SeleniumTestComponents.BaseComponents;
    using SeleniumTestComponents.BaseComponents.Base;
    using SeleniumTestComponents.StandardComponents;
    using OpenQA.Selenium;

    public class KendoTreeViewNode : Node<KendoTreeViewNode>
    {
        protected override By DefaultSelector => null;
        protected override BaseElement NameElement => GetChild<Component>(By.ClassName("k-in"));
        protected override BaseElement CollapseIcon => GetChild<Component>(By.ClassName("k-icon"));
        protected override BaseCheckBox CheckBox => GetChild<CheckBox>(By.ClassName("k-checkbox-wrapper"));
        protected override TestCollection<KendoTreeViewNode> SubNodes => Group.GetChildren<KendoTreeViewNode>(By.ClassName("k-item"));

        protected BaseElement Group => GetChild<Component>(By.ClassName("k-group"));

        protected override bool IsExpanded() => CollapseIcon.WebElement.GetAttribute("class").Contains("k-i-collapse");
    }
}
