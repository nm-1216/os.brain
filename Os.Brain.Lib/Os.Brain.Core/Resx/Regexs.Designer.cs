﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:2.0.50727.3053
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Os.Brain.Common.Resx{
    using System;
    
    
    /// <summary>
    ///   强类型资源类，用于查找本地化字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "2.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Regexs {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Regexs() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Os.Brain.Core.resx.Regexs", typeof(Regexs).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   为使用此强类型资源类的所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 ^[a-z]+$ 的本地化字符串。
        /// </summary>
        internal static string ABC {
            get {
                return ResourceManager.GetString("ABC", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^\s*$ 的本地化字符串。
        /// </summary>
        internal static string Blank {
            get {
                return ResourceManager.GetString("Blank", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^#(([0-9a-f]{3})|([0-9a-f]{6}))$ 的本地化字符串。
        /// </summary>
        internal static string Color {
            get {
                return ResourceManager.GetString("Color", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;link [\s\S]*?/&gt;|&lt;style [\s\S]*?&lt;/style&gt; 的本地化字符串。
        /// </summary>
        internal static string Css {
            get {
                return ResourceManager.GetString("Css", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:(?:19|2\d)\d{2}-(?:0?[1-9]|1[0-2])-(?:0?[1-9]|1\d|2[0-8])|(?:19|2\d)\d{2}-(?:0?[13456789]|1[0-2])-(?:29|30)|(?:19|2\d)\d{2}-(?:0?[13578]|1[02])-31|(?:(?:19|2\d)(?:0[48]|[2468][048]|[13579][26])|(?:2[048])00)-0?2-29)$ 的本地化字符串。
        /// </summary>
        internal static string Date {
            get {
                return ResourceManager.GetString("Date", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:(?:(?:19|2\d)\d{2}-(?:0?[1-9]|1[0-2])-(?:0?[1-9]|1\d|2[0-8])|(?:19|2\d)\d{2}-(?:0?[13456789]|1[0-2])-(?:29|30)|(?:19|2\d)\d{2}-(?:0?[13578]|1[02])-31|(?:(?:19|2\d)(?:0[48]|[2468][048]|[13579][26])|(?:2[048])00)-0?2-29)\s(?:[01]?\d|2[0-3])(?::(?:[0-5]?\d)){2})$ 的本地化字符串。
        /// </summary>
        internal static string DateTime {
            get {
                return ResourceManager.GetString("DateTime", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^[\w-]+@[\w-]+\.(?:com|net|org|edu|mil|tv|biz|info)$ 的本地化字符串。
        /// </summary>
        internal static string Email {
            get {
                return ResourceManager.GetString("Email", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:[\w-]+@[\w-]+\.(?:com|net|org|edu|mil|tv|biz|info),)*[\w-]+@[\w-]+\.(?:com|net|org|edu|mil|tv|biz|info)$ 的本地化字符串。
        /// </summary>
        internal static string Emails {
            get {
                return ResourceManager.GetString("Emails", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:[1-9]\d*|0)(?:\.[0-9]+)?$ 的本地化字符串。
        /// </summary>
        internal static string Float {
            get {
                return ResourceManager.GetString("Float", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:\d{17}[\d|X]|\d{15})$ 的本地化字符串。
        /// </summary>
        internal static string Idcard {
            get {
                return ResourceManager.GetString("Idcard", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;iframe  [\s\S]*?/&gt; 的本地化字符串。
        /// </summary>
        internal static string Iframe {
            get {
                return ResourceManager.GetString("Iframe", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 \.(jpg|jpeg|png|bmp|gif)$ 的本地化字符串。
        /// </summary>
        internal static string Img {
            get {
                return ResourceManager.GetString("Img", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:0|(?:[\+-]?[1-9]\d*))$ 的本地化字符串。
        /// </summary>
        internal static string Int {
            get {
                return ResourceManager.GetString("Int", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:(?:2[0-4]\d|25[0-5]|1\d\d|[1-9]\d|\d)\.){3}(?:2[0-4]\d|25[0-5]|1\d\d|[1-9]\d|\d)$ 的本地化字符串。
        /// </summary>
        internal static string IP {
            get {
                return ResourceManager.GetString("IP", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^([\s]*,[\s]*[\d]+)+$ 的本地化字符串。
        /// </summary>
        internal static string List {
            get {
                return ResourceManager.GetString("List", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^[a-z]+[a-z0-9_]{3,}$ 的本地化字符串。
        /// </summary>
        internal static string Mark {
            get {
                return ResourceManager.GetString("Mark", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:0?(?:13\d|15[012356789]|18[689])\d{8})$ 的本地化字符串。
        /// </summary>
        internal static string Mobile {
            get {
                return ResourceManager.GetString("Mobile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:(?:(?:0?(?:13\d|15[012356789]|18[689])\d{8}),)*(?:0?(?:13\d|15[012356789]|18[689])\d{8}))$ 的本地化字符串。
        /// </summary>
        internal static string Mobiles {
            get {
                return ResourceManager.GetString("Mobiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:[\+-]?)(?:[1-9]\d{0,11}|0)(?:\.[0-9]{1,2})?$ 的本地化字符串。
        /// </summary>
        internal static string Money {
            get {
                return ResourceManager.GetString("Money", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^\d+$ 的本地化字符串。
        /// </summary>
        internal static string Number {
            get {
                return ResourceManager.GetString("Number", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:(?:(?:(?:0\d{2,3}-?)|(?:\(0\d{2,3}\)))?[1-9]\d{7}|(?:(?:0\d{3}-?)|(?:\(0\d{3}\)))?[1-9]\d{6}|[48]00\d{7})|(?:0?(?:13\d|15[012356789]|18[689])\d{8}))$ 的本地化字符串。
        /// </summary>
        internal static string Phone {
            get {
                return ResourceManager.GetString("Phone", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(((((0\d{2,3}-?)|(\(0\d{2,3}\)))?[1-9]\d{7}|((0\d{3}-?)|(\(0\d{3}\)))?[1-9]\d{6}|[48]00\d{7})|(0?(13\d|15[012356789]|18[689])\d{8})),)*((((0\d{2,3}-?)|(\(0\d{2,3}\)))?[1-9]\d{7}|((0\d{3}-?)|(\(0\d{3}\)))?[1-9]\d{6}|[48]00\d{7})|(0?(13\d|15[012356789]|18[689])\d{8}))$ 的本地化字符串。
        /// </summary>
        internal static string Phones {
            get {
                return ResourceManager.GetString("Phones", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;script[\s\S]+&lt;/script *&gt;|href *= *[\s\S]*script *:|on[\s\S]*=|_disibledevent=|&lt;iframe[\s\S]+&lt;/iframe *&gt;|&lt;frameset[\s\S]+&lt;/frameset *&gt; 的本地化字符串。
        /// </summary>
        internal static string Script {
            get {
                return ResourceManager.GetString("Script", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 &lt;\/?[^&gt;]+&gt; 的本地化字符串。
        /// </summary>
        internal static string Tags {
            get {
                return ResourceManager.GetString("Tags", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:(?:(?:0\d{2,3}-?)|(?:\(0\d{2,3}\)))?[1-9]\d{7}|(?:(?:0\d{3}-?)|(?:\(0\d{3}\)))?[1-9]\d{6}|[48]00\d{7})$ 的本地化字符串。
        /// </summary>
        internal static string Tel {
            get {
                return ResourceManager.GetString("Tel", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:(?:(?:(?:(?:0\d{2,3}-?)|(?:\(0\d{2,3}\)))?[1-9]\d{7}|(?:(?:0\d{3}-?)|(?:\(0\d{3}\)))?[1-9]\d{6}|[48]00\d{7}),)*(?:(?:(?:0\d{2,3}-?)|(?:\(0\d{2,3}\)))?[1-9]\d{7}|(?:(?:0\d{3}-?)|(?:\(0\d{3}\)))?[1-9]\d{6}|[48]00\d{7}))$ 的本地化字符串。
        /// </summary>
        internal static string Tels {
            get {
                return ResourceManager.GetString("Tels", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:(?:[01]?\d|2[0-3])(?::(?:[0-5]?\d)){2})$ 的本地化字符串。
        /// </summary>
        internal static string Time {
            get {
                return ResourceManager.GetString("Time", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^(?:http|https)\://(?:[a-zA-Z0-9\.\-]+(?:\:[a-zA-Z0-9\.&amp;%\$\-]+)*@)*(?:(?:25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9])\.(?:25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(?:25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[1-9]|0)\.(?:25[0-5]|2[0-4][0-9]|[0-1]{1}[0-9]{2}|[1-9]{1}[0-9]{1}|[0-9])|localhost|(?:[a-zA-Z0-9\-]+\.)*[a-zA-Z0-9\-]+\.(?:com|edu|gov|int|mil|net|org|biz|arpa|info|name|pro|aero|coop|museum|[a-zA-Z]{1,10}))(?:\:[0-9]+)*(?:/(?:$|[a-zA-Z0-9\.\,\?\&apos;\\\+ [字符串的其余部分被截断]&quot;; 的本地化字符串。
        /// </summary>
        internal static string Url {
            get {
                return ResourceManager.GetString("Url", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 ^[1-9]\d{5}$ 的本地化字符串。
        /// </summary>
        internal static string Zone {
            get {
                return ResourceManager.GetString("Zone", resourceCulture);
            }
        }
    }
}