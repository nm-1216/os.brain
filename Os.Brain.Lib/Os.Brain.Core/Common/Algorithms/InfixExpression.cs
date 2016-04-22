//-----------------------------------------------------------------------
// <copyright file="InfixExpression.cs" company="Os.Brain">Copyright (c) Os.Brain. All rights reserved.</copyright>
// <author>Craze</author>
// <datetime>2013/12/21</datetime>
// <discription>InfixExpression 中缀表达式</discription>
//-----------------------------------------------------------------------

namespace Os.Brain.Common
{
    ////前：prefix expression
    ////中：infix expression
    ////后：suffix expression

    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Algorithms 算法集
    /// </summary>
    public partial class Algorithms
    {
        #region 中缀表达式转后缀表达式 二叉树方式
        /// <summary>
        /// express  中缀表达式转后缀表达式 二叉树方式
        /// </summary>
        public class express
        {
            /// <summary>
            /// ops 运算符栈
            /// </summary>
            private Stack<char> ops;

            /// <summary>
            /// ovs 操作数栈
            /// </summary>
            private Stack<BinaryTree.Node<string>> ovs;

            /// <summary>
            /// strops 操作符
            /// </summary>
            private string strops = "+-*/()#";

            /// <summary>
            ///  Gets the Ovs of the express.
            /// </summary>
            /// <value>The Ovs of the express.</value>
            public Stack<BinaryTree.Node<string>> Ovs
            {
                get { return this.ovs; }
            }

            /// <summary>
            /// Scanner 转换
            /// </summary>
            /// <param name="str">str 中缀表达式</param>
            public void Scanner(string str)
            {
                this.Init();

                string temp = str;
                string data = string.Empty;

                for (int i = 0; i < str.Length; i++)
                {
                    if (this.strops.IndexOf(temp[i]) >= 0)
                    {
                        if (!string.IsNullOrEmpty(data))
                        {
                            this.ovs.Push(new BinaryTree.Node<string>(data));
                        }

                        data = string.Empty;

                        int n = this.osp(temp[i]);

                        while (n < this.isp(this.ops.Peek()))
                        {
                            BinaryTree.Node<string> node1 = this.ovs.Pop();
                            BinaryTree.Node<string> node2 = this.ovs.Pop();
                            this.ovs.Push(new BinaryTree.Node<string>(this.ops.Peek().ToString(), node2, node1));
                            this.ops.Pop();
                        }

                        if (n > this.isp(this.ops.Peek()))
                        {
                            this.ops.Push(temp[i]);
                        }
                        else if (n == this.isp(this.ops.Peek()))
                        {
                            this.ops.Pop();
                        }
                    }
                    else
                    {
                        data += temp[i].ToString();
                    }
                }
            }

            /// <summary>
            /// isp 获取操作符优先级(入栈)
            /// </summary>
            /// <param name="x">x 操作符</param>
            /// <returns>返回 操作符优先级</returns>
            private int isp(char x)
            {
                switch (x)
                {
                    case '#': return 0;
                    case '(': return 1;
                    case '*':
                    case '/':
                    case '%': return 5;
                    case '+':
                    case '-': return 3;
                }

                return -1;
            }

            /// <summary>
            /// osp 获取操作符优先级(出栈)
            /// </summary>
            /// <param name="x">x 操作符</param>
            /// <returns>返回 操作符优先级</returns>
            private int osp(char x)
            {
                switch (x)
                {
                    case '#': return 0;
                    case '(': return 6;
                    case '*':
                    case '/':
                    case '%': return 4;
                    case '+':
                    case '-': return 2;
                    case ')': return 1;
                }

                return -1;
            }

            /// <summary>
            /// Init 初始化
            /// </summary>
            private void Init()
            {
                this.ops = new Stack<char>();
                this.ovs = new Stack<BinaryTree.Node<string>>();
                ////#优先级最低
                this.ops.Push('#');
            }
        }
        #endregion

        #region 中缀表达式转后缀表达式 传统方式
        /// <summary>
        /// ZZ_HZ 中缀表达式转后缀表达式 传统方式
        /// </summary>
        public class ZZ_HZ
        {
            /// <summary>
            /// ops 运算符栈
            /// </summary>
            private Stack<char> ops;

            /// <summary>
            /// ovs 操作数栈
            /// </summary>
            private Stack<string> ovs;

            /// <summary>
            /// strops 操作符
            /// </summary>
            private string strops = "+-*/()#";

            /// <summary>
            /// Scanner 转换
            /// </summary>
            /// <param name="str">str 中缀表达式</param>
            /// <returns>返回 后缀表达式</returns>
            public string Scanner(string str)
            {
                this.Init();

                string temp = str;
                string data = string.Empty;

                for (int i = 0; i < str.Length; i++)
                {
                    if (this.strops.IndexOf(temp[i]) >= 0)
                    {
                        if (!string.IsNullOrEmpty(data))
                        {
                            this.ovs.Push(data);
                        }

                        data = string.Empty;

                        int n = this.osp(temp[i]);

                        while (n < this.isp(this.ops.Peek()))
                        {
                            this.ovs.Push(this.ops.Peek().ToString());
                            this.ops.Pop();
                        }

                        if (n > this.isp(this.ops.Peek()))
                        {
                            this.ops.Push(temp[i]);
                        }
                        else if (n == this.isp(this.ops.Peek()))
                        {
                            this.ops.Pop();
                        }
                    }
                    else
                    {
                        data += temp[i].ToString();
                    }

                    temp = string.Empty;
                    while (this.ovs.Count > 0)
                    {
                        temp = this.ovs.Peek() + temp;
                        this.ovs.Pop();
                    }
                }

                return temp;
            }

            /// <summary>
            /// isp 获取操作符优先级(入栈)
            /// </summary>
            /// <param name="x">x 操作符</param>
            /// <returns>返回 操作符优先级</returns>
            private int isp(char x)
            {
                switch (x)
                {
                    case '#': return 0;
                    case '(': return 1;
                    case '*':
                    case '/':
                    case '%': return 5;
                    case '+':
                    case '-': return 3;
                }

                return -1;
            }

            /// <summary>
            /// osp 获取操作符优先级(出栈)
            /// </summary>
            /// <param name="x">x 操作符</param>
            /// <returns>返回 操作符优先级</returns>
            private int osp(char x)
            {
                switch (x)
                {
                    case '#': return 0;
                    case '(': return 6;
                    case '*':
                    case '/':
                    case '%': return 4;
                    case '+':
                    case '-': return 2;
                    case ')': return 1;
                }

                return -1;
            }

            /// <summary>
            /// Init 初始化
            /// </summary>
            private void Init()
            {
                this.ops = new Stack<char>();
                this.ovs = new Stack<string>();
                ////#优先级最低
                this.ops.Push('#');
            }
        }
        #endregion

        #region 中缀表达式转后缀表达式 传统方式
        /// <summary>
        /// ZZ_QZ 中缀表达式转后缀表达式 传统方式
        /// </summary>
        public class ZZ_QZ
        {
            /// <summary>
            /// ops 运算符栈
            /// </summary>
            private Stack<char> ops;

            /// <summary>
            /// ovs 操作数栈
            /// </summary>
            private Stack<string> ovs;

            /// <summary>
            /// strops 运算符
            /// </summary>
            private string strops = "+-*/()#";

            /// <summary>
            /// Scanner 转换
            /// </summary>
            /// <param name="str">str 中缀表达式</param>
            /// <returns>返回 后缀表达式</returns>
            public string Scanner(string str)
            {
                this.ops = new Stack<char>();
                this.ovs = new Stack<string>();
                ////优先级最低
                this.ops.Push('#');

                string temp = str;
                string data = string.Empty;

                for (int i = str.Length - 1; i >= 0; i--)
                {
                    if (this.strops.IndexOf(temp[i]) >= 0)
                    {
                        if (!string.IsNullOrEmpty(data))
                        {
                            this.ovs.Push(data);
                        }

                        data = string.Empty;

                        int n = this.osp(temp[i]);

                        while (n < this.isp(this.ops.Peek()))
                        {
                            this.ovs.Push(this.ops.Peek().ToString());
                            this.ops.Pop();
                        }

                        if (n > this.isp(this.ops.Peek()))
                        {
                            this.ops.Push(temp[i]);
                        }
                        else if (n == this.isp(this.ops.Peek()))
                        {
                            this.ops.Pop();
                        }
                    }
                    else
                    {
                        data += temp[i].ToString();
                    }
                }

                temp = string.Empty;
                while (this.ovs.Count != 0)
                {
                    temp += this.ovs.Peek();
                    this.ovs.Pop();
                }

                return temp;
            }

            /// <summary>
            /// isp 获取操作符优先级(入栈)
            /// </summary>
            /// <param name="x">x 操作符</param>
            /// <returns>返回 操作符优先级</returns>
            private int isp(char x)
            {
                switch (x)
                {
                    case '#': return 0;
                    case ')': return 1;
                    case '*':
                    case '/':
                    case '%': return 5;
                    case '+':
                    case '-': return 3;
                }

                return -1;
            }

            /// <summary>
            /// osp 获取操作符优先级(出栈)
            /// </summary>
            /// <param name="x">x 操作符</param>
            /// <returns>返回 操作符优先级</returns>
            private int osp(char x)
            {
                switch (x)
                {
                    case '#': return 0;
                    case '(': return 1;
                    case '*':
                    case '/':
                    case '%': return 4;
                    case '+':
                    case '-': return 2;
                    case ')': return 6;
                }

                return -1;
            }
        }
        #endregion
    }
}
