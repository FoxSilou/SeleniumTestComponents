using System;
using System.Collections.Generic;
using SeleniumTestComponents.BaseComponents.Base;

namespace SeleniumTestComponents.BaseComponents.Tree
{
    public abstract class Node<T> : BaseElement where T : Node<T>, new()
    {
        protected abstract BaseElement NameElement { get; }
        protected abstract BaseElement CollapseIcon { get; }
        protected abstract BaseCollection<T> SubNodes { get; }

        protected abstract bool IsExpanded();

        #region Values

        public string Name => NameElement.GetText();
        public bool Expanded => IsExpanded();

        #endregion Values

        public void Expand()
        {
            if (!Expanded) CollapseIcon.Click();
        }

        public Node<T> GetSubNode(string name)
        {
            return SubNodes.GetByText(name, elt => elt.GetChild<BaseComponent>(NameElement.Selector).GetText());
        }

        public void DoAction(Action<T> action, Stack<string> names)
        {
            if (names.Count == 0)
            {
                action(this as T);
                return;
            }
            Expand();
            Node<T> node = GetSubNode(names.Pop());
            node.DoAction(action, names);
        }
    }
}