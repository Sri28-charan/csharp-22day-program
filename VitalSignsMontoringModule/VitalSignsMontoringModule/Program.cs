using System;
using VitalSignsMontoringModule;

class Program
{
   
    static string CheckStatus(double temp, int oxygen, int pulse)
    {
        if (temp > 39.0 || oxygen < 90 || pulse < 50 || pulse > 120)
            return "CRITICAL / EMERGENCY";

        else if (temp > 37.5 || oxygen < 95 || pulse > 100)
            return "OBSERVATION NEEDED";

        else
            return "NORMAL";
    }

    static void Main(string[] args)
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("       VITAL SIGNS MONITOR");
        Console.WriteLine("--------------------------------------------------");

   
        Details d = new Details();

      
        Console.Write("Enter Patient Name: ");
        d.PatientName = Console.ReadLine();

        while (true)
        {
            try
            {
                Console.Write("Enter Temperature (C): ");
                d.Temperature = Convert.ToDouble(Console.ReadLine());

                if (d.Temperature > 0 && d.Temperature < 45)
                    break;
                else
                    Console.WriteLine("Enter valid temperature");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input! Enter numeric value.");
            }
        }


        while (true)
        {
            try
            {
                Console.Write("Enter Oxygen Level (%): ");
                d.OxygenLevel = Convert.ToInt32(Console.ReadLine());

                if (d.OxygenLevel >= 0 && d.OxygenLevel <= 100)
                    break;
                else
                    Console.WriteLine("Enter oxygen between 0–100%");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!");
            }
        }

   
        while (true)
        {
            try
            {
                Console.Write("Enter Pulse Rate (BPM): ");
                d.PulseRate = Convert.ToInt32(Console.ReadLine());

                if (d.PulseRate > 0 && d.PulseRate < 200)
                    break;
                else
                    Console.WriteLine("Enter valid pulse rate");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input!");
            }
        }

        Console.WriteLine("\n[Analyzing Data...]");

        // ✅ Call method using object values
        string status = CheckStatus(d.Temperature, d.OxygenLevel, d.PulseRate);

        // ✅ Output report
        Console.WriteLine("\n--------------------------------------------------");
        Console.WriteLine("       MEDICAL ASSESSMENT REPORT");
        Console.WriteLine("--------------------------------------------------");

        Console.WriteLine("Patient: " + d.PatientName);

        Console.WriteLine("\nVitals Recorded:");
        Console.WriteLine("- Temp:   " + d.Temperature + " C");
        Console.WriteLine("- Oxygen: " + d.OxygenLevel + " %");
        Console.WriteLine("- Pulse:  " + d.PulseRate + " BPM");

        Console.WriteLine("\nStatus Assessment: " + status);

        Console.WriteLine("\n--------------------------------------------------");

        Console.ReadLine();
    }
}