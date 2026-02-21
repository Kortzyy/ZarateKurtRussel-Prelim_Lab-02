/* ====================================================================
 * Name of the Lab: Prelim Activity 02: Advanced Object-Oriented Programming and Robustness
 * Developer Name : Kurt Russel B. Zarate
 * Subject        : IT Elective 2
 * Course & Block : BSIT - 3.2
 * Date Created   : February 20, 2026
 * Description:
 * USER-DRIVEN SIMULATION OF THE BIO-SAFE VACCINE MONITOR SYSTEM.
 * THIS FILE HANDLES:
 *  - USER INPUT
 *  - INPUT VALIDATION
 *  - POLYMORPHIC EXECUTION FLOW
 *  - GLOBAL EXCEPTION HANDLING
 * ====================================================================
 */

using System;
using Zarate_TheBioSafeVaccineMonitor.Models;

namespace Zarate_TheBioSafeVaccineMonitor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // DISPLAY SYSTEM TITLE FOR USER CONTEXT
                Console.WriteLine("=== BIO-SAFE VACCINE MONITOR SYSTEM ===\n");

                // CREATE A MEDICAL STORAGE OBJECT BASED ON USER INPUT
                // POLYMORPHISM IS USED BECAUSE THE RETURN TYPE IS THE BASE CLASS
                MedicalStorage storage = CreateStorageFromUserInput();

                // CALL THE SAME METHOD REGARDLESS OF STORAGE TYPE
                // ACTUAL METHOD EXECUTED DEPENDS ON OBJECT TYPE AT RUNTIME
                storage.CheckTemperature();

                // SIMULATE DOOR OPEN AND CLOSE OPERATION
                SimulateDoorOperation(storage);
            }
            catch (ArgumentException ex)
            {
                // CATCHES INVALID USER INPUT SUCH AS WRONG DATA TYPES
                Console.WriteLine($"INPUT ERROR: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                // CATCHES OPERATIONAL ERRORS SUCH AS DOOR LEFT OPEN TOO LONG
                Console.WriteLine($"OPERATION ERROR: {ex.Message}");
            }
            catch (Exception ex)
            {
                // CATCHES ANY UNEXPECTED SYSTEM ERRORS
                Console.WriteLine($"UNEXPECTED ERROR: {ex.Message}");
            }
            finally
            {
                // ALWAYS EXECUTES REGARDLESS OF SUCCESS OR FAILURE
                Console.WriteLine("\nSYSTEM SHUTDOWN.");
            }
        }

        // ============================================================
        // HELPER METHODS
        // THESE METHODS KEEP MAIN() CLEAN AND PREVENT SPAGHETTI CODE
        // ============================================================

        // CREATES THE APPROPRIATE STORAGE OBJECT BASED ON USER SELECTION
        private static MedicalStorage CreateStorageFromUserInput()
        {
            // ASK USER TO SELECT STORAGE TYPE
            Console.WriteLine("SELECT STORAGE TYPE:");
            Console.WriteLine("[1] Ultra-Cold Freezer");
            Console.WriteLine("[2] Standard Fridge");
            Console.Write("ENTER CHOICE: ");

            string choice = Console.ReadLine();

            // GET STORAGE IDENTIFIER FROM USER
            Console.Write("ENTER STORAGE ID: ");
            string id = Console.ReadLine();

            // GET TEMPERATURE WITH VALIDATION
            double temp = ReadDouble("ENTER CURRENT TEMPERATURE: ");

            // RETURN OBJECT BASED ON USER CHOICE
            // POLYMORPHISM: RETURN TYPE IS MedicalStorage
            return choice switch
            {
                "1" => new UltraColdFreezer(id, temp),
                "2" => new StandardFridge(id, temp),
                _ => throw new ArgumentException("INVALID STORAGE TYPE SELECTION.")
            };
        }

        // SAFELY READS A DOUBLE VALUE FROM USER INPUT
        // PREVENTS APPLICATION CRASH FROM INVALID INPUT
        private static double ReadDouble(string prompt)
        {
            Console.Write(prompt);

            // TRY TO PARSE USER INPUT INTO A DOUBLE
            if (!double.TryParse(Console.ReadLine(), out double value))
                throw new ArgumentException("TEMPERATURE MUST BE A NUMBER.");

            return value;
        }

        // HANDLES DOOR OPEN AND CLOSE SIMULATION
        // DEMONSTRATES EXCEPTION HANDLING FOR INVALID OPERATIONS
        private static void SimulateDoorOperation(MedicalStorage storage)
        {
            // ASK USER IF THEY WANT TO OPEN THE DOOR
            Console.Write("\nOPEN DOOR? (Y/N): ");
            string response = Console.ReadLine()?.ToUpper();

            if (response == "Y")
            {
                // RECORD DOOR OPEN TIME
                storage.OpenDoor();

                // ASK USER HOW LONG THE DOOR STAYS OPEN
                int seconds = ReadInt("HOW MANY SECONDS WILL THE DOOR STAY OPEN?: ");

                // SIMULATE TIME PASSING
                System.Threading.Thread.Sleep(seconds * 1000);

                // ATTEMPT TO CLOSE DOOR
                // MAY THROW InvalidOperationException IF TIME > 30 SECONDS
                storage.CloseDoor();
            }
        }

        // SAFELY READS AN INTEGER VALUE FROM USER INPUT
        private static int ReadInt(string prompt)
        {
            Console.Write(prompt);

            // VALIDATE INTEGER INPUT
            if (!int.TryParse(Console.ReadLine(), out int value))
                throw new ArgumentException("INPUT MUST BE A VALID NUMBER.");

            return value;
        }
    }
}