using CabInvoiceGenerator;
using NUnit.Framework;

namespace TestCabInvoiceGenerator
{
    public class Tests
    {
        [Test]
        public void GivenDistanceAndTime_SholudReturnFairValue()
        {
            InvoiceGenerator cabInvoice = new InvoiceGenerator(RideType.NORMAL);
            double value = cabInvoice.CalculateFair(15, 5);
            Assert.AreEqual(value, 250);
        }
        [Test]
        public void GivenIntegerInput_ShouldReturn_MultipleRides_TotalFair()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.PREMIER);
            Ride[] rides = { new Ride(2, 3), new Ride(4, 5), new Ride(5, 6) };
            double result = invoice.CalculateMultipleRides(rides);
            Assert.AreEqual(result, 46);
        }
        [Test]
        public void GivenIntegerInput_ShouldReturn_MultipleRides_TotalFair_InvoiceSummary()
        {
            InvoiceGenerator invoice = new InvoiceGenerator(RideType.NORMAL);
            Ride[] rides1 = { new Ride(15, 10), new Ride(35, 35), new Ride(25, 15) };
            InvoiceSummary result = invoice.CalculateMultipleRidesSummary(rides1);
            Assert.AreEqual(result.totalNumberOfRides, 3);
        }
    }
}