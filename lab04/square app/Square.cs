namespace lab04.square_app;

public class Square
{
    public void Run()
    {
        Console.WriteLine("Enter number");
        string input = Console.ReadLine()!;
        var n = Int32.Parse(input);
        
        var query =
            from num in Enumerable.Range(1, n)
            where num != 5 && num != 9 && (num % 2 == 1 || num % 7 == 0)
            select num;

        var enumerable = query as int[] ?? query.ToArray();
        
        Console.WriteLine(enumerable.Sum());
        Console.WriteLine(enumerable.Length);
        Console.WriteLine(enumerable.FirstOrDefault());
        Console.WriteLine(enumerable.ElementAtOrDefault(2));
    }
}