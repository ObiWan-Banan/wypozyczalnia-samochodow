using account;
using cars;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace wypozyczalnia
{

    public partial class RentCar_window : Window
    {
        private Car selectedCar;
        public RentCar_window(Car car)
        {
            InitializeComponent();
            selectedCar = car;
            this.DataContext = selectedCar;
            pickUpDate.BlackoutDates.AddDatesInPast();
            dropOffDate.BlackoutDates.AddDatesInPast();
            BlackoutDates(selectedCar.id);
            Cars_window.isRentWindowOpened = true;
        }

        private void BlackoutDates(int carId)
        {
            List<Reservation> selectedCarReservations = ReservationCalendar.GetSpecificCarReservationCalendar(carId);

            if (selectedCarReservations.Count == 0) return;

            foreach (var reservation in selectedCarReservations)
            {
                DateTime temp1 = Convert.ToDateTime(reservation.rentedFrom);
                DateTime temp2 = Convert.ToDateTime(reservation.rentedTo);
                temp1 = temp1.AddDays(1);
                temp2 = temp2.AddDays(-1);
                pickUpDate.BlackoutDates.Add(new CalendarDateRange(temp1, temp2));
                dropOffDate.BlackoutDates.Add(new CalendarDateRange(temp1, temp2));
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed) DragMove();
        }

        private void PowerButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
            Cars_window.isRentWindowOpened = false;
        }

        private void RentButton_Click(object sender, RoutedEventArgs e)
        {
            string tempPickUpDate = "";
            string tempDropOffDate = "";
            DateTime dropOff;
            DateTime pickUp;
            DateTime currentDate = DateTime.Now;


            try
            {
                pickUp = (DateTime)pickUpDate.SelectedDate;
                tempPickUpDate = pickUp.ToShortDateString();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Please fill in pick-up date!");
                return;

            }

            try
            {
                dropOff = (DateTime)dropOffDate.SelectedDate;
                tempDropOffDate = dropOff.ToShortDateString();
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Please fill in drop-off date!");
                return;
            }
            if (dropOff < pickUp)
            {
                System.Windows.MessageBox.Show("We do not rent cars to time travellers ;)");
                return;
            }
            else if (dropOff == pickUp)
            {
                System.Windows.MessageBox.Show("We do not rent cars for hours.");
                return;
            }

            Reservation reservation = new Reservation(CurrentlyLoggedUser.currentlyLoggedUserId, selectedCar.id, tempPickUpDate, tempDropOffDate);

            if (!ReservationCalendar.CheckIfReservationIsPossible(reservation)) return;

            System.Windows.MessageBox.Show("Reservation is complete!");
            ReservationCalendar.AddNewReservationToList(reservation);
            Cars_window.isRentWindowOpened = false;
            Close();
        }


    }
}
