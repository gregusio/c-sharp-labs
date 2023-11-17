namespace lab03.queue_app;

public class QueueApp
{
    public void RunQueue()
    {
        QueueInheritance queueInheritance = new QueueInheritance();
        queueInheritance.Enqueue(1);
        queueInheritance.Enqueue(2);
        try
        {
            Console.WriteLine(queueInheritance.Dequeue());
            Console.WriteLine(queueInheritance.Dequeue());
            Console.WriteLine(queueInheritance.Dequeue());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public void RunBetterQueue()
    {
        QueueComposition queueComposition = new QueueComposition();
        queueComposition.Enqueue(1);
        queueComposition.Enqueue(2);
        
        try
        {
            Console.WriteLine(queueComposition.Dequeue());
            Console.WriteLine(queueComposition.Dequeue());
            Console.WriteLine(queueComposition.Dequeue());
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}