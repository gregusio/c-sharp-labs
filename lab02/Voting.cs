namespace ParliamentApp;

public class Voting
{
    public void Run()
    {
        string input;
        var wrongInput = true;
        var numberOfParliamentarians = 0;

        while (wrongInput)
        {
            Console.WriteLine("Enter the number of parliamentarians");
            input = Console.ReadLine()!;
            try
            {
                numberOfParliamentarians = int.Parse(input);
                wrongInput = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("You entered not a number, try again!");
            }
        }

        Console.WriteLine("Enter the topic of the voting");
        var topic = Console.ReadLine();
        var parliament = new Parliament(numberOfParliamentarians, topic!);

        Console.WriteLine($"The voting topic is {topic}");
        Console.WriteLine("To start voting, type START");

        //to show that random parliamentarian cannot vote before typing START uncomment lines below
        // try
        // {
        //     var par = new Parliamentarian(123, parliament);
        //     par.Vote();
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e.Message);
        // }


        wrongInput = true;
        while (wrongInput)
        {
            input = Console.ReadLine()!;
            if (input == "START")
            {
                Console.WriteLine("Voting started!");
                parliament.StartVoting();
                wrongInput = false;
            }
            else
            {
                Console.WriteLine("To start voting, type START");
            }
        }

        parliament.StopVoting();
        parliament.ShowLastVoting();

        //to show that you cannot vote after typing END uncomment line below
        // try
        // {
        //     var par = new Parliamentarian(321, parliament);
        //     par.Vote();
        // }
        // catch (Exception e)
        // {
        //     Console.WriteLine(e.Message);
        // }
    }
}