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

    public partial class Admin_ControlPanel : Window
    {

        public Admin_ControlPanel()
        {
            InitializeComponent();
            CenterWindowOnScreen();
        }
        public Admin_ControlPanel(double leftPosition, double topPosition)
        {
            InitializeComponent();
            this.Left = leftPosition;
            this.Top = topPosition;
        }

        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_Car_Button_Click(object sender, RoutedEventArgs e)
        {
            AddCar_window addCar_Window = new AddCar_window(Left, Top);
            addCar_Window.Show();
            Close();
        }

        private void Delete_Car_Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteCar_window deleteCar_Window = new DeleteCar_window(Left, Top);
            deleteCar_Window.Show();
            Close();
        }

        private void Delete_User_Button_Click(object sender, RoutedEventArgs e)
        {
            DeleteUser_window deleteUser_Window = new DeleteUser_window(Left, Top);
            deleteUser_Window.Show();
            Close();
        }

        private void Reservation_Calendar_Button_Click(object sender, RoutedEventArgs e)
        {
            ReservationCalendar_window reservationCalendar_Window = new ReservationCalendar_window();
            reservationCalendar_Window.Show();
            Close();
        }
    }
}
