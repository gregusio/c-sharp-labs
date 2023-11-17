namespace ParliamentApp;

public class Parliament
{
    private readonly List<Parliamentarian> _parliamentarians;
    private int _currVotesFor;
    private int _currVotesAgainst;
    private readonly string _topic;
    public event EventHandler CollectingVotes = null!;
    public event EventHandler StopCollectingVotes = null!;

    public Parliament(int numberOfParliamentarians, string topic)
    {
        _parliamentarians = new List<Parliamentarian>();
        for (var i = 0; i < numberOfParliamentarians; i++)
            _parliamentarians.Add(new Parliamentarian(i, this));

        _currVotesFor = 0;
        _currVotesAgainst = 0;
        _topic = topic;
    }

    public void StartVoting()
    {
        _currVotesFor = 0;
        _currVotesAgainst = 0;
        CollectingVotes?.Invoke(this, EventArgs.Empty);

        var id = 0;
        var input = Console.ReadLine()!;

        while (input != "END")
        {
            var array = input!.Split(" ");
            if (array?[0] == "VOTE")
                try
                {
                    id = int.Parse(array[1]);
                    var parliamentarian = _parliamentarians.FirstOrDefault(i => i.Id == id);
                    if (parliamentarian!.Vote())
                    {
                        Console.WriteLine($"Parliamentarian with id {id} voted YES");
                        _currVotesFor++;
                    }
                    else
                    {
                        Console.WriteLine($"Parliamentarian with id {id} voted NO");
                        _currVotesAgainst++;
                    }
                }
                catch (Exception e)
                {
                    switch (e)
                    {
                        case FormatException:
                            Console.WriteLine("Try again!");
                            break;
                        case NullReferenceException:
                            Console.WriteLine($"Parliamentarian with id {id} does not exist");
                            break;
                        default:
                            Console.WriteLine(e.Message);
                            break;
                    }
                }
            else
                Console.WriteLine("Try again!");

            input = Console.ReadLine()!;
        }
    }

    public void StopVoting()
    {
        StopCollectingVotes?.Invoke(this, EventArgs.Empty);
    }

    public void ShowLastVoting()
    {
        Console.WriteLine("\nThe results of the vote on {0}", _topic);
        Console.WriteLine("Votes for:      {0}", _currVotesFor);
        Console.WriteLine("Votes against:  {0}", _currVotesAgainst);
        Console.WriteLine("Abstained:      {0}", _parliamentarians.Count - _currVotesFor - _currVotesAgainst);
    }
}