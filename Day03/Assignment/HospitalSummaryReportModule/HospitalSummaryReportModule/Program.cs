
using HospitalSummaryReportModule;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("       DAILY HOSPITAL ACTIVITY REPORT");
        Console.WriteLine("--------------------------------------------------");

        Console.WriteLine("Date: " + DateTime.Now.ToString("dd-MM-yyyy"));

   
        List<PatientRecord> patients = new List<PatientRecord>
        {
            new PatientRecord { Name = "John Doe",  Department = "General",   BillAmount = 500,  Status = "Discharged" },
            new PatientRecord { Name = "Jane Smith",Department = "Dental",    BillAmount = 1200, Status = "Admitted" },
            new PatientRecord { Name = "Bob Brown", Department = "General",   BillAmount = 400,  Status = "Discharged" },
            new PatientRecord { Name = "Alice W.",  Department = "Ortho",     BillAmount = 2500, Status = "Admitted" },
            new PatientRecord { Name = "Sam K.",    Department = "Dental",    BillAmount = 800,  Status = "Discharged" }
        };

        Console.WriteLine("\nPatient List:");

        int count = 1;
        decimal totalRevenue = 0;

       
        int generalCount = 0;
        int dentalCount = 0;
        int orthoCount = 0;


        foreach (PatientRecord p in patients)
        {
            Console.WriteLine($"{count}. {p.Name} - {p.Department} - ${p.BillAmount}");

            totalRevenue += p.BillAmount;

         
            if (p.Department == "General")
                generalCount++;
            else if (p.Department == "Dental")
                dentalCount++;
            else if (p.Department == "Ortho")
                orthoCount++;

            count++;
        }

      
        int totalPatients = patients.Count;

      
        Console.WriteLine("\n--------------------------------------------------");
        Console.WriteLine("SUMMARY STATISTICS");
        Console.WriteLine("--------------------------------------------------");

        Console.WriteLine("Total Patients Visited:  " + totalPatients);
        Console.WriteLine("Total Revenue:           $" + totalRevenue);

        Console.WriteLine("\nTraffic by Department:");
        Console.WriteLine("- General: " + generalCount);
        Console.WriteLine("- Dental:  " + dentalCount);
        Console.WriteLine("- Ortho:   " + orthoCount);

        Console.WriteLine("\nEnd of Report.");
        Console.WriteLine("--------------------------------------------------");

        Console.ReadLine();
    }
}
