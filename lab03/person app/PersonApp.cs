namespace lab03.person_app;

public class PersonApp
{
    private void ChangeNames(Person person)
    {
        person.Name = "Adam";
        person.SecondName = "Kowalski";
    }

    private void ChangePerson(Person person)
    {
        person = new Person("Wojciech", "Nowaczkiewicz");
    }

    private void ChangePersonToNull(Person person)
    {
        person = null;
    }

    public void Run()
    {
        var person = new Person("Jan", "Nowak");
        Console.WriteLine("{0} {1}", person.Name, person.SecondName);

        ChangeNames(person);
        Console.WriteLine("{0} {1}", person.Name, person.SecondName);

        ChangePerson(person);
        Console.WriteLine("{0} {1}", person.Name, person.SecondName);

        ChangePersonToNull(person);
        Console.WriteLine("{0} {1}", person.Name, person.SecondName);
    }
}