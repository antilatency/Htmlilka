using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class HelperStringToHTML {

    static readonly Dictionary<char, string> AttributeTagContentReplacement = new Dictionary<char, string>() {
        {'<',"&lt;"},
        //{'>',"&gt;"},
        //{'&',"&amp;"},
        //{'"',"&quot;"},
    };
    static readonly char[] AttributeTagContentChars = AttributeTagContentReplacement.Keys.ToArray();

    public static string ReplaceInvalidTagContentSymbols(this string x) {
        return x.ReplaceInvalidHtmlSymbols(AttributeTagContentChars, AttributeTagContentReplacement);
    }

    static readonly Dictionary<char, string> AttributeValueReplacement = new Dictionary<char, string>() {
        //{'<',"&lt;"},
        //{'>',"&gt;"},
        //{'&',"&amp;"},
        {'"',"&quot;"},
    };
    static readonly char[] AttributeValueChars = AttributeValueReplacement.Keys.ToArray();

    public static string ReplaceInvalidAttributeValueSymbols(this string x) {
        return x.ReplaceInvalidHtmlSymbols(AttributeValueChars, AttributeValueReplacement);
    }


    private static string ReplaceInvalidHtmlSymbols(this string x, char[] keys, Dictionary<char, string> keyValuePairs) {
        int start = 0;
        int i = x.IndexOfAny(keys);
        if (i >= 0) {
            StringBuilder stringBuilder = new StringBuilder(2 * x.Length);

            while (i >= 0) {
                stringBuilder.Append(x, start, i - start);
                stringBuilder.Append(keyValuePairs[x[i]]);
                start = i + 1;
                i = x.IndexOfAny(keys, start);
            }
            stringBuilder.Append(x, start, x.Length - start);
            return stringBuilder.ToString();
        }
        return x;
    }
}