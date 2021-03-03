using account;
using System.Windows;
using System.Windows.Input;

namespace wypozyczalnia
{
    public partial class User_ControlPanel : Window
    {
        public User_ControlPanel()
        {

            InitializeComponent();
            CenterWindowOnScreen();

        }
        public User_ControlPanel(double leftPosition, double topPosition)
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

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            Cars_window cars_Window = new Cars_window();
            cars_Window.Show();
            Close();
        }

        private void SummaryButton_Click(object sender, RoutedEventArgs e)
        {
            FileWriter.GenerateSpecificUserSummary(CurrentlyLoggedUser.currentlyLoggedUserId);
            System.Windows.MessageBox.Show("Summary generated!\nYou can find it in folder where application is installed.");
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            CancelReservation_window cancelReservation_Window = new CancelReservation_window(Left, Top);
            cancelReservation_Window.Show();
            Close();
        }
    }
}
