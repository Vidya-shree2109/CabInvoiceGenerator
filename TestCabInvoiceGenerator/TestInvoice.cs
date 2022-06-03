using CabInvoiceGenerator;
using NUnit.Framework;

namespace TestCabInvoiceGenerator
{
    public class Tests
    {
        [Test]
        public void GivenDistanceAndTime_SholudReturnFairValue()
        {
            InvoiceGenerator cabInvoice = new InvoiceGenerator();
            double value = cabInvoice.CalculateFair(3,10);
            Assert.AreEqual(40, value);
        }
    }
}