using Common;

namespace SandwichProcessor;

public class SandwichAssignment : IAssignment
{
    public string Title { get; set; } = "";

    public void Process()
    {
        Console.WriteLine(Title);
        Console.WriteLine("Gather sliced salami, bread, cheese, lettuce, and tomatoes.");
        Thread.Sleep(1000);
        Console.WriteLine("Layer salami on one bread slice, add cheese, lettuce, and tomato slices.");
        Thread.Sleep(1000);
        Console.WriteLine("Optionally spread mayo or mustard on the other slice, sprinkle salt and pepper.");
        Thread.Sleep(1000);
        Console.WriteLine("Top with the second bread slice, cut if desired, and enjoy your quick salami sandwich!");
        Thread.Sleep(1000);
    }
}