using Common;

namespace BeerProcessor;

public class BeerAssignment : IAssignment
{
    public string Title { get; set; } = "";

    public void Process()
    {
        Console.WriteLine(Title);
        Console.WriteLine("Mix malt extract or malted grains with water to create a mash.");
        Thread.Sleep(2000);
        Console.WriteLine("Allow the yeast to ferment the liquid, converting sugars into alcohol and carbon dioxide.");
        Thread.Sleep(2000);
        Console.WriteLine("Transfer the fermented beer into clean, sanitized bottles, leaving sediment behind.");
        Thread.Sleep(2000);
    }
}