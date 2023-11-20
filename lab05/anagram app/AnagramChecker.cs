using System.Text.RegularExpressions;

namespace lab05.anagram_app;

public class AnagramChecker : IAnagramChecker
{
    private string FormatString(string str)
    {
        str = str.ToLower();
        Regex regex = new Regex(@"[^A-Za-z]");
        return regex.Replace(str, "");
    }
    
    public bool IsAnagram(string? word1, string? word2)
    {
        if (word1 == null || word2 == null)
            throw new NullReferenceException();
        
        word1 = FormatString(word1);
        word2 = FormatString(word2);
        
        if(word1.Length != word2.Length)
            return false;
        
        foreach (var c in word2)
        {
            if(word1.IndexOf(c) == -1)
                return false;
            word1 = word1.Remove(word1.IndexOf(c), 1);
        }
        
        return word1.Length == 0;
    }
}