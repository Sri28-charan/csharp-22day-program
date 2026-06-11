using BillingAndCostEstimationModule;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("       HOSPITAL BILLING CALCULATOR");
        Console.WriteLine("--------------------------------------------------");

        Bill bill = new Bill();

   
        Console.Write("Patient Name: ");
        bill.PatientName = Console.ReadLine();

        Console.Write("Patient Age: ");
        bill.Age = Convert.ToInt32(Console.ReadLine());

  
        while (true)
        {
            Console.WriteLine("\nAdd Services:");
            Console.WriteLine("1. Consultation (500)");
            Console.WriteLine("2. Blood Test (200)");
            Console.WriteLine("3. X-Ray (1000)");
            Console.WriteLine("4. Done");

            Console.Write("Choice: ");
            int choice;

            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid input!");
                continue;
            }

            if (choice == 1)
            {
                bill.BaseAmount += Bill.ConsultationFee;
                Console.WriteLine("[Added Consultation]");
            }
            else if (choice == 2)
            {
                bill.BaseAmount += Bill.BloodTestFee;
                Console.WriteLine("[Added Blood Test]");
            }
            else if (choice == 3)
            {
                bill.BaseAmount += Bill.XRayFee;
                Console.WriteLine("[Added X-Ray]");
            }
            else if (choice == 4)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice!");
            }
        }

        Console.WriteLine("\n[Calculating Bill...]");

        if (bill.Age > 60)
        {
            bill.Discount = bill.BaseAmount * 0.20m;
        }
        else if (bill.Age < 10)
        {
            bill.Discount = Bill.ConsultationFee * 0.50m;
        }
        else
        {
            bill.Discount = 0;
        }

        decimal afterDiscount = bill.BaseAmount - bill.Discount;

        bill.Tax = afterDiscount * 0.05m;
        bill.Total = afterDiscount + bill.Tax;

        string type;

        if (bill.Age > 60)
        {
            type = "Senior Citizen";
        }
        else if (bill.Age < 10)
        {
            type = "Child";
        }
        else
        {
            type = "Regular";
        }


    
        Console.WriteLine("\n--------------------------------------------------");
        Console.WriteLine("            FINAL BILL INVOICE");
        Console.WriteLine("--------------------------------------------------");

        Console.WriteLine($"Patient: {bill.PatientName} ({type})\n");

        Console.WriteLine("Base Amount:      " + bill.BaseAmount.ToString("0.00"));
        Console.WriteLine("Discount:         -" + bill.Discount.ToString("0.00"));
        Console.WriteLine("Tax (5%):         +" + bill.Tax.ToString("0.00"));

        Console.WriteLine("\n--------------------------------------------------");
        Console.WriteLine("TOTAL PAYABLE:    " + bill.Total.ToString("0.00"));
        Console.WriteLine("--------------------------------------------------");

        Console.ReadLine();
    }
}