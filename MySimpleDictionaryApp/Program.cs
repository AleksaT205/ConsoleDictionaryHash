using System;
using System.Diagnostics;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Ostali testovi iz prethodnog primera...

        Console.WriteLine("\n--- Pokretanje detaljnog benchmark testa ---");
        RunDetailedBenchmark();
    }

    static void RunDetailedBenchmark()
    {
        var dict = new MySimpleDictionary<int, int>();
        Stopwatch sw = new Stopwatch();

        const int n = 100_000;

        // 1. Dodavanje n elemenata - O(n)
        sw.Restart();
        for (int i = 0; i < n; i++)
        {
            dict.Add(i, i * 10);
        }
        sw.Stop();
        Console.WriteLine($"Dodavanje {n} elemenata: {sw.ElapsedMilliseconds} ms (O(n))");

        // 2. Pristup elementima preko indeksa (get) - O(n) po ključa (jer lista traži linearno)
        sw.Restart();
        int sum = 0;
        for (int i = 0; i < n; i += 10_000)
        {
            sum += dict[i];
        }
        sw.Stop();
        Console.WriteLine($"Pristup (get) 10 elemenata: {sw.ElapsedTicks} takta (O(n) linearno pretraživanje)");

        // 3. Izmena elemenata preko indeksa (set) - O(n)
        sw.Restart();
        for (int i = 0; i < n; i += 10_000)
        {
            dict[i] = dict[i] + 1;
        }
        sw.Stop();
        Console.WriteLine($"Izmena (set) 10 elemenata: {sw.ElapsedTicks} takta (O(n) linearno pretraživanje)");

        // 4. Provera postojanja ključeva (ContainsKey) - O(n)
        sw.Restart();
        bool found = false;
        for (int i = 0; i < n; i += 10_000)
        {
            found |= dict.ContainsKey(i);
        }
        sw.Stop();
        Console.WriteLine($"Provera postojanja ključeva 10 puta: {sw.ElapsedTicks} takta (O(n) linearno)");

        // 5. Provera postojanja vrednosti (ContainsValue) - O(n)
        sw.Restart();
        bool valFound = dict.ContainsValue(123456789);
        sw.Stop();
        Console.WriteLine($"Provera postojanja vrednosti (jedan poziv): {sw.ElapsedTicks} takta (O(n))");

        // 6. Uklanjanje elemenata - O(n)
        sw.Restart();
        for (int i = 0; i < n; i += 10_000)
        {
            dict.Remove(i);
        }
        sw.Stop();
        Console.WriteLine($"Uklanjanje 10 elemenata: {sw.ElapsedTicks} takta (O(n))");

        // 7. Iteriranje kroz sve elemente - O(n)
        sw.Restart();
        int count = 0;
        foreach (var kvp in dict)
        {
            count++;
        }
        sw.Stop();
        Console.WriteLine($"Iteracija kroz preostale elemente ({count}): {sw.ElapsedMilliseconds} ms (O(n))");

        // 8. Brisanje svih elemenata - O(1) za List.Clear()
        sw.Restart();
        dict.Clear();
        sw.Stop();
        Console.WriteLine($"Brisanje svih elemenata (Clear): {sw.ElapsedTicks} takta (O(1))");
    }
}
