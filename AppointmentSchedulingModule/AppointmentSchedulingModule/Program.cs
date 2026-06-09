using AppointmentSchedulingModule;
using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("       APPOINTMENT BOOKING SYSTEM");
        Console.WriteLine("--------------------------------------------------");

        
        Console.Write("Enter Patient Name: ");
        string patientName = Console.ReadLine();

        
        List<string> departments = new List<string>
        {
            "General Medicine",
            "Dental",
            "Orthopedics"
        };

        List<string> generalDoctors = new List<string>
        {
            "Dr. A. Kumar",
            "Dr. B. Singh"
        };

        List<string> dentalDoctors = new List<string>
        {
            "Dr. C. Roy",
            "Dr. D. Gupta"
        };

        List<string> orthoDoctors = new List<string>
        {
            "Dr. E. Reddy",
            "Dr. F. Sharma"
        };

        List<string> timeSlots = new List<string>
        {
            "10:00 AM",
            "11:00 AM",
            "12:00 PM"
        };

        int deptChoice;
        while (true)
        {
            Console.WriteLine("\nSelect Department:");
            for (int i = 0; i < departments.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + departments[i]);
            }

            Console.Write("Enter Choice: ");

            if (int.TryParse(Console.ReadLine(), out deptChoice) &&
                deptChoice >= 1 && deptChoice <= departments.Count)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid selection. Try again.");
            }
        }

        string selectedDepartment = departments[deptChoice - 1];


        List<string> selectedDoctors = new List<string>();

        switch (deptChoice)
        {
            case 1:
                selectedDoctors = generalDoctors;
                break;
            case 2:
                selectedDoctors = dentalDoctors;
                break;
            case 3:
                selectedDoctors = orthoDoctors;
                break;
        }

        int docChoice;
        while (true)
        {
            Console.WriteLine("\nSelect Doctor:");
            for (int i = 0; i < selectedDoctors.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + selectedDoctors[i]);
            }

            Console.Write("Enter Choice: ");

            if (int.TryParse(Console.ReadLine(), out docChoice) &&
                docChoice >= 1 && docChoice <= selectedDoctors.Count)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid selection.Try again.");
            }
        }

        string selectedDoctor = selectedDoctors[docChoice - 1];

      
        int timeChoice;
        while (true)
        {
            Console.WriteLine("\nSelect Time Slot:");
            for (int i = 0; i < timeSlots.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + timeSlots[i]);
            }

            Console.Write("Enter Choice: ");

            if (int.TryParse(Console.ReadLine(), out timeChoice) &&
                timeChoice >= 1 && timeChoice <= timeSlots.Count)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid selection. Try again.");
            }
        }

        string selectedTime = timeSlots[timeChoice - 1];

        Appointment appt = new Appointment
        {
            PatientName = patientName,
            Department = selectedDepartment,
            Doctor = selectedDoctor,
            TimeSlot = selectedTime
        };

        Console.WriteLine("\n[Booking Confirmed]");

        Console.WriteLine("\n--------------------------------------------------");
        Console.WriteLine("            APPOINTMENT TICKET");
        Console.WriteLine("--------------------------------------------------");
        Console.WriteLine("Patient:    " + appt.PatientName);
        Console.WriteLine("Department: " + appt.Department);
        Console.WriteLine("Doctor:     " + appt.Doctor);
        Console.WriteLine("Time:       " + appt.TimeSlot);
        Console.WriteLine("Status:     Confirmed");
        Console.WriteLine("\nPlease arrive 15 mins before your slot.");
        Console.WriteLine("--------------------------------------------------");
        Console.ReadLine();
    }
}