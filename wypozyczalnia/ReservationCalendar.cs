using account;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace cars
{
    public static class ReservationCalendar
    {
        public static List<Reservation> reservationCalendar;
        public static List<Reservation> pastReservations;

        static ReservationCalendar()
        {
            reservationCalendar = new List<Reservation>();
            pastReservations = new List<Reservation>();
            string filePath = "reservations.txt";
            List<string> fileLines = File.ReadAllLines(filePath).ToList();
            DateTime currentDay = DateTime.Now;

            foreach (var line in fileLines)
            {
                string[] reservationData = line.Split(';');
                DateTime tempDate = Convert.ToDateTime(reservationData[3]);
                Reservation temp = new Reservation();

                temp.borrowerId = Int32.Parse(reservationData[0]);
                temp.carId = Int32.Parse(reservationData[1]);
                temp.rentedFrom = reservationData[2];
                temp.rentedTo = reservationData[3];

                if (tempDate > currentDay)
                { 
                    reservationCalendar.Add(temp);
                }
                else
                {
                   pastReservations.Add(temp);
                }
            }
        }
        public static void LoadReservations() { }

        public static bool CheckIfReservationIsPossible(Reservation res)
        {
            DateTime dropOffToCheck = Convert.ToDateTime(res.rentedTo);
            DateTime pickUpToCheck = Convert.ToDateTime(res.rentedFrom);
            foreach (var reservation in reservationCalendar)
            {
                if (res.carId == reservation.carId)
                {
                    DateTime tempReservationPickUp = Convert.ToDateTime(reservation.rentedFrom);
                    DateTime tempReservationDropOff = Convert.ToDateTime(reservation.rentedTo);
                    if (tempReservationPickUp < dropOffToCheck && pickUpToCheck < tempReservationDropOff)
                    {
                        System.Windows.MessageBox.Show("Car you are trying to rent is not available during selected time range.");
                        return false;
                    }
                }
                else if(CurrentlyLoggedUser.currentlyLoggedUserId == reservation.borrowerId)
                {
                    DateTime tempReservationPickUp = Convert.ToDateTime(reservation.rentedFrom);
                    DateTime tempReservationDropOff = Convert.ToDateTime(reservation.rentedTo);
                    if (tempReservationPickUp < dropOffToCheck && pickUpToCheck < tempReservationDropOff)
                    {
                        System.Windows.MessageBox.Show("You already have another reservation at that time!");
                        return false;
                    }
                }
            }
            return true; 
        }

        public static bool checkIfCarHasNoReservations(int carId)
        {
            foreach(var reservation in reservationCalendar)
            {
                if(reservation.carId==carId)
                {
                    return false;
                }
            }
            return true;
        }

        public static bool checkIfUserHasNoReservations(int userId)
        {
            foreach(var reservation in reservationCalendar)
            {
                if(reservation.borrowerId==userId)
                {
                    return false;
                }
            }
            return true;
        }
        public static List<Reservation> GetSpecificCarReservationCalendar(int carId)
      {
           List<Reservation> temp = new List<Reservation>();
           foreach(var reservation in reservationCalendar)
           {
               if(reservation.carId==carId)
               {
                   temp.Add(reservation);
               }
           }
           return temp;
      }

        public static List<Reservation> GetSpecificUserPastReservations(int userId)
        {
            List<Reservation> temp = new List<Reservation>();
            foreach(var reservation in pastReservations)
            {
                if(reservation.borrowerId==userId)
                {
                    temp.Add(reservation);
                }
            }
            return temp;
        }

        public static void AddNewReservationToList(Reservation res)
        {
            reservationCalendar.Add(res);
        }

        public static void deleteReservationFromList(Reservation res)
        {
            foreach(var reservation in reservationCalendar)
            {
                if (reservation.Equals(res))
                {
                    reservationCalendar.Remove(reservation);
                    return;
                }
            }    
        }

        public static int calculateTotalReservationCost(int carId)
        {
            foreach(var reservation in reservationCalendar)
            {
                if(reservation.carId==carId)
                {
                    DateTime pickUp = Convert.ToDateTime(reservation.rentedFrom);
                    DateTime dropOff = Convert.ToDateTime(reservation.rentedTo);
                    int numberOfRentDays = (dropOff.Date - pickUp.Date).Days;
                    int oneReservationSum = CarList.getSpecificCarRentPrice(reservation.carId) * numberOfRentDays;

                    return oneReservationSum;
                }
            }
            return 0;
        }

        public static void deleteUserPastReservations(int userId)
        {
            List<Reservation> temp = new List<Reservation>();
            foreach(var reservation in pastReservations)
            {
                if(reservation.borrowerId!=userId)
                {
                    temp.Add(reservation);
                }
            }
            pastReservations = temp;
        }

    }
}
