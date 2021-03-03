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
using System.Text.RegularExpressions;
using account;
using System.Windows.Controls.Primitives;

namespace wypozyczalnia
{
    /// <summary>
    /// Interaction logic for Register_window.xaml
    /// </summary>
    public partial class Register_window : Window
    {
        public Register_window(double leftPosition, double topPosition)
        {
            InitializeComponent();
            this.Left = leftPosition;
            this.Top = topPosition;
            birthday.BlackoutDates.Add(new CalendarDateRange(new DateTime(2003, 01, 01), DateTime.Now));

        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Login_window login_Window = new Login_window(this.Left, this.Top);
            login_Window.Show();
            Close();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {

            string inputUsername = username.Text;
            string inputPassword = password.Password;
            string inputConfirmPassword = confirm_password.Password;
            string inputBirthday = "";
            Regex reg = new Regex("(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#]).*$");
            Match match = reg.Match(inputPassword);


            if (string.IsNullOrEmpty(inputUsername))
            {
                System.Windows.MessageBox.Show("Username box is empty");
                return;
            }
            else if (string.IsNullOrEmpty(inputPassword))
            {
                System.Windows.MessageBox.Show("Password box is empty");
                return;
            }
            else if (string.IsNullOrEmpty(inputConfirmPassword))
            {
                System.Windows.MessageBox.Show("Confirm Password box is empty");
                return;
            }
            else if (!inputPassword.Equals(inputConfirmPassword))
            {
                System.Windows.MessageBox.Show("Confirm Password does not match password");
                return;
            }
            else if (UserList.isUsernameTaken(inputUsername))
            {
                System.Windows.MessageBox.Show("Username is already taken, choose another one");
                return;
            }
            else if (UserList.isOnTheList(inputUsername, inputPassword))
            {
                System.Windows.MessageBox.Show("User is already on the list");
                return;
            }
            else if (!match.Success)
            {
                System.Windows.MessageBox.Show("Password must have at least: one special character(!@#), one lower case letter, one upper case letter, one number");
                return;
            }
            else
            {
                try
                {
                    DateTime inputDateTimeBirthday = (DateTime)birthday.SelectedDate;
                    inputBirthday = inputDateTimeBirthday.ToShortDateString();
                }
                catch (Exception)
                {
                    System.Windows.MessageBox.Show("Missing box birthday or invalid data format\n(correct one is: DD.MM.RRRR)");
                    return;
                }
            }


            User newUser = new User(inputUsername, inputPassword, inputBirthday);
            UserList.userList.Add(newUser);
            System.Windows.MessageBox.Show("Success! You can now log in.");


            Login_window login_Window = new Login_window(this.Left, this.Top);
            login_Window.Show();

            Close();
        }
    }
}
