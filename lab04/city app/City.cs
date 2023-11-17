namespace lab04.city_app;

public class City
{
    private List<string> GetCities()
    {
        var list = new List<string>();
        string input = Console.ReadLine()!;
        while (input != "X")
        {
            list.Add(input);
            input = Console.ReadLine()!;
        }

        return list;
    }

    private void PrintCities(char letter, Dictionary<char, List<string>> dict)
    {
        if(!dict.ContainsKey(letter))
            Console.WriteLine("Empty");
        else
        {
            foreach (var city in dict[letter])
            {
                Console.Write($"{city} ");
            }

            Console.WriteLine();
        }
    }

    public void Run()
    {
        Console.WriteLine("Enter cities");
        var cityList = GetCities();
        
        var dict = cityList
            .OrderBy(s => s)
            .GroupBy(e => e[0])
            .ToDictionary(g => g.Key, g => g.ToList());
        
        Console.WriteLine("Enter letters");
        string input = Console.ReadLine()!;
        while (input != "END")
        {
            PrintCities(input[0], dict);
            input = Console.ReadLine()!;
        }
    }
}