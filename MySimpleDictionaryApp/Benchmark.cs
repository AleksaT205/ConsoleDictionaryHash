using System.Diagnostics;

class Benchmark
{
    public static void Run()
    {
        var dict = new MySimpleDictionary<int, int>();
        var stopwatch = new Stopwatch();

        stopwatch.Start();
        for (int i = 0; i < 100_000; i++)
        {
            dict.Add(i, i * 2);
        }
        stopwatch.Stop();
        Console.WriteLine($"Dodavanje 100,000 elemenata trajalo je {stopwatch.ElapsedMilliseconds} ms.");

        stopwatch.Restart();
        bool contains = dict.ContainsKey(50_000);
        stopwatch.Stop();
        Console.WriteLine($"Provera postojanja ključa 50,000 trajala je {stopwatch.ElapsedTicks} tikova.");

        stopwatch.Restart();
        dict.Remove(50_000);
        stopwatch.Stop();
        Console.WriteLine($"Uklanjanje ključa 50,000 trajalo je {stopwatch.ElapsedTicks} tikova.");
    }
}

