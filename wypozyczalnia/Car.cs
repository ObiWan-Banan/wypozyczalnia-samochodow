using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace cars
{
    public enum gearbox { Manual, Automatic };
    public enum bodyType { Sedan, Estate, SUV, Hatchback, Coupe, Roadster };
    public enum fuelType { PB, ON, Electric };

    
    public class Car
    {
        public int id { get; set; }
        public string name { get; set; }
        public string imageFilePath { get; set; }
        public int productionYear { get; set; }
        public int horsepower { get; set; }
        public gearbox gearbox { get; set; }
        public bodyType bodyType { get; set; }
        public fuelType fuelType { get; set; }
        public int rentPrice { get; set; }

        public Car() { }


        

    }
}
