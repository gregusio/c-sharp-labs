using System.Diagnostics;
using System.Net.NetworkInformation;

namespace lab08;

public class App
{
    private static readonly SemaphoreSlim semaphore = new SemaphoreSlim(4);
    
    private void First(string input)
    {
        var lines = input.Split("\n");
        lines = lines[new Range(1, lines.Length)];

        var watch = new Stopwatch();
        
        watch.Start();
        foreach (var line in lines)
        {
            var ping = new Ping();
            ping.Send(line.Split(";")[1]);
        }
        watch.Stop();
        
        Console.WriteLine(watch.ElapsedMilliseconds);
    }

    private void Second(string input)
    {
        var lines = input.Split("\n");
        lines = lines[new Range(1, lines.Length)];

        var watch = new Stopwatch();
        
        
        ParallelOptions options = new ParallelOptions
        {
            MaxDegreeOfParallelism = 4
        };
        
        watch.Start();
        Parallel.ForEach(lines, options, line =>
        {
            var ping = new Ping();
            ping.Send(line.Split(";")[1]);
        });
        watch.Stop();
        
        Console.WriteLine(watch.ElapsedMilliseconds);
    }
    
    private void Third(string input)
    {
        var lines = input.Split("\n");
        lines = lines[new Range(1, lines.Length)];
        var addresses = lines.Select(x => x.Split(";")[1]).ToList();

        var tasks = addresses.Select(address => Task.Run(() =>
        { 
            semaphore.Wait();

            if (Monitor.TryEnter(address))
            {
                var ping = new Ping();
                ping.Send(address);
                Monitor.Exit(address);
            }
            
            semaphore.Release();
            
        })).ToArray();

        var watch = new Stopwatch();
        
        watch.Start();
        Task.WaitAll(tasks);
        watch.Stop();
        
        Console.WriteLine(watch.ElapsedMilliseconds);
    }
    
    public void Run()
    {
        var input = File.ReadAllText("/home/gregusio/Documents/c-sharp-labs/lab08/ping.txt");
        First(input);     //about 36s
        Second(input);    //about 10s
        Third(input);     //about 9s
    }
}
