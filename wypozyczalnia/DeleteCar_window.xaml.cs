using cars;
using System.Windows;
using System.Windows.Input;


namespace wypozyczalnia
{

    public partial class DeleteCar_window : Window
    {
        public DeleteCar_window(double leftPosition, double topPosition)
        {
            InitializeComponent();
            this.Left = leftPosition;
            this.Top = topPosition;
            carToBeDeleted.ItemsSource = CarList.carList;
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
            Admin_ControlPanel admin_ControlPanel = new Admin_ControlPanel(Left, Top);
            admin_ControlPanel.Show();
            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Car temp = (Car)carToBeDeleted.SelectedItem;
            if (temp == null)
            {
                System.Windows.MessageBox.Show("Please select car.");
                return;
            }
            int idToBeDeleted = temp.id;

            if (!ReservationCalendar.checkIfCarHasNoReservations(idToBeDeleted))
            {
                System.Windows.MessageBox.Show("Car can not be deleted because of reservations.");
                return;
            }

            CarList.deleteCarFromList(idToBeDeleted);
            System.Windows.MessageBox.Show("Car deleted!");

            Admin_ControlPanel admin_ControlPanel = new Admin_ControlPanel(Left, Top);
            admin_ControlPanel.Show();
            Close();

        }


    }
}
