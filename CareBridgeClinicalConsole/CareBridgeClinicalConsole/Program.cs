using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace CareBridgeClinicalConsole
{
    class Program
    {
        
        private static readonly string ConnectionString =
            "Server=DESKTOP-AESDBS3;Database=CareBridgeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            bool run = true;

            while (run)
            {
                Console.Clear();
               
                Console.WriteLine("==================================================================");
                Console.WriteLine("             CAREBRIDGE CLINICAL OPERATIONS CONSOLE               ");
                Console.WriteLine("==================================================================");
                Console.ResetColor();
                Console.WriteLine("1. 30-Day Readmission Analytics Report");
                Console.WriteLine("2. High-Risk Patient Safety Monitoring");
                Console.WriteLine("3. Provider Workload & Encounter Distribution");
                Console.WriteLine("4. Monthly Revenue Analysis & Leakage Auditing");
                Console.WriteLine("5. Exit Application");
                Console.WriteLine("------------------------------------------------------------------");
                Console.Write("Select an operational reporting metric (1-5): ");

                string choice = Console.ReadLine() ?? string.Empty;

                // Navigating choices cleanly using a switch statement
                switch (choice)
                {
                    case "1":
                        ExecuteReportProcedure("dbo.sp_Readmissions30DaysReport");
                        break;
                    case "2":
                        ExecuteReportProcedure("dbo.sp_HighRiskPatientsReport");
                        break;
                    case "3":
                        ExecuteReportProcedure("dbo.sp_ProviderWorkloadReport");
                        break;
                    case "4":
                        ExecuteReportProcedure("dbo.sp_RevenueLeakageReport");
                        break;
                    case "5":
                        run = false;
                        Console.WriteLine("\nDisconnecting securely from CareBridgeDB!");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n Invalid choice! Please select a valid number from 1 to 5.");
                        Console.ResetColor();
                        PauseForUser();
                        break;
                }
            }
        }

        private static void ExecuteReportProcedure(string procedureName)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[SYSTEM] Loading Data Stream from: {procedureName}...");
            Console.ResetColor();
            Console.WriteLine("------------------------------------------------------------------\n");

            // 'using' statements ensure database connections close automatically even if a crash happens
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("No active matching records found in this category.");
                                PauseForUser();
                                return;
                            }

                            // 1. Generate Headers Dynamically based on SQL Column Names
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i),-25}");
                            }
                            Console.WriteLine();
                            Console.WriteLine(new string('-', reader.FieldCount * 25));

                            // 2. Stream rows and print them aligned to columns
                            while (reader.Read())
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    // Guard against DBNull exceptions crashing your strings
                                    string cellValue = reader.IsDBNull(i) ? "NULL" : reader.GetValue(i).ToString()!;
                                    Console.Write($"{cellValue,-25}");
                                }
                                Console.WriteLine();
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        
                        Console.WriteLine($"\n Database Connectivity Error: {ex.Message}");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                       
                        Console.WriteLine($"\n Application Runtime Error: {ex.Message}");
                        Console.ResetColor();
                    }
                }
            }

            PauseForUser();
        }

        private static void PauseForUser()
        {
            Console.WriteLine("\n------------------------------------------------------------------");
           
            Console.WriteLine("Press [Enter] to return back to the main console hub...");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}
