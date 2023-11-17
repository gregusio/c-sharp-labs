using System.Text.RegularExpressions;

namespace SimpleGame;

public class Game
{
    private void ShowLocation(Location location)
    {
        Console.WriteLine($"You are in location {location.Name}. What do you want to do?");
        var counter = 1;
        foreach (var npc in location.Npcs)
            Console.WriteLine($"[{counter++}] Talk to {npc.Name}");

        Console.WriteLine("[X] Close the game");
    }

    private void TalkTo(NonPlayerCharacter npc, DialogParser parser)
    {
        var dialogNotFinished = true;
        var currentNpcDialog = npc.Dialog;
        Console.WriteLine(parser.ParseDialog(currentNpcDialog));

        while (dialogNotFinished)
        {
            var heroAnswers = currentNpcDialog?.HeroAnswers;
            if (heroAnswers is null)
            {
                dialogNotFinished = false;
            }
            else
            {
                var counter = 1;
                foreach (var answer in heroAnswers)
                    Console.WriteLine($"[{counter++}] {parser.ParseDialog(answer)}");
                var option = 1;
                var wrongInput = true;
                while (wrongInput)
                {
                    var input = Console.ReadLine();

                    if (input!.Length != 1 || (option = input[0] - 48) > heroAnswers.Count)
                        Console.WriteLine("Chosen answer is out of range. Please try again!");
                    else if (option <= heroAnswers.Count) wrongInput = false;
                }

                currentNpcDialog = heroAnswers[option - 1].NextDialog;
                if (currentNpcDialog is not null)
                    Console.WriteLine(parser.ParseDialog(currentNpcDialog));
                else
                    dialogNotFinished = false;
            }
        }
    }

    private string FormatString(string name)
    {
        var moreWhiteSpaces = new Regex(@"\s\s+");
        name = name.Trim();
        name = moreWhiteSpaces.Replace(name, " ");
        return name;
    }

    private bool IsNameValid(string name)
    {
        var charsOthersThanLetters = new Regex(@"[^A-Za-z ]");

        return !charsOthersThanLetters.IsMatch(name) && name.Length >= 2;
    }

    private EHeroClass ChosenClass(string chosenClass)
    {
        switch (chosenClass)
        {
            case "1":
                return EHeroClass.Merchant;
            case "2":
                return EHeroClass.Witcher;
            case "3":
                return EHeroClass.King;
            default:
                throw new ArgumentException("Incorrect input. Try again!");
        }
    }

    private NonPlayerCharacter CreateExampleMerchant()
    {
        var heroPart6 = new HeroDialogPart("No, I will not help, goodbye.", null);
        var heroPart5 = new HeroDialogPart("In that case, deal with it yourself.", null);
        var merchantPart4 = new NpcDialogPart("Thanks.", null);
        var heroPart4 = new HeroDialogPart("OK, it can be 100 oren.", merchantPart4);
        var merchantPart3 = new NpcDialogPart("Unfortunately, I don't have more. I am very poor.",
            new List<HeroDialogPart>() { heroPart4, heroPart5 });
        var heroPart3 = new HeroDialogPart("100 oren is not enough!", merchantPart3);
        var heroPart2 = new HeroDialogPart("I'll let you know when I'm ready.", null);
        var merchantPart2 =
            new NpcDialogPart("Thank you! As a reward, you will receive 100 oren from me.",
                new List<HeroDialogPart>() { heroPart2, heroPart3 });
        var heroPart1 = new HeroDialogPart("Yes, I'm happy to help.", merchantPart2);
        var merchantPart1 =
            new NpcDialogPart("Hello #HERONAME#, can you help me get to another city?",
                new List<HeroDialogPart>() { heroPart1, heroPart6 });

        return new NonPlayerCharacter("Quartermaster", merchantPart1);
    }

    private NonPlayerCharacter CreateExampleWitcher()
    {
        var witcherPart5 = new NpcDialogPart("I know it's not much, but a witcher has to live for something.", null);
        var heroPart6 = new HeroDialogPart("So we will leave as soon as I am ready.", null);
        var witcherPart4 = new NpcDialogPart("South of the village of Podgaje.",
            new List<HeroDialogPart>() { heroPart6 });
        var heroPart5 = new HeroDialogPart("Little for such a beast.", witcherPart5);
        var heroPart4 = new HeroDialogPart("Where to find it?", witcherPart4);
        var witcherPart3 = new NpcDialogPart("300 Novigrad crowns.",
            new List<HeroDialogPart>() { heroPart5, heroPart6 });
        var heroPart3 = new HeroDialogPart("What's the prize on him?", witcherPart3);
        var witcherPart2 =
            new NpcDialogPart("The monster is called the basilisk and it is the terror of these marshes.",
                new List<HeroDialogPart>() { heroPart3, heroPart4 });
        var heroPart2 = new HeroDialogPart("Surely brother, what is this monster?", witcherPart2);
        var heroPart1 = new HeroDialogPart("I don't have time for that.", null);
        var witcherPart1 = new NpcDialogPart("Hello #HERONAME#, will you help me defeat the monster?",
            new List<HeroDialogPart>() { heroPart1, heroPart2 });

        return new NonPlayerCharacter("Lambert", witcherPart1);
    }

    public void Run()
    {
        var input = "";
        var wrongInput = true;
        EHeroClass chosenClass = EHeroClass.King;

        Console.WriteLine("Welcome to the game!");
        while (wrongInput)
        {
            Console.WriteLine("[1] Start a new game");
            Console.WriteLine("[X] Close the game");
            input = Console.ReadLine();

            if (input != "1" && input != "X")
                Console.WriteLine("The selected option is wrong! Please try again!");
            else
                wrongInput = false;
        }

        if (input == "1")
        {
            Console.Clear();
            Console.WriteLine("Name the hero");

            wrongInput = true;
            while (wrongInput)
            {
                input = Console.ReadLine();
                input = FormatString(input!);
                if (IsNameValid(input))
                    wrongInput = false;
                else
                    Console.WriteLine("Incorrect hero name. Please try again!");
            }

            var characterName = input;

            Console.WriteLine($"Hello {characterName}, choose a hero class");

            wrongInput = true;
            while (wrongInput)
            {
                Console.WriteLine("[1] " + EHeroClass.Merchant);
                Console.WriteLine("[2] " + EHeroClass.Witcher);
                Console.WriteLine("[3] " + EHeroClass.King);
                input = Console.ReadLine();
                
                try
                {
                    chosenClass = ChosenClass(input!);
                    wrongInput = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var newHero = new Hero(characterName, chosenClass);
            var parser = new DialogParser(newHero);
            
            Console.Clear();
            Console.WriteLine($"{newHero.HeroClass} {newHero.Name} sets out on an adventure.");

            var merchant = CreateExampleMerchant();
            var witcher = CreateExampleWitcher();
            var location = new Location("Velen", new List<NonPlayerCharacter>() {merchant, witcher});

            while (true)
            {
                ShowLocation(location);
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        TalkTo(merchant, parser);
                        break;
                    case "2":
                        TalkTo(witcher, parser);
                        break;
                    case "X":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Incorrect choice. Please try again!");
                        break;
                }
            }
        }
        else if (input == "X")
        {
            Environment.Exit(0);
        }
    }
}