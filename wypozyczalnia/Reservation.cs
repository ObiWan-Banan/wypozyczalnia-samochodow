using account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cars
{
    public class Reservation
    {
        public int borrowerId { get; set; }
        public int carId { get; set; }
        public string rentedFrom { get; set; }
        public string rentedTo { get; set; }

        public Reservation(int userId=0,int carId_=0,string dateFrom="",string dateTo="")
        {
            borrowerId = userId;
            carId = carId_;
            rentedFrom = dateFrom;
            rentedTo = dateTo;
        }


        public override bool Equals(Object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Reservation r = (Reservation)obj;
                return (carId == r.carId) && (borrowerId == r.borrowerId) && (rentedFrom == r.rentedFrom) && (rentedTo == r.rentedTo);
            }
        }

    }
}
