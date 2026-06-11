using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace PatientRegistrationModule
{
    internal class Registration
    {
        public static Patient Register(Patient patient)
        {
            // Name validation
            while (true)
            {
                Console.WriteLine("Enter Patient Name:");
                string name = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(name))
                {
                    patient.PatientName = name;
                    break;
                }
                else
                {
                    Console.WriteLine("Please enter a valid name");
                }
            }

            // age validation
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Age:");
                    int age = Convert.ToInt32(Console.ReadLine());

                    if (age > 0 && age <= 120)
                    {
                        patient.Age = age;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter age between 1 and 120");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid numeric age");
                }
            }

            // Gender
            Console.WriteLine("Enter Gender (Male/Female/Other):");
            patient.Gender = Console.ReadLine();

            // Phone Validation
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter Phone Number:");
                    string phonenumber = Console.ReadLine();

                    if (phonenumber.Length == 10 && long.Parse(phonenumber) >= 0)
                    {
                        patient.PhoneNumber = phonenumber;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter valid 10-digit phone number");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Phone must contain only digits");
                }
            }

            // City
            Console.WriteLine("Enter City:");
            patient.City = Console.ReadLine();


            // Generate ID
            patient.PatientId = "PAT-" + DateTime.Now.Year + "-" + new Random().Next(100, 999);


            return patient;
        }


        public static void PrintSlip(Patient p)
        {
            Console.WriteLine("\n--------------------------------------------------");
            Console.WriteLine("            PATIENT REGISTRATION SLIP");
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Date: " + DateTime.Now.ToString("dd-MM-yyyy"));
            Console.WriteLine("Patient ID: " + p.PatientId);
            Console.WriteLine("Name:       " + p.PatientName);
            Console.WriteLine("Age:        " + p.Age + " years");
            Console.WriteLine("Gender:     " + p.Gender);
            Console.WriteLine("Contact:    " + p.PhoneNumber);
            Console.WriteLine("Location:   " + p.City);
            Console.WriteLine("\nInstructions:");
            Console.WriteLine("Please proceed to the waiting area.");
            Console.WriteLine("--------------------------------------------------");
        }

    }
}

