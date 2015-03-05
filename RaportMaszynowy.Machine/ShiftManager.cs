using System;

namespace RaportMaszynowy.Machine
{
    public class ShiftManager
    {
        //Operator wtryskarki oraz system rozpoczyna raportowanie produkcji od godzin I zm.- 06:00:01, II zm.- 14:00:01, III zm.- 22:00:01.
        /// <summary>
        /// Zwraca numer zmiany w zaleznosci od czasu
        /// </summary>
        /// <returns></returns>
        public int GetShiftNumber()
        {
            // use DateTime.Now
        }
    }
}
