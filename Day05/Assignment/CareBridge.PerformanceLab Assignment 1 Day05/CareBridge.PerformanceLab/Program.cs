using CareBridge.PerformanceLab.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

class Program
{
    static void Main()
    {
        using var db = new CareBridgeContext();

        var stopwatch = new System.Diagnostics.Stopwatch();
        stopwatch.Start();

        Console.WriteLine("REVENUE-AT-RISK DASHBOARD");
        Console.WriteLine("------------------------------------------------------------");

        
        var summary = db.Claims
            .AsNoTracking()
            .GroupBy(c => c.Status)
            .Select(g => new
            {
                Status = g.Key,
                ClaimCount = g.Count(),

                TotalBilled = g.Sum(c => c.BilledAmount),

                
                TotalReimbursed = g.Sum(c => c.ReimbursedAmt),

                Gap = g.Sum(c => c.BilledAmount - (c.ReimbursedAmt))
            })
            .OrderByDescending(x => x.TotalBilled)
            .ToList();

       
        var revenueAtRisk = db.Claims
            .AsNoTracking()
            .Where(c => c.Status != "Paid")
            .Sum(c => c.BilledAmount);

        stopwatch.Stop();

        Console.WriteLine("Status      Claims      Billed        Reimbursed      Gap");

        foreach (var item in summary)
        {
            Console.WriteLine(
                $"{item.Status,-10} {item.ClaimCount,-10} {item.TotalBilled,-13} {item.TotalReimbursed,-15} {item.Gap}"
            );
        }

        Console.WriteLine("------------------------------------------------------------");

        Console.WriteLine($"REVENUE AT RISK (not Paid) : {revenueAtRisk}");

        
        Console.WriteLine($"Tracked Entities           : {db.ChangeTracker.Entries().Count()}");

        Console.WriteLine($"Elapsed Time               : {stopwatch.ElapsedMilliseconds} ms");
    }
}
