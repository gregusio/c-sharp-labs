namespace lab04.matrix_app;

public class Matrix
{
    private int Sum(List<List<int>> list)
    {
        return list.Sum(x => x.Sum());
    }
    
    public void Run()
    {
        Console.WriteLine("Enter matrix size");
        var input = Console.ReadLine()!;
        var n = Int32.Parse(input);
        input = Console.ReadLine()!;
        var m = Int32.Parse(input);

        Random random = new Random();

        var list = Enumerable.Repeat(Enumerable.Repeat(0, m).ToList(), n).ToList();
        var filledList = list
            .Select(x => x
                .Select(y => random.Next(10))
                .ToList())
            .ToList();
        
        var matrixSum = filledList
            .SelectMany(x => x)
            .ToList()
            .Sum();
        
        // Console.WriteLine(matrixSum == Sum(filledList));
        Console.WriteLine(matrixSum);
    }
}