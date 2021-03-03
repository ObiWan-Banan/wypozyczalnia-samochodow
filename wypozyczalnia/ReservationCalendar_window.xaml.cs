using account;
using cars;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace wypozyczalnia
{

    public partial class ReservationCalendar_window : Window
    {
        private struct ReservationDataGridInfo
        {
            public int carId { get; set; }
            public string carName { get; set; }
            public string borrowerUsername { get; set; }
            public string rentedFrom { get; set; }
            public string rentedTo { get; set; }
            public string imageFilePath { get; set; }
            public int totalReservationCost { get; set; }
        }
        private List<ReservationDataGridInfo> reservationsList;
        public ReservationCalendar_window()
        {
            InitializeComponent();
            initializeReservationsList();
            reservationsGrid.ItemsSource = reservationsList;
        }

        private void initializeReservationsList()
        {
            reservationsList = new List<ReservationDataGridInfo>();

            foreach (var reservation in ReservationCalendar.reservationCalendar)
            {
                ReservationDataGridInfo temp = new ReservationDataGridInfo();
                temp.carId = reservation.carId;
                temp.rentedFrom = reservation.rentedFrom;
                temp.rentedTo = reservation.rentedTo;
                temp.carName = CarList.getSpecificCarName(reservation.carId);
                temp.borrowerUsername = UserList.getUsername(reservation.borrowerId);
                temp.imageFilePath = CarList.getSpecificCarImage(reservation.carId);
                temp.totalReservationCost = ReservationCalendar.calculateTotalReservationCost(reservation.carId);

                reservationsList.Add(temp);
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
            Admin_ControlPanel admin_ControlPanel = new Admin_ControlPanel();
            admin_ControlPanel.Show();
            Close();
        }
    }
}
