using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars
{
    public static class CarList
    {
        public static List<Car> carList;
        public static List<Car> deletedCarList;

        static CarList()
        {
            carList = new List<Car>();
            string filePath = "cars.txt";
            List<string> fileLines = File.ReadAllLines(filePath).ToList();

            foreach(var line in fileLines)
            {
                string[] carData = line.Split(';');
                Car temp = new Car();

                temp.id = Int32.Parse(carData[0]);
                temp.name = carData[1];
                temp.imageFilePath = carData[2];
                temp.productionYear = Int32.Parse(carData[3]);
                temp.horsepower = Int32.Parse(carData[4]);
                temp.gearbox = (gearbox)Enum.Parse(typeof(gearbox),carData[5]);
                temp.bodyType = (bodyType)Enum.Parse(typeof(bodyType), carData[6]);
                temp.fuelType = (fuelType)Enum.Parse(typeof(fuelType), carData[7]);
                temp.rentPrice = Int32.Parse(carData[8]);

                carList.Add(temp);
            }
            initializeDeletedCarList();
        }
        public static void initializeCarList() { } 
        
        public static void initializeDeletedCarList()
        {
            deletedCarList = new List<Car>();
            string filePath = "deletedCars.txt";
            List<string> fileLines = File.ReadAllLines(filePath).ToList();

            foreach (var line in fileLines)
            {
                string[] carData = line.Split(';');
                Car temp = new Car();

                temp.id = Int32.Parse(carData[0]);
                temp.name = carData[1];
                temp.imageFilePath = carData[2];
                temp.productionYear = Int32.Parse(carData[3]);
                temp.horsepower = Int32.Parse(carData[4]);
                temp.gearbox = (gearbox)Enum.Parse(typeof(gearbox), carData[5]);
                temp.bodyType = (bodyType)Enum.Parse(typeof(bodyType), carData[6]);
                temp.fuelType = (fuelType)Enum.Parse(typeof(fuelType), carData[7]);
                temp.rentPrice = Int32.Parse(carData[8]);

                deletedCarList.Add(temp);
            }
        }

        public static string getSpecificCarName(int carId)
        {
            foreach(var car in carList)
            {
                if(car.id==carId)
                {
                    return car.name;
                }
            }
            foreach(var car in deletedCarList)
            {
                if (car.id == carId)
                {
                    return car.name;
                }
            }
            return null;
        }
        public static int getSpecificCarRentPrice(int carId)
        {
            foreach (var car in carList)
            {
                if (car.id == carId)
                {
                    return car.rentPrice;
                }
            }
            foreach (var car in deletedCarList)
            {
                if (car.id == carId)
                {
                    return car.rentPrice;
                }
            }
            return 0;
        }

        public static string getSpecificCarImage(int carId)
        {
            foreach(var car in carList)
            {
                if(car.id==carId)
                {
                    return car.imageFilePath;
                }
            }
            return null;
        }

        public static void AddNewCarToList(Car car)
        {
            carList.Add(car);
        }

        public static void deleteCarFromList(int carId)
        {
            foreach(var car in carList)
            {
                if(car.id==carId)
                {
                    deletedCarList.Add(car);
                    carList.Remove(car);
                    return;
                }
            }
        }

        public static int getMaxIdFromBothLists()
        {
            int max = 1;

            foreach(var car in carList)
            {
                if(car.id>max)
                {
                    max = car.id;
                }
            }
            foreach (var car in deletedCarList)
            {
                if (car.id > max)
                {
                    max = car.id;
                }
            }
            return max;
        }

    }
}
