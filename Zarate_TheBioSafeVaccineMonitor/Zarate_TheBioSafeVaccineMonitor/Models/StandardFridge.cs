/* =====================================================================
 * DESCRIPTION:
 * REPRESENTS A STANDARD REFRIGERATOR FOR VACCINE STORAGE.
 * EACH STORAGE TYPE HAS ITS OWN TEMPERATURE RULES.
 * ====================================================================
 */

using System;
using Zarate_TheBioSafeVaccineMonitor.Interfaces;

namespace Zarate_TheBioSafeVaccineMonitor.Models
{
    public class StandardFridge : MedicalStorage, IAlertable
    {
        // SAFE LIMIT FOR STANDARD VACCINES
        private readonly double threshold = 8;

        public StandardFridge(string id, double temp)
            : base(id, temp)
        {
        }

        // POLYMORPHIC BEHAVIOR
        public override void CheckTemperature()
        {
            Console.WriteLine("CHECKING STANDARD FRIDGE...");

            if (CurrentTemp > threshold)
            {
                TriggerAlarm("STANDARD FRIDGE TEMPERATURE EXCEEDED!");
            }
            else
            {
                Console.WriteLine("TEMPERATURE WITHIN SAFE RANGE.");
            }
        }

        public void TriggerAlarm(string message)
        {
            Console.WriteLine($"[ALARM - FRIDGE]: {message}");
        }
    }
}