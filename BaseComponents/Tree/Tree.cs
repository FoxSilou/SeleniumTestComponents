using System;
using System.Collections.Generic;
using System.Linq;
using SeleniumTestComponents.BaseComponents.Base;

namespace SeleniumTestComponents.BaseComponents.Tree
{
    public abstract class Tree<T> : BaseElement where T : Node<T>, new()
    {
        protected abstract BaseCollection<T> Nodes { get; }

        protected abstract string TextSelector(BaseElement webElement);

        public void DoActionOnNode(Action<T> action, params string[] names)
        {
            Stack<string> nameStack = new Stack<string>(names.Reverse());
            Node<T> node = Nodes.GetByText(nameStack.Pop(), TextSelector);
            node.DoAction(action, nameStack);
        }

        public void WaitUntilAnyNodes() => Nodes.WaitUntilAnyWithText();
    }
}