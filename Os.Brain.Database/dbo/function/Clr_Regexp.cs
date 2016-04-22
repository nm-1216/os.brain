using System;
using System.Collections;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

public partial class regexp
{
    /// <summary>
    /// 指示所指定的正则表达式在指定的输入字符串中是否找到了匹配项
    /// </summary>
    /// <param name="input">要搜索匹配项的字符串</param>
    /// <param name="pattern">要匹配的正则表达式模式</param>
    /// <param name="options">枚举值的一个按位组合，这些枚举值提供匹配选项</param>
    /// <returns>如果正则表达式找到匹配项，则为 true；否则，为 false</returns>
    [Microsoft.SqlServer.Server.SqlFunction(Name = "clr_regexp_like")]
    public static SqlBoolean regexp_like(SqlString input, SqlString pattern, SqlInt32 options)
    {
        if (input.IsNull || pattern.IsNull)
            return new SqlBoolean(false);

        return new SqlBoolean(System.Text.RegularExpressions.Regex.IsMatch(input.Value, pattern.Value, (RegexOptions)options.Value));
    }

    /// <summary>
    /// 使用指定的匹配选项在输入字符串中搜索指定的正则表达式的第一个匹配项所在位置
    /// </summary>
    /// <param name="input">要搜索匹配项的字符串</param>
    /// <param name="pattern">要匹配的正则表达式模式</param>
    /// <param name="options">枚举值的一个按位组合，这些枚举值提供匹配选项</param>
    /// <returns>一个对象所在位置</returns>
    [Microsoft.SqlServer.Server.SqlFunction(Name = "clr_regexp_instr")]
    public static SqlInt32 regexp_instr(SqlString input, SqlString pattern, SqlInt32 options)
    {
        if (input.IsNull || pattern.IsNull)
            return new SqlInt32(-1);

        System.Text.RegularExpressions.Match _match = System.Text.RegularExpressions.Regex.Match(input.Value, pattern.Value, (RegexOptions)options.Value);
        if (_match.Success)
            return new SqlInt32(_match.Captures[0].Index);

        return new SqlInt32(-1);
    }

    /// <summary>
    /// 使用指定的匹配选项在输入字符串中搜索指定的正则表达式的第一个匹配项的值
    /// </summary>
    /// <param name="input">要搜索匹配项的字符串</param>
    /// <param name="pattern">要匹配的正则表达式模式</param>
    /// <param name="options">枚举值的一个按位组合，这些枚举值提供匹配选项</param>
    /// <returns>一个对象的值</returns>
    [Microsoft.SqlServer.Server.SqlFunction(Name = "clr_regexp_substr")]
    public static SqlString regexp_substr(SqlString input, SqlString pattern, SqlInt32 options)
    {
        if (input.IsNull || pattern.IsNull)
            return SqlString.Null;

        System.Text.RegularExpressions.Match _match = System.Text.RegularExpressions.Regex.Match(input.Value, pattern.Value, (RegexOptions)options.Value);
        if (_match.Success)
            return _match.Captures[0].Value;

        return SqlString.Null;
    }

    /// <summary>
    /// 在指定的输入字符串内，使用指定的替换字符串替换与指定正则表达式匹配的所有字符串。 指定的选项将修改匹配操作
    /// </summary>
    /// <param name="input">要搜索匹配项的字符串</param>
    /// <param name="pattern">要匹配的正则表达式模式</param>
    /// <param name="replacement">替换字符串</param>
    /// <param name="options">枚举值的一个按位组合，这些枚举值提供匹配选项</param>
    /// <returns>一个与输入字符串基本相同的新字符串，唯一的差别在于，其中的每个匹配字符串已被替换字符串代替</returns>
    [Microsoft.SqlServer.Server.SqlFunction(Name = "clr_regexp_replace")]
    public static SqlString regexp_replace(SqlString input, SqlString pattern, SqlString replacement, SqlInt32 options)
    {
        if (input.IsNull || pattern.IsNull || replacement.IsNull)
            return input;

        return new SqlString(System.Text.RegularExpressions.Regex.Replace(input.Value, pattern.Value, replacement.Value, (RegexOptions)options.Value));
    }

    /// <summary>
    /// 在由指定的正则表达式模式定义的位置拆分输入字符串。 指定的选项将修改匹配操作
    /// </summary>
    /// <param name="input">要拆分的字符串</param>
    /// <param name="pattern">要匹配的正则表达式模式</param>
    /// <param name="options">枚举值的一个按位组合，这些枚举值提供匹配选项</param>
    /// <returns>字符串数组</returns>
    [Microsoft.SqlServer.Server.SqlFunction(Name = "clr_regexp_split", FillRowMethodName = "SplitFillRow", TableDefinition = "item nvarchar(256)")]
    public static IEnumerable regexp_split(SqlString input, SqlString pattern, SqlInt32 options)
    {
        string[] _array;
        if (input.IsNull)
            _array = new string[] { null };
        else if (pattern.IsNull)
            _array = new string[] { input.Value };
        else
            _array = System.Text.RegularExpressions.Regex.Split(input.Value, pattern.Value, (RegexOptions)options.Value);

        return _array;
    }

    private static void SplitFillRow(Object obj, ref SqlString item)
    {
        if (obj != null)
            item = (string)obj;
    }
}


/*
[Test ]
public void RegexOptionsTest()
{
    Assert .AreEqual((int )RegexOptions .None,0);
    Assert .AreEqual((int )RegexOptions .IgnoreCase,1);
    Assert .AreEqual((int )RegexOptions .Multiline,2);
    Assert .AreEqual((int )RegexOptions .ExplicitCapture,4);
    Assert .AreEqual((int )RegexOptions .Compiled,8);
    Assert .AreEqual((int )RegexOptions .Singleline,16);
    Assert .AreEqual((int )RegexOptions .IgnorePatternWhitespace,32);
    Assert .AreEqual((int )RegexOptions .RightToLeft,64);
    Assert .AreEqual((int )RegexOptions .ECMAScript, 256);
    Assert .AreEqual((int )RegexOptions .CultureInvariant,512);
    Assert .AreEqual((int )(RegexOptions .IgnoreCase | RegexOptions .Multiline), 3);
}
 */
