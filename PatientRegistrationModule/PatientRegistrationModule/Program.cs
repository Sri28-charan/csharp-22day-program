using PatientRegistrationModule;
using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("        HOSPITAL PATIENT REGISTRATION SYSTEM");
        Console.WriteLine("--------------------------------------------------");

        try
        {
            // 1. Create a fresh, empty instance of the Patient object first
            Patient newPatient = new Patient();

            // 2. Pass that instance into your static Register method
            Patient registeredPatient = Registration.Register(newPatient);

            Console.WriteLine("\n[Registration Process Completed Successfully]");

            // 3. Print the slip using the populated object returned by your method
            Registration.PrintSlip(registeredPatient);
        }
        catch (Exception ex)
        {
            // Catch any unhandled system level exceptions to prevent unexpected crashes
            Console.WriteLine($"\nAn unexpected system error occurred: {ex.Message}");
        }

        Console.WriteLine("\nPress Enter to exit the application...");
        Console.ReadLine();
    }
}
