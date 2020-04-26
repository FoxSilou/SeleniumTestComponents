namespace SeleniumTestComponents.BaseComponents
{
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;
    using System.Collections.Generic;

    public abstract class Node<T> : BaseElement where T : Node<T>, new()
    {
        protected abstract BaseElement NameElement { get; }
        protected abstract BaseElement CollapseIcon { get; }
        protected abstract BaseCheckBox CheckBox { get; }
        protected abstract TestCollection<T> SubNodes { get; }
        protected abstract bool IsExpanded();

        #region Values
        public string Name => NameElement.GetText();
        public bool Expanded => IsExpanded();
        public bool Checked => CheckBox.Checked;
        #endregion Values

        public void Expand()
        {
            if (!Expanded) CollapseIcon.Click();
        }

        public Node<T> GetSubNode(string name)
        {
            return SubNodes.GetByText(name, elt => elt.FindElement(NameElement.Selector).Text);
        }

        public void Check(Stack<string> names)
        {
            if (names.Count == 0)
            {
                CheckBox.Check();
                return;
            }
            Node<T> node = GetSubNode(names.Pop());
            Expand();
            node.Check(names);
        }

        public void Uncheck(Stack<string> names)
        {
            if (names.Count == 0)
            {
                CheckBox.Uncheck();
                return;
            }
            Node<T> node = GetSubNode(names.Pop());
            Expand();
            node.Uncheck(names);
        }
    }
}
