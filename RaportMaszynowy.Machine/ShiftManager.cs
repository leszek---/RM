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
            DateTime dateNow = DateTime.Now;
            DateTime hour6 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 6, 0, 0);
            DateTime hour14 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 14, 0, 0);
            DateTime hour22 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 22, 0, 0);
            
            if(dateNow > hour6 & dateNow <= hour14 )
                return 1;
            if (dateNow > hour14 & dateNow <= hour22)
                return 2;
            if (dateNow > hour22 || dateNow <= hour6)
                return 3;
            else
                return 0;
        }
    }
}
