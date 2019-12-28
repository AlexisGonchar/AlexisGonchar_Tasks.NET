﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BinaryTree
{
    [Serializable]
    public class BinaryTree<T> : IComparable
        where T : IComparable
    {
        public T Data { get; set; }
        public BinaryTree<T> Left { get; set;  }
        public BinaryTree<T> Right { get; set; }
        
        private BinaryTree<T> parent;

        public BinaryTree()
        {

        }

        public BinaryTree(T data, BinaryTree<T> parent = null)
        {
            Data = data;
            this.parent = parent;
        }

        public void Add(T data)
        {
            if(Data == null)
            {
                Data = data;
            }else
            {
                if (data.CompareTo(Data) < 0)
                {
                    if (Left == null)
                    {
                        Left = new BinaryTree<T>(data, this);
                    }
                    else
                    {
                        Left.Add(data);
                    }
                }
                else
                {
                    if (Right == null)
                    {
                        Right = new BinaryTree<T>(data, this);
                    }
                    else
                    {
                        Right.Add(data);
                    }
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

            if (tree.Left == null && tree.Right == null && tree.parent != null)
            {
                if (tree == tree.parent.Left)
                    tree.parent.Left = null;
                else
                {
                    tree.parent.Right = null;
                }
                return true;
            }
            
            
            if (tree.Left != null && tree.Right == null)
            {
                //Меняем родителя
                tree.Left.parent = tree.parent;
                if (tree == tree.parent.Left)
                {
                    tree.parent.Left = tree.Left;
                }
                else if (tree == tree.parent.Right)
                {
                    tree.parent.Right = tree.Left;
                }
                return true;
            }

            //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            if (tree.Left == null && tree.Right != null)
            {
                //Меняем родителя
                tree.Right.parent = tree.parent;
                if (tree == tree.parent.Left)
                {
                    tree.parent.Left = tree.Right;
                }
                else if (tree == tree.parent.Right)
                {
                    tree.parent.Right = tree.Right;
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
                if (curTree.parent == tree)
                {
                    curTree.Left = tree.Left;
                    tree.Left.parent = curTree;
                    curTree.parent = tree.parent;
                    if (tree == tree.parent.Left)
                    {
                        tree.parent.Left = curTree;
                    }
                    else if (tree == tree.parent.Right)
                    {
                        tree.parent.Right = curTree;
                    }
                    return true;
                }
                //Если самый левый элемент НЕ является первым потомком
                else
                {
                    if (curTree.Right != null)
                    {
                        curTree.Right.parent = curTree.parent;
                    }
                    curTree.parent.Left = curTree.Right;
                    curTree.Right = tree.Right;
                    curTree.Left = tree.Left;
                    tree.Left.parent = curTree;
                    tree.Right.parent = curTree;
                    curTree.parent = tree.parent;
                    if (tree == tree.parent.Left)
                    {
                        tree.parent.Left = curTree;
                    }
                    else if (tree == tree.parent.Right)
                    {
                        tree.parent.Right = curTree;
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

        public void Serialize(string path)
        {
            XmlSerializer stream = new XmlSerializer(typeof(BinaryTree<T>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                stream.Serialize(fs, this);
            }
        }

        public void Deserialize(string path)
        {
            XmlSerializer stream = new XmlSerializer(typeof(BinaryTree<T>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                BinaryTree<T> tree = (BinaryTree<T>)stream.Deserialize(fs);
                Data = tree.Data;
                Left = tree.Left;
                Right = tree.Right;
            }
        }

        public void BalanceTree()
        {
            List<BinaryTree<T>> listOfNodes = new List<BinaryTree<T>>();
            
            FillList(this, listOfNodes);
            
            int count = listOfNodes.Count;
            
            BalanceTree(0, count - 1, listOfNodes);

            Data = Right.Data;
            Left = Right.Left;
            Right = Right.Right;
        }

        private void BalanceTree(int minSublist, int maxSublist, List<BinaryTree<T>> list)
        {
            if (minSublist <= maxSublist)
            {
                int middleNode = (int)Math.Ceiling(((double)minSublist + maxSublist) / 2);
                
                Add(list[middleNode].Data);
                
                BalanceTree(minSublist, middleNode - 1, list);
                BalanceTree(middleNode + 1, maxSublist, list);
            }
        }

        private void FillList(BinaryTree<T> node, List<BinaryTree<T>> list)
        {
            if (node != null)
            {
                FillList(node.Left, list);
                
                list.Add(node);
                
                FillList(node.Right, list);
            }
        }
    }
}
