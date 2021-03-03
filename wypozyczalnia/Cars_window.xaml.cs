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
using cars;
using account;

namespace wypozyczalnia
{

    public partial class Cars_window : Window
    {
        public static bool isRentWindowOpened = false;
        public Cars_window()
        {
            InitializeComponent();
            CarsGrid.ItemsSource = cars.CarList.carList;
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            User_ControlPanel user_ControlPanel = new User_ControlPanel();
            user_ControlPanel.Show();
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            if (!isRentWindowOpened)
            {
                Car temp = (Car)CarsGrid.SelectedItem;


                RentCar_window rentCar_Window = new RentCar_window(temp);
                rentCar_Window.Show();
                isRentWindowOpened = true;
            }
            else
            {
                System.Windows.MessageBox.Show("You need to close previous rent window in order to open new one.");
                return;
            }
        }
    }
}
