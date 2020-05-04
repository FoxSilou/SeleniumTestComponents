namespace SeleniumTestComponents.BaseComponents
{
    using SeleniumTestComponents.BaseComponents.Base;
    using OpenQA.Selenium;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public abstract class Tree<T> : BaseElement where T : Node<T>, new()
    {
        protected abstract TestCollection<T> Nodes { get; }
        protected abstract string TextSelector(IWebElement webElement);

        public void DoActionOnNode(Action<T> action, params string[] names)
        {
            Stack<string> nameStack = new Stack<string>(names.Reverse());
            Node<T> node = Nodes.GetByText(nameStack.Pop(), TextSelector);
            node.DoAction(action, nameStack);
        }
    }
}
