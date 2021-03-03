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

    public partial class DeleteUser_window : Window
    {
        public DeleteUser_window(double leftPosition, double topPosition)
        {
            InitializeComponent();
            this.Left = leftPosition;
            this.Top = topPosition;
            userToBeDeleted.ItemsSource = UserList.userList;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            User temp = (User)userToBeDeleted.SelectedItem;
            if (temp == null)
            {
                System.Windows.MessageBox.Show("Please select user.");
                return;
            }
            int tempUserId = temp.id;
            if (!ReservationCalendar.checkIfUserHasNoReservations(tempUserId))
            {
                System.Windows.MessageBox.Show("User can not be deleted because of reservations.");
                return;
            }
            UserList.deleteUserFromList(tempUserId);
            ReservationCalendar.deleteUserPastReservations(tempUserId);
            System.Windows.MessageBox.Show("User deleted!");

            Admin_ControlPanel admin_ControlPanel = new Admin_ControlPanel(Left, Top);
            admin_ControlPanel.Show();
            Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Admin_ControlPanel admin_ControlPanel = new Admin_ControlPanel(Left, Top);
            admin_ControlPanel.Show();
            Close();
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
