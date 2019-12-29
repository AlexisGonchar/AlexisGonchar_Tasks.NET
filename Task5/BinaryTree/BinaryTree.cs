using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BinaryTree
{
    /// <summary>
    /// Сlass describing a binary tree node.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public class BinaryTree<T> : IComparable
        where T : IComparable
    {
        /// <summary>
        /// The node data.
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// The left node.
        /// </summary>
        public BinaryTree<T> Left { get; set;  }
        /// <summary>
        /// The right node.
        /// </summary>
        public BinaryTree<T> Right { get; set; }
        
        private BinaryTree<T> parent;

        /// <summary>
        /// Initializes a new instance of the BinaryTree class.
        /// </summary>
        public BinaryTree()
        {

        }

        /// <summary>
        /// nitializes a new instance of the BinaryTree class.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="parent"></param>
        public BinaryTree(T data, BinaryTree<T> parent = null)
        {
            Data = data;
            this.parent = parent;
        }

        /// <summary>
        /// Adds the data.
        /// </summary>
        /// <param name="data"></param>
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

        /// <summary>
        /// Search the node.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public BinaryTree<T> Search(T data)
        {
            return Search(this, data);
        }

        /// <summary>
        /// Remove the data.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool Remove(T data)
        {
            //Check if this node exists
            BinaryTree<T> tree = Search(data);
            if (tree == null)
            {
                //If the node does not exist, return false
                return false;
            }
            BinaryTree<T> curTree;

            //If remove the root
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

            //Sides removal
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
            
            //Removal of a node having a left subtree, but not having a right subtree
            if (tree.Left != null && tree.Right == null)
            {
                //Change parent
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

            //Removal of a node having a right subtree, but not having a left subtree
            if (tree.Left == null && tree.Right != null)
            {
                //Change parent
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

            //Removal of a node having subtrees on both sides
            if (tree.Right != null && tree.Left != null)
            {
                curTree = tree.Right;

                while (curTree.Left != null)
                {
                    curTree = curTree.Left;
                }

                //If the leftmost element is the first child
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
                //If the leftmost element is not the first child
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

        /// <summary>
        /// Nodes Object Comparison.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Serialization of binary tree in XML.
        /// </summary>
        /// <param name="path"></param>
        public void Serialize(string path)
        {
            XmlSerializer stream = new XmlSerializer(typeof(BinaryTree<T>));
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                stream.Serialize(fs, this);
            }
        }

        /// <summary>
        /// XML binary tree deserialization.
        /// </summary>
        /// <param name="path"></param>
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

        /// <summary>
        /// Binary tree balancing.
        /// </summary>
        public void BalanceTree()
        {
            List<BinaryTree<T>> listOfNodes = new List<BinaryTree<T>>();
            
            FillList(this, listOfNodes);

            RemoveChildNodes(listOfNodes);

            int count = listOfNodes.Count;

            Data = default(T);

            BalanceTree(0, count - 1, listOfNodes);
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

        private void RemoveChildNodes(List<BinaryTree<T>> listOfNodes)
        {
            foreach (BinaryTree<T> node in listOfNodes)
            {
                node.Left = null;
                node.Right = null;
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
