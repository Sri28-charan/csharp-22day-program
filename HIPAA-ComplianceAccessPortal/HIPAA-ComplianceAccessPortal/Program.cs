using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace HIPA_ComplianceAccessPortal
{
    class Program
    {
        // Verified local connection string for your SQL Server instance
        private static readonly string ConnectionString =
            "Server=DESKTOP-AESDBS3;Database=CareBridgeDB;Trusted_Connection=True;TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            bool logoutRequested = false;

            while (!logoutRequested)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("==================================================================");
                Console.WriteLine("          CAREBRIDGE HIPAA-COMPLIANT ACCESS PORTAL                ");
                Console.WriteLine("       [Compliance Protocol: Minimum Necessary Access]            ");
                Console.WriteLine("==================================================================");
                Console.ResetColor();
                Console.WriteLine("Select your authenticated corporate role context:");
                Console.WriteLine("1. Clinical Operations Team");
                Console.WriteLine("2. Financial Billing Audit Team");
                Console.WriteLine("3. Research & Analytics Team (De-Identified Scope)");
                Console.WriteLine("4. Shutdown Session / Exit Portal");
                Console.WriteLine("------------------------------------------------------------------");
                Console.Write("Enter your role context selection (1-4): ");

                string roleChoice = Console.ReadLine() ?? string.Empty;

                // Restricting active view endpoints using a switch statement
                switch (roleChoice)
                {
                    case "1":
                        // Targets the newly joined clinical view mapping e.EncounterId = d.EncounterId
                        FetchViewRecords("dbo.vw_Clinical", "CLINICAL OPERATIONS SESSION");
                        break;
                    case "2":
                        // Targets the newly joined billing view combining Claims and Insurance tables
                        FetchViewRecords("dbo.vw_Billing", "BILLING AUDIT SESSION");
                        break;
                    case "3":
                        // Targets the de-identified analytics view with generalized age bands
                        FetchViewRecords("dbo.vw_Analytics_DeId", "ANALYTICS DE-IDENTIFIED RESEARCH SESSION");
                        break;
                    case "4":
                        logoutRequested = true;
                        Console.WriteLine("\n[AUDIT] Terminating session securely. Revoking context permissions...");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n❌ Access Denied: Unrecognized role configuration context.");
                        Console.ResetColor();
                        PauseSession();
                        break;
                }
            }
        }

        /// <summary>
        /// Queries the designated database view securely, generating clean outputs 
        /// aligned with HIPAA minimum data disclosure laws.
        /// </summary>
        private static void FetchViewRecords(string targetViewName, string sessionContextLabel)
        {
            Console.Clear();
            
            Console.WriteLine($"[AUDIT LOG] Establishing Secured Context: {sessionContextLabel}");
            Console.WriteLine($"[QUERY TARGET] Accessing: {targetViewName}");
            Console.ResetColor();
            Console.WriteLine(new string('=', 90) + "\n");

            // Safe connection handling using the 'using' pattern to protect unmanaged connection streams
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                // Selecting from a specific view prevents users from touching base tables directly
                string secureQuery = $"SELECT TOP 20 * FROM {targetViewName};";

                using (SqlCommand command = new SqlCommand(secureQuery, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Console.WriteLine("No permitted data streams available within this role scope.");
                                PauseSession();
                                return;
                            }

                            // 1. Output permitted headers dynamically based on view columns
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                Console.Write($"{reader.GetName(i),-25}");
                            }
                            Console.WriteLine();
                            Console.WriteLine(new string('-', reader.FieldCount * 25));

                            // 2. Stream permitted rows securely
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

                        Console.WriteLine($"\nSecurity/Data Layer Access Exception: {ex.Message}");
                        Console.ResetColor();
                    }
                    catch (Exception ex)
                    {
                       
                        Console.WriteLine($"\n Application Runtime Error: {ex.Message}");
                        Console.ResetColor();
                    }
                }
            }

            PauseSession();
        }

        private static void PauseSession()
        {
            Console.WriteLine("\n" + new string('-', 90));
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Press [Enter] to cycle your role context or log out securely...");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}