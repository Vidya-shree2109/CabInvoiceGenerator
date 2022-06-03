using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class RideRepository
    {
        Dictionary<string, List<Ride>> rideDict = null;
        public RideRepository()
        {
            this.rideDict = new Dictionary<string, List<Ride>>();
        }
        public void AddRides(string userId, Ride[] rides)
        {
            bool check = rideDict.ContainsKey(userId);
            try
            {
                if (!check)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    rideDict.Add(userId, list);
                }
            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are Null !");
            }
        }
        public Ride[] GetRide(string userId)
        {
            try
            {
                return this.rideDict[userId].ToArray();
            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_USER_ID, "User Id is Invalid !");
            }
        }
    }
}
