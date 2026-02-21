/* =====================================================================
 * PROJECT: Bio-Safe Vaccine Monitor System
 * DESCRIPTION:
 * ABSTRACT REPRESENTATION OF A GENERIC MEDICAL STORAGE UNIT.
 * CONTAINS SHARED PROPERTIES AND LOGIC USED BY ALL STORAGE TYPES.
 * DEMONSTRATES:
 *  - ENCAPSULATION
 *  - INHERITANCE
 *  - POLYMORPHISM (VIRTUAL METHOD)
 * ====================================================================
 */

using System;
namespace Zarate_TheBioSafeVaccineMonitor.Models
{
    public abstract class MedicalStorage
    {
        // PRIVATE FIELDS (ENCAPSULATION)
        // THESE CANNOT BE DIRECTLY MODIFIED OUTSIDE THIS CLASS.
        private string storageID;
        private double currentTemp;
        private DateTime? doorOpenedAt;

        // PROPERTY TO CONTROL ACCESS TO STORAGE ID
        public string StorageID
        {
            get { return storageID; }
            protected set
            {
                // VALIDATION TO PREVENT EMPTY OR INVALID IDs
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("STORAGE ID CANNOT BE EMPTY.");

                storageID = value;
            }
        }

        // PROPERTY WITH VALIDATION LOGIC
        public double CurrentTemp
        {
            get { return currentTemp; }
            set
            {
                // PREVENT UNREALISTIC TEMPERATURE VALUES
                // THIS PROTECTS THE SYSTEM FROM INVALID DATA
                if (value < -150 || value > 50)
                    throw new ArgumentException("INVALID TEMPERATURE VALUE.");

                currentTemp = value;
            }
        }

        // BASE CONSTRUCTOR
        protected MedicalStorage(string id, double temp)
        {
            // USING PROPERTIES ENSURES VALIDATION IS APPLIED
            StorageID = id;
            CurrentTemp = temp;
        }

        // VIRTUAL METHOD ALLOWS CHILD CLASSES TO PROVIDE
        // THEIR OWN IMPLEMENTATION (POLYMORPHISM)
        public virtual void CheckTemperature()
        {
            Console.WriteLine("CHECKING GENERIC STORAGE...");
        }

        // RECORD THE EXACT TIME WHEN DOOR IS OPENED
        public void OpenDoor()
        {
            doorOpenedAt = DateTime.Now;
            Console.WriteLine("DOOR OPENED.");
        }

        // CHECK HOW LONG THE DOOR WAS OPEN
        public void CloseDoor()
        {
            if (doorOpenedAt.HasValue)
            {
                // CALCULATE DURATION
                TimeSpan duration = DateTime.Now - doorOpenedAt.Value;

                // IF DOOR IS OPEN MORE THAN 30 SECONDS,
                // THROW AN EXCEPTION TO PREVENT SYSTEM FAILURE
                if (duration.TotalSeconds > 30)
                {
                    throw new InvalidOperationException("DOOR LEFT OPEN TOO LONG.");
                }

                // RESET TIMER AFTER SAFE CLOSE
                doorOpenedAt = null;
                Console.WriteLine("DOOR CLOSED SAFELY.");
            }
        }
    }
}

