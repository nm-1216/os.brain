//-----------------------------------------------------------------------
// <copyright file="BinaryTree.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>Algorithms BinaryTree 二叉树</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Algorithms 算法集
    /// </summary>
    public partial class Algorithms
    {
        /// <summary>
        /// BinaryTree 二叉树
        /// </summary>
        public class BinaryTree
        {
            /// <summary>
            /// PreorderTraversal 前序遍历
            /// </summary>
            /// <param name="root">root 二叉树根节点</param>
            /// <returns>返回 空</returns>
            public static string PreorderTraversal(Node<string> root)
            {
                return string.Empty;
            }

            /// <summary>
            /// InorderTraversal 中序遍历
            /// </summary>
            /// <param name="root">root 二叉树根节点</param>
            /// <returns>返回 空</returns>
            public static string InorderTraversal(Node<string> root)
            {
                return string.Empty;
            }

            /// <summary>
            /// PostorderTraversal 后续遍历
            /// </summary>
            /// <param name="root">root 二叉树根节点</param>
            /// <returns>换回 遍历后字符传</returns>
            public static string PostorderTraversal(Node<string> root)
            {
                string temp = string.Empty;
                if (root != null)
                {
                    temp += PostorderTraversal(root.LChild);
                    temp += PostorderTraversal(root.RChild);
                    temp += root.Data;
                }

                return temp;
            }

            /// <summary>
            /// Node 定义节点
            /// </summary>
            /// <typeparam name="T">T 类型</typeparam>
            public class Node<T>
            {
                /// <summary>
                /// data 数据集
                /// </summary>
                private T data;

                /// <summary>
                /// lChild 左节点
                /// </summary>
                private Node<T> leftChild;

                /// <summary>
                /// rChild 右节点
                /// </summary>
                private Node<T> rightChild;

                /// <summary>
                /// Initializes a new instance of the <see cref="Node{T}"/> class. 
                /// </summary>
                /// <param name="val">val 当前节点的值</param>
                /// <param name="lp">lp 左节点</param>
                /// <param name="rp">rp 又节点</param>
                public Node(T val, Node<T> lp, Node<T> rp)
                {
                    this.data = val;
                    this.leftChild = lp;
                    this.rightChild = rp;
                }

                /// <summary>
                /// Initializes a new instance of the <see cref="Node{T}"/> class. 
                /// </summary>
                /// <param name="lp">lp 左节点</param>
                /// <param name="rp">rp 又节点</param>
                public Node(Node<T> lp, Node<T> rp)
                {
                    this.data = default(T);
                    this.leftChild = lp;
                    this.rightChild = rp;
                }

                /// <summary>
                /// Initializes a new instance of the <see cref="Node{T}"/> class. 
                /// </summary>
                /// <param name="val">val 当前节点的值</param>
                public Node(T val)
                {
                    this.data = val;
                    this.leftChild = null;
                    this.rightChild = null;
                }

                /// <summary>
                /// Initializes a new instance of the <see cref="Node{T}"/> class. 
                /// </summary>
                public Node()
                {
                    this.data = default(T);
                    this.leftChild = null;
                    this.rightChild = null;
                }

                /// <summary>
                /// Gets or sets the Data of the Node.
                /// </summary>
                /// <value>The Data of the Node.</value> 
                public T Data
                {
                    get { return this.data; }

                    set { this.data = value; }
                }

                /// <summary>
                /// Gets or sets the LChild of the Node.
                /// </summary>
                /// <value>The LChild of the Node.</value> 
                public Node<T> LChild
                {
                    get { return this.leftChild; }

                    set { this.leftChild = value; }
                }

                /// <summary>
                /// Gets or sets the RChild of the Node.
                /// </summary>
                /// <value>The RChild of the Node.</value> 
                public Node<T> RChild
                {
                    get { return this.rightChild; }

                    set { this.rightChild = value; }
                }
            }
        }
    }
}