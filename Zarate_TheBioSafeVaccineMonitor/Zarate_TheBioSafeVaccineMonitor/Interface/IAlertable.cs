/* =====================================================================
 * PROJECT: Bio-Safe Vaccine Monitor System
 * DESCRIPTION: DEFINES A CONTRACT FOR ALL STORAGE UNITS THAT CAN TRIGGER AN ALARM.
 * ====================================================================
 */

namespace Zarate_TheBioSafeVaccineMonitor.Interfaces
{
    public interface IAlertable
    {
        // THIS METHOD FORCES IMPLEMENTING CLASSES
        // DEFINES MANDATORY ALARM BEHAVIOR
        void TriggerAlarm(string message);
    }
}