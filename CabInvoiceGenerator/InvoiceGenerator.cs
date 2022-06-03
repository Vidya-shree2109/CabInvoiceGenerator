using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private readonly int MIN_FAIR;
        private readonly int FAIR_PR_KM;
        private readonly int FAIR_PR_MINUTE;
        RideRepository repository = new RideRepository();
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            try
            {
                if (rideType.Equals(RideType.NORMAL))
                {
                    this.MIN_FAIR = 10;
                    this.FAIR_PR_KM = 15;
                    this.FAIR_PR_MINUTE = 5;
                }
                else if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MIN_FAIR = 5;
                    this.FAIR_PR_KM = 10;
                    this.FAIR_PR_MINUTE = 2;
                }
            }
            catch (InvoiceException)
            {
                throw new InvoiceException(InvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride");
            }
        }
        public double CalculateFair(int distance, int time)
        {
            double calculateFair = 0.0d;
            try
            {
                calculateFair = FAIR_PR_KM * distance + time * FAIR_PR_MINUTE;
            }
            catch (InvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride");
                }
                if (distance == 0)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_DISTANCE, "Please Tell me Valid Distance");
                }
                if (time < 0)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.INVALID_TIME, "Time is invalid");
                }
            }
            return Math.Max(calculateFair, MIN_FAIR);
        }
        public double CalculateMultipleRides(Ride[] rides)
        {
            double result = 0.0d;
            try
            {
                foreach (var data in rides)
                {
                    result += CalculateFair((int)data.distance, (int)data.time);
                }
            }
            catch (InvoiceException)
            {
                if (rides == null)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
            return result / rides.Length;

        }
        public InvoiceSummary CalculateMultipleRidesSummary(Ride[] rides)
        {
            double result = 0.0d;
            try
            {
                foreach (var data in rides)
                {
                    result += CalculateFair((int)data.distance, (int)data.time);
                }
            }
            catch (InvoiceException)
            {
                if (rides == null)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
            return new InvoiceSummary(rides.Length, result);
        }
        public void MapUserId(string usreId, Ride[] rides)
        {
            this.repository.AddRides(usreId, rides);
        }
        public InvoiceSummary GetRideInvoiceSummary(string userId)
        {
            Ride[] result = this.repository.GetRide(userId);
            return CalculateMultipleRidesSummary(result);
        }
        public InvoiceSummary InvoiceSummaryForPremiumRides(Ride[] rides)
        {
            double result = 0.0d;
            try
            {
                foreach (var data in rides)
                {
                    result = CalculateFair((int)data.distance, (int)data.time);
                }
            }
            catch (InvoiceException)
            {
                if (rides == null)
                {
                    throw new InvoiceException(InvoiceException.ExceptionType.NULL_RIDES, "Rides are Null");
                }
            }
            return new InvoiceSummary(rides.Length, result);
        }
    }
}