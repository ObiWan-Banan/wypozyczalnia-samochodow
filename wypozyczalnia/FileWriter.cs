using cars;
using account;
using System.Collections.Generic;
using System;
using System.IO;

namespace wypozyczalnia
{
   
    public static class FileWriter
    {
        public static bool programEndedWithException = false;
        public static void GenerateSpecificUserSummary(int userID)
        {
            List<Reservation> userPastReservations = ReservationCalendar.GetSpecificUserPastReservations(userID);

            List<string> output = new List<string>();
            string currentlyLoggedUsername = CurrentlyLoggedUser.GetSpecificUserUsername();
            string filePath = $"{currentlyLoggedUsername}Summary.txt";
            string firstLine = $"Reservation summary for client {currentlyLoggedUsername}:";
            output.Add(firstLine);
            int totalSpentSum = 0;
            int totalRentDays = 0;

            foreach(var reservation in userPastReservations)
            {
                DateTime pickUp = Convert.ToDateTime(reservation.rentedFrom);
                DateTime dropOff = Convert.ToDateTime(reservation.rentedTo);
                int numberOfRentDays = (dropOff.Date - pickUp.Date).Days;
                int oneReservationSum = CarList.getSpecificCarRentPrice(reservation.carId) * numberOfRentDays;
                totalSpentSum += oneReservationSum;
                totalRentDays += numberOfRentDays;

                output.Add($"Car {CarList.getSpecificCarName(reservation.carId)} rented from {reservation.rentedFrom} to {reservation.rentedTo} ({numberOfRentDays} days)" +
                    $" for total of {oneReservationSum}PLN");
            }
            string lastLine = $"Total sum spent: {totalSpentSum}PLN, total rent days: {totalRentDays}";
            output.Add(lastLine);
            File.WriteAllLines(filePath, output);
        }
        public static void UpdateReservationCalendarFile()
        {
                string filePath = "reservations.txt";
                List<string> output = new List<string>();
                foreach(var reservation in ReservationCalendar.pastReservations)
                {
                    output.Add($"{reservation.borrowerId};{reservation.carId};{reservation.rentedFrom};{reservation.rentedTo}");
                }
                foreach(var reservation in ReservationCalendar.reservationCalendar)
                {
                    output.Add($"{reservation.borrowerId};{reservation.carId};{reservation.rentedFrom};{reservation.rentedTo}");
                }
                File.WriteAllLines(filePath, output);
            
        }
        public static void UpdateUserListFile()
        {
                string filePath = "users.txt";
                List<string> output = new List<string>();
                foreach(User user in UserList.userList)
                {
                    output.Add($"{user.id};{user.username};{user.password};{user.birthday}");
                }
                File.WriteAllLines(filePath, output);
        }

        public static void UpdateCarListFile()
        {
           
                string filePath = "cars.txt";
                List<string> output = new List<string>();
                foreach(var car in CarList.carList)
                {
                    output.Add($"{car.id};{car.name};{car.imageFilePath};{car.productionYear};{car.horsepower};{car.gearbox};{car.bodyType};{car.fuelType};" +
                        $"{car.rentPrice}");
                }
                File.WriteAllLines(filePath, output);
            
        }
        public static void UpdateDeletedCarListFile()
        {
            
                string filePath = "deletedCars.txt";
                List<string> output = new List<string>();
                foreach (var car in CarList.deletedCarList)
                {
                    output.Add($"{car.id};{car.name};{car.imageFilePath};{car.productionYear};{car.horsepower};{car.gearbox};{car.bodyType};{car.fuelType};" +
                        $"{car.rentPrice}");
                }
                File.WriteAllLines(filePath, output);
            
        }
    }
}
