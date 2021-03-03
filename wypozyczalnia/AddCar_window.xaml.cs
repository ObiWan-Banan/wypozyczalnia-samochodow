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
    public partial class AddCar_window : Window
    {
        public AddCar_window(double leftPosition, double topPosition)
        {
            InitializeComponent();
            this.Left = leftPosition;
            this.Top = topPosition;
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

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string name = carName.Text;
            string imageFilePath = ImageFilePath.Text;
            string productionYear = production_year.Text;
            string horsepower = Horsepower.Text;
            string rentPrice = RentPrice.Text;
            string gearbox;
            string bodyType;
            string fuelType;

            if (String.IsNullOrEmpty(name))
            {
                System.Windows.MessageBox.Show("Please fill in car name box.");
                return;
            }
            if (String.IsNullOrEmpty(imageFilePath))
            {
                System.Windows.MessageBox.Show("Please fill in image file path box.");
                return;
            }
            if (String.IsNullOrEmpty(productionYear))
            {
                System.Windows.MessageBox.Show("Please fill in production year box.");
                return;
            }
            if (String.IsNullOrEmpty(horsepower))
            {
                System.Windows.MessageBox.Show("Please fill in horsepower box.");
                return;
            }
            try
            {
                gearbox = Gearbox.SelectedValue.ToString();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Please choose gearbox type.");
                return;
            }
            try
            {
                bodyType = BodyType.SelectedValue.ToString();
            }
            catch (Exception)
            {

                System.Windows.MessageBox.Show("Please choose body type.");
                return;
            }
            try
            {
                fuelType = FuelType.SelectedValue.ToString();
            }
            catch (Exception)
            {

                System.Windows.MessageBox.Show("Please choose fuel type.");
                return;
            }
            if (String.IsNullOrEmpty(rentPrice))
            {
                System.Windows.MessageBox.Show("Please fill in rent price box.");
                return;
            }
            Car temp = new Car();
            temp.id = CarList.getMaxIdFromBothLists() + 1;
            temp.name = name;
            temp.imageFilePath = imageFilePath;
            temp.productionYear = Int32.Parse(productionYear);
            temp.horsepower = Int32.Parse(horsepower);
            temp.gearbox = (gearbox)Enum.Parse(typeof(gearbox), gearbox);
            temp.bodyType = (bodyType)Enum.Parse(typeof(bodyType), bodyType);
            temp.fuelType = (fuelType)Enum.Parse(typeof(fuelType), fuelType);
            temp.rentPrice = Int32.Parse(rentPrice);
            System.Windows.MessageBox.Show("Car added!");
            CarList.AddNewCarToList(temp);

            Admin_ControlPanel admin_ControlPanel = new Admin_ControlPanel(Left, Top);
            admin_ControlPanel.Show();
            Close();

        }
    }
}
