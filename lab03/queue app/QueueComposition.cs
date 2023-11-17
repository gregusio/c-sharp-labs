using System.Collections;

namespace lab03.queue_app;

public class QueueComposition
{
    private readonly ArrayList _array = new ArrayList();
    
    public void Enqueue(Object value)
    {
        _array.Add(value);
    }

    public Object Dequeue()
    {
        if (_array.Count > 0)
        {
            Object o = _array[0]!;
            _array.RemoveAt(0);
            return o;
        }
        throw new Exception("Queue is empty!");
    }
}