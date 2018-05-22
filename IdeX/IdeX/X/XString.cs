// ----------------------------------------------------
// COPYRIGHT (C) <TooJooGoo> ALL RIGHTS RESERVED. SEE THE LIC
// ENSE FILE FOR THE FULL LICENSE GOVERNING THIS CODE. 
// ----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

public class XString
{
    public static bool Eq(string a, string b)
    {
        return string.Equals(a, b, StringComparison.InvariantCultureIgnoreCase);
    }
    public static bool Eq(string input, params string[] possibleStrings)
    {
        if(possibleStrings != null)
        {
            foreach(var possibleString in possibleStrings)
            {
                if(Eq(input,possibleString))
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool StartsWith(string str, string prefix)
    {
        return str.StartsWith(prefix, StringComparison.InvariantCultureIgnoreCase);
    }
    public static bool StartsWith(string input, params string[] prefixes)
    {
        if (prefixes != null)
        {
            foreach (var prefix in prefixes)
            {
                if (StartsWith(input, prefix))
                {
                    return true;
                }
            }
        }
        return false;
    }

    internal static void ParseAssoc(string input, out string left, out string right, string delim="=")
    {
        if(!string.IsNullOrEmpty(input))
        {
            var i = input.IndexOf(delim);
            if(i > 0)
            {
                left = input.Substring(0, i).Trim();
                right = input.Substring(i+ 1).Trim();
                return;
            }
        }
        left = "";
        right = "";
    }

    public static string[] SplitIntoLines(string input)
    {
        var parts = input.Split('\n').Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
        return parts;
    }

    public static IEnumerable<KeyValuePair<string, string>> ToDict(string input
    , char delim1 = '\n', char delim2 = '=')
    {
        var look = input.Split(delim1).Where(part => part.Trim() != "").ToLookup(
            x => x.Substring(0, x.IndexOf(delim2)).Trim(),
            x => x.Substring(x.IndexOf(delim2) + 1).Trim());
        var dict = look.ToDictionary(
            x => x.Key,
            x => x.ElementAt(0));
        return dict;
    }

    public static string WrapChars(string input, int charsPerLine = 40)
    {
        string output = "";
        string sub = input;
        while(sub.Length > charsPerLine)
        {
            output += sub.Substring(0, charsPerLine) + "\r\n";
            sub = sub.Substring(charsPerLine + 1);
        }
        output += sub;
        return output;
    }
    public static string WrapWords(string input, int charsPerLine = 40)
    {
        string output = "";
        var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var currentLineLength = 0;
        foreach(var word in words)
        {
            currentLineLength += word.Length;
            if(currentLineLength > charsPerLine)
            {
                output += " \r\n";
                currentLineLength = word.Length;
            }
            output += word + " ";
        }
        return output;
    }
}
