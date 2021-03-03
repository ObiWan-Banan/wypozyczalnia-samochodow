using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using account;
using cars;

namespace wypozyczalnia
{
    /// <summary>
    /// Interaction logic for Login_window.xaml
    /// </summary>
    public partial class Login_window : Window
    {
        public Login_window()
        {
            InitializeComponent();
            CenterWindowOnScreen();
            if (!FileReader.LoadDataFromFiles()) Close();
        }
        public Login_window(double leftPosition, double topPosition)
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

        private void Login_Button_Click(object sender, RoutedEventArgs e)
        {

            string inputPassword = password.Password;
            string inputUsername = username.Text;

            bool switcher = true;

            if (string.IsNullOrEmpty(inputUsername))
            {
                System.Windows.MessageBox.Show("Username box is empty");
                switcher = false;
            }
            else if (string.IsNullOrEmpty(inputPassword))
            {
                System.Windows.MessageBox.Show("Password box is empty");
                switcher = false;
            }

            if (switcher)
            {

                if (AdminList.isOnTheList(inputUsername, inputPassword))
                {

                    System.Windows.MessageBox.Show("You are successfully logged in as an admin!");
                    Admin_ControlPanel admin_ControlPanel = new Admin_ControlPanel(this.Left, this.Top);
                    admin_ControlPanel.Show();
                    Close();
                }
                else if (UserList.isOnTheList(inputUsername, inputPassword))
                {
                    CurrentlyLoggedUser.InitilizeCurrentyLoggedUser(UserList.GetId(inputUsername, inputPassword));
                    System.Windows.MessageBox.Show("You are successfully logged in as an user!");
                    User_ControlPanel user_ControlPanel = new User_ControlPanel(this.Left, this.Top);
                    user_ControlPanel.Show();
                    Close();
                }
                else
                {
                    System.Windows.MessageBox.Show("Account does not exist! Click REGISTER button in order to register.");
                }
            }
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            Register_window register_Window = new Register_window(this.Left, this.Top);
            register_Window.Show();
            Close();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
