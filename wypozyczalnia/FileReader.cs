using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wypozyczalnia
{
    public static class FileReader
    {
        public static bool LoadDataFromFiles()
        {
            try
            {
                cars.CarList.initializeCarList();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Error: could not open car data files!");
                FileWriter.programEndedWithException = true;
                return false;
            }
            try
            {
                account.AdminList.initializeAdminList();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Error: could not open admin data files!");
                FileWriter.programEndedWithException = true;
                return false;
            }
            try
            {
                account.UserList.initializeUserList();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Error: could not open user data files!");
                FileWriter.programEndedWithException = true;
                return false;
            }
            try
            {
                cars.ReservationCalendar.LoadReservations();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Error: could not open reservation data files!");
                FileWriter.programEndedWithException = true;
                return false;
            }
            return true;
    }
    }
}
