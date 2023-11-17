using System.Collections;

namespace lab03.queue_app;

public class QueueInheritance : ArrayList
{
    public void Enqueue(Object value)
    {
        base.Add(value);
    }

    public Object Dequeue()
    {
        if (base.Count > 0)
        {
            Object o = base[0]!;
            base.RemoveAt(0);
            return o;
        }
        throw new Exception("Queue is empty!");
    }
}