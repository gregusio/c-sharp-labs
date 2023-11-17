using lab03.person_app;
using lab03.queue_app;
using lab03.complex_app;

var person = new PersonApp();
person.Run();

var queue = new QueueApp();
queue.RunQueue();
queue.RunBetterQueue();

var complex1 = new Complex<int>(4, 2);
Console.WriteLine($"real: {complex1.GetRealPart()} abstract: {complex1.GetAbstractPart()}");

var complex2 = new Complex<double>(4.5, 1.1);
Console.WriteLine($"real: {complex2.GetRealPart()} abstract: {complex2.GetAbstractPart()}");