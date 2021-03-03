using account;
using cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wypozyczalnia
{

    public partial class CancelReservation_window : Window
    {
        private class ReservationComboBoxInfo
        {
            public int carId { get; set; }
            public string carName { get; set; }
            public string rentedFrom { get; set; }
            public string rentedTo { get; set; }
        }
        private List<ReservationComboBoxInfo> reservationComboBoxInfos;
        public CancelReservation_window(double leftPostion, double topPosition)
        {
            InitializeComponent();
            Left = leftPostion;
            Top = topPosition;
            initializeReservationComboBox();
            reservationsComboBox.ItemsSource = reservationComboBoxInfos;
        }

        private void initializeReservationComboBox()
        {
            reservationComboBoxInfos = new List<ReservationComboBoxInfo>();
            foreach (var reservation in ReservationCalendar.reservationCalendar)
            {
                if (reservation.borrowerId == CurrentlyLoggedUser.currentlyLoggedUserId)
                {
                    ReservationComboBoxInfo temp = new ReservationComboBoxInfo();
                    temp.carId = reservation.carId;
                    temp.carName = CarList.getSpecificCarName(reservation.carId);
                    temp.rentedFrom = reservation.rentedFrom;
                    temp.rentedTo = reservation.rentedTo;

                    reservationComboBoxInfos.Add(temp);
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            User_ControlPanel user_ControlPanel = new User_ControlPanel(Left, Top);
            user_ControlPanel.Show();
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            ReservationComboBoxInfo temp = (ReservationComboBoxInfo)reservationsComboBox.SelectedItem;
            if (temp == null)
            {
                System.Windows.MessageBox.Show("Please select reservation.");
                return;
            }
            Reservation resToDelete = new Reservation(CurrentlyLoggedUser.currentlyLoggedUserId, temp.carId, temp.rentedFrom, temp.rentedTo);
            ReservationCalendar.deleteReservationFromList(resToDelete);

            System.Windows.MessageBox.Show("Reservation deleted!");
            User_ControlPanel user_ControlPanel = new User_ControlPanel(Left, Top);
            user_ControlPanel.Show();
            Close();
        }
    }
}
