using System;
using System.Collections.Generic;

Console.WriteLine("=== Garbage Collection Demo ===");

// Measure memory before allocation
long before = GC.GetTotalMemory(true);

Console.WriteLine($"Memory Before Allocation: {before / 1024} KB");

// Create many patient records
var patients = new List<string>();

for (int i = 0; i < 50_000; i++)
{
    patients.Add($"Patient-{i}");
}

// Measure memory after allocation
long after = GC.GetTotalMemory(true);

Console.WriteLine($"Memory After Allocation: {after / 1024} KB");
Console.WriteLine($"Allocated Approx: {(after - before) / 1024} KB");

// Remove reference to the list
patients = null;

// Request garbage collection
GC.Collect();
GC.WaitForPendingFinalizers();
GC.Collect();

// Measure memory after cleanup
long cleaned = GC.GetTotalMemory(true);

Console.WriteLine($"Memory After Cleanup: {cleaned / 1024} KB");
Console.WriteLine($"Difference From Start: {(cleaned - before) / 1024} KB");

Console.WriteLine();
Console.WriteLine("Discussion:");
Console.WriteLine("- Did memory increase after allocation?");
Console.WriteLine("- Did memory decrease after GC?");
Console.WriteLine("- If not, why might the CLR keep memory reserved?");





Console.WriteLine("=== Garbage Collection Demo ===");

long before1 = GC.GetTotalMemory(true);

Console.WriteLine($"Memory Before Allocation: {before / 1024} KB");

CreatePatients();

GC.Collect();
GC.WaitForPendingFinalizers();
GC.Collect();

long after1 = GC.GetTotalMemory(true);

Console.WriteLine($"Memory After Cleanup: {after / 1024} KB");
Console.WriteLine($"Difference From Start: {(after - before) / 1024} KB");

static void CreatePatients()
{
    var patients = new List<string>();

    for (int i = 0; i < 50_000; i++)
    {
        patients.Add($"Patient-{i}");
    }

    long during = GC.GetTotalMemory(true);

    Console.WriteLine($"Memory During Allocation: {during / 1024} KB");
}

long during = GC.GetTotalMemory(true);
