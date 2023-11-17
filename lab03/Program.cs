using lab03.person_app;
using lab03.queue_app;

var person = new PersonApp();
person.Run();

var queue = new QueueApp();
queue.RunQueue();
queue.RunBetterQueue();
