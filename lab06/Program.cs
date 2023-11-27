using System.Reflection;
using lab06;

Console.WriteLine("Fields: ");

var type = Type.GetType("lab06.Customer");
var fields = type!.GetFields(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);

Console.WriteLine("-- Public: ");

foreach (var fieldInfo in fields)
{
    if(fieldInfo.IsPublic)
        Console.WriteLine($"Type: \"{fieldInfo.FieldType.Name}\"; name: \"{fieldInfo.Name}\"");
}

Console.WriteLine("-- Non Public: ");

foreach (var fieldInfo in fields)
{
    if(fieldInfo.IsPrivate || fieldInfo.IsFamily)
        Console.WriteLine($"Type: \"{fieldInfo.FieldType.Name}\"; name: \"{fieldInfo.Name}\"");
}

var methods = type!.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

Console.WriteLine("Methods: ");

foreach (var methodInfo in methods)
{
    Console.WriteLine($"Method: \"{methodInfo.Name}\"");
}

var nestedTypes = type!.GetNestedTypes(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

Console.WriteLine("Nested types: ");

foreach (var nestedType in nestedTypes)
{
    Console.WriteLine($"Nested type: \"{nestedType.Name}\"");
}

var properties = type!.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

Console.WriteLine("Properties: ");

foreach (var propertyInfo in properties)
{
    Console.WriteLine($"Property: \"{propertyInfo.Name}\"");
}

var members = type!.GetMembers(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);

Console.WriteLine("Members: ");

foreach (var memberInfo in members)
{
    Console.WriteLine($"Member: \"{memberInfo.Name}\"");
}

var customer = new Customer("John");
type.GetProperty("Address")!.SetValue(customer, "Some address");
type.GetProperty("SomeValue")!.SetValue(customer, 100);

foreach (var propertyInfo in type.GetProperties())
{
    Console.WriteLine("Property: " + propertyInfo.Name + "; value: " + propertyInfo.GetValue(customer));
}