namespace lab05.concat_app;

public class ConcatStringsAgain
{
    public string Concat(string? str1, string? str2)
    {
        if (str1 == null || str2 == null)
            throw new NullReferenceException();
        
        return str1 + str2;
    }
}