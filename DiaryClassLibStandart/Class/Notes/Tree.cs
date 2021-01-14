using System;
using System.Collections.Generic;
using System.Text;

namespace LibForPersonalTool.Class.Notes
{
    public class Tree<T>
    {
        public T Value;
        public Tree<T> Parent = null;
        public List<Tree<T>> Children;

        public Tree (T value)
        {
            this.Value = value;
            this.Children = new List<Tree<T>>();
        }

        public void AddChild(T childData)
        {
            var ch = new Tree<T>(childData);
            ch.Parent = this;
            Children.Add(ch);

        }

    }
}
