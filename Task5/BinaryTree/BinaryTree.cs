using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTree
{
    public class BinaryTree<T> : IComparable
        where T : IComparable
    {

        public T Data { get; set; }
        public BinaryTree<T> Left { get; set;  }
        public BinaryTree<T> Right { get; set; }
        public BinaryTree<T> Parent { get; set; }

        public BinaryTree()
        {

        }

        public BinaryTree(T data, BinaryTree<T> parent = null)
        {
            Data = data;
            Parent = parent;
        }

        public void Add(T data)
        {
            if(data.CompareTo(Data) < 0)
            {
                if(Left == null)
                {
                    Left = new BinaryTree<T>(data);
                }
                else
                {
                    Left.Add(data);
                }
            }
            else
            {
                if(Right == null)
                {
                    Right = new BinaryTree<T>(data);
                }
                else
                {
                    Right.Add(data);
                }
            }
        }

        private BinaryTree<T> Search(BinaryTree<T> tree, T data)
        {
            if (tree == null) return null;
            switch (data.CompareTo(tree.Data))
            {
                case 1: return Search(tree.Right, data);
                case -1: return Search(tree.Left, data);
                case 0: return tree;
                default: return null;
            }
        }

        public BinaryTree<T> Search(T data)
        {
            return Search(this, data);
        }

        public bool Remove(T data)
        {
            BinaryTree<T> tree = Search(data);
            if (tree == null)
            {
                return false;
            }
            BinaryTree<T> curTree;

            if (tree == this)
            {
                if (tree.Right != null)
                {
                    curTree = tree.Right;
                }
                else curTree = tree.Left;

                while (curTree.Left != null)
                {
                    curTree = curTree.Left;
                }
                T temp = curTree.Data;
                this.Remove(temp);
                tree.Data = temp;

                return true;
            }

            if (tree.Left == null && tree.Right == null && tree.Parent != null)
            {
                if (tree == tree.Parent.Left)
                    tree.Parent.Left = null;
                else
                {
                    tree.Parent.Right = null;
                }
                return true;
            }
            
            
            if (tree.Left != null && tree.Right == null)
            {
                //Меняем родителя
                tree.Left.Parent = tree.Parent;
                if (tree == tree.Parent.Left)
                {
                    tree.Parent.Left = tree.Left;
                }
                else if (tree == tree.Parent.Right)
                {
                    tree.Parent.Right = tree.Left;
                }
                return true;
            }

            //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            if (tree.Left == null && tree.Right != null)
            {
                //Меняем родителя
                tree.Right.Parent = tree.Parent;
                if (tree == tree.Parent.Left)
                {
                    tree.Parent.Left = tree.Right;
                }
                else if (tree == tree.Parent.Right)
                {
                    tree.Parent.Right = tree.Right;
                }
                return true;
            }

            //Удаляем узел, имеющий поддеревья с обеих сторон
            if (tree.Right != null && tree.Left != null)
            {
                curTree = tree.Right;

                while (curTree.Left != null)
                {
                    curTree = curTree.Left;
                }

                //Если самый левый элемент является первым потомком
                if (curTree.Parent == tree)
                {
                    curTree.Left = tree.Left;
                    tree.Left.Parent = curTree;
                    curTree.Parent = tree.Parent;
                    if (tree == tree.Parent.Left)
                    {
                        tree.Parent.Left = curTree;
                    }
                    else if (tree == tree.Parent.Right)
                    {
                        tree.Parent.Right = curTree;
                    }
                    return true;
                }
                //Если самый левый элемент НЕ является первым потомком
                else
                {
                    if (curTree.Right != null)
                    {
                        curTree.Right.Parent = curTree.Parent;
                    }
                    curTree.Parent.Left = curTree.Right;
                    curTree.Right = tree.Right;
                    curTree.Left = tree.Left;
                    tree.Left.Parent = curTree;
                    tree.Right.Parent = curTree;
                    curTree.Parent = tree.Parent;
                    if (tree == tree.Parent.Left)
                    {
                        tree.Parent.Left = curTree;
                    }
                    else if (tree == tree.Parent.Right)
                    {
                        tree.Parent.Right = curTree;
                    }

                    return true;
                }
            }
            return false;
        }

        public int CompareTo(object obj)
        {
            if (obj is BinaryTree<T>)
            {
                return ((BinaryTree<T>)obj).Data.CompareTo(Data);
            }
            else
            {
                throw new InvalidCastException("Unable to cast types.");
            }
        }

        public List<T> PreOrderTraversal()
        {
            List<T> values = new List<T>();
            PreOrderTraversal(this, values);
            return values;
        }

        private void PreOrderTraversal(BinaryTree<T> node, List<T> values)
        {
            if (node != null)
            {
                values.Add(node.Data);
                PreOrderTraversal(node.Left, values);
                PreOrderTraversal(node.Right, values);
            }
        }
    }
}
