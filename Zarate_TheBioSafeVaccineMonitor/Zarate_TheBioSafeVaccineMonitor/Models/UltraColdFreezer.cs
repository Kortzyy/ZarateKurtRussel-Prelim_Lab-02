/* =====================================================================
 * DESCRIPTION:
 * REPRESENTS A FREEZER THAT STORES VACCINES AT EXTREME LOW TEMPERATURES.
 * DEMONSTRATES:
 *  - INHERITANCE
 *  - POLYMORPHISM (OVERRIDE)
 *  - INTERFACE IMPLEMENTATION
 * ====================================================================
 */

using System;
using Zarate_TheBioSafeVaccineMonitor.Interfaces;

namespace Zarate_TheBioSafeVaccineMonitor.Models
{
    public class UltraColdFreezer : MedicalStorage, IAlertable
    {
        // SAFE TEMPERATURE LIMIT
        // IF CURRENT TEMP IS HIGHER THAN THIS, ALARM TRIGGERS
        private readonly double threshold = -60;

        // PASS PARAMETERS TO BASE CLASS USING : base()
        public UltraColdFreezer(string id, double temp)
            : base(id, temp)
        {
        }

        // OVERRIDE BASE METHOD
        // THIS IS POLYMORPHISM IN ACTION
        public override void CheckTemperature()
        {
            Console.WriteLine("CHECKING ULTRA-COLD FREEZER...");

            // COMPARE CURRENT TEMP TO SAFE THRESHOLD
            if (CurrentTemp > threshold)
            {
                // CALL ALARM IF UNSAFE
                TriggerAlarm("ULTRA-COLD FREEZER TEMPERATURE EXCEEDED!");
            }
            else
            {
                Console.WriteLine("TEMPERATURE WITHIN SAFE RANGE.");
            }
        }

        // IMPLEMENT INTERFACE METHOD
        public void TriggerAlarm(string message)
        {
            Console.WriteLine($"[ALARM - FREEZER]: {message}");
        }
    }
}