using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceSummary
    {
        public int totalNumberOfRides;
        public double totalFair;
        public double averageFair;
        public InvoiceSummary(int totalNumberOfRides, double totalFair)
        {
            this.totalNumberOfRides = totalNumberOfRides;
            this.totalFair = totalFair;
            this.averageFair = this.totalFair / this.totalNumberOfRides;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) ; return false;
            if (!(obj is InvoiceSummary)) return false;
            InvoiceSummary inputesObject = (InvoiceSummary)obj;
            return this.totalNumberOfRides == inputesObject.totalNumberOfRides && this.totalFair == inputesObject.averageFair && this.averageFair == inputesObject.averageFair;
        }
        public override int GetHashCode()
        {
            return this.totalNumberOfRides.GetHashCode() ^ this.totalFair.GetHashCode() ^ this.averageFair.GetHashCode();
        }
    }
}
