using System;
using System.Collections.Generic;
using System.Text;

namespace AAD
{
    public class TreeNode<T>
    {
        public T Value { get; }
        public TreeNode<T>? Parent { get; private set; }
        public List<TreeNode<T>> Children { get; }
        public int Level { get; }

        public TreeNode(T value, TreeNode<T>? parent = null)
        {
            Value = value;
            Parent = parent;
            Level = Parent == null ? 0 : Parent.Level + 1;
            Children = new List<TreeNode<T>>();
        }

        public bool IsRoot => Parent == null;

        public TreeNode<T> Add(T childValue)
        {
            var childNode = new TreeNode<T>(childValue, this);
            Children.Add(childNode);
            return childNode;
        }

        public int Count()
        {
            int count = 1;
            foreach (var child in Children)
            {
                count += child.Count();
            }
            return count;
        }

        public int Height()
        {
            if (IsLeaf)
                return Level + 1;

            int maxHeight = 0;
            foreach (var child in Children)
            {
                int height = child.Height();
                if (height > maxHeight)
                    maxHeight = height;
            }
            return maxHeight;
        }

        public bool IsLeaf => Children.Count == 0;

        public void TraversePreOrder(Action<TreeNode<T>> action)
        {
            action(this);
            foreach (var child in Children)
            {
                child.TraversePreOrder(action);
            }
        }

        public void TraversePostOrder(Action<TreeNode<T>> action)
        {
            foreach (var child in Children)
            {
                child.TraversePostOrder(action);
            }
            action(this);
        }

        public void TraverseLevelOrder(Action<TreeNode<T>> action)
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(this);

            while (queue.Count > 0)
            {
                var currentLevelNodes = new List<TreeNode<T>>(queue);
                queue.Clear();

                foreach (var node in currentLevelNodes)
                {
                    action(node);
                    foreach (var child in node.Children)
                    {
                        queue.Enqueue(child);
                    }
                }
            }
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            TraverseLevelOrder(node =>
            {
                sb.AppendLine($"{new string(' ', node.Level * 2)}{node.Value}");
            });
            return sb.ToString().TrimEnd();
        }
    }
}
