using CabInvoiceGenerator;
using System;
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\t\t\t\t\tWELCOME TO CAB INVOICE GENERATOR PROGRAM\t\t\t\t\t\n");
        bool verify = true;
        while (verify)
        {
            Console.WriteLine("\nEnter :\n1.Display Cab Fare\n2.Display Fare Of Multiple Rides\n3.Display Invoice Summary\n4.Invoice Summary Given the User id\n5.Stop the Execution\n");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    InvoiceGenerator generator = new InvoiceGenerator(RideType.NORMAL);
                    double result = generator.CalculateFair(15, 5);
                    Console.WriteLine("Result = " + result);
                    break;
                case 2:
                    InvoiceGenerator invoice = new InvoiceGenerator(RideType.PREMIER);
                    Ride[] rides = { new Ride(15, 5), new Ride(25, 10), new Ride(20, 20) };
                    double result1 = invoice.CalculateMultipleRides(rides);
                    Console.WriteLine("Result is:->" + result1);
                    break;
                case 3:
                    InvoiceGenerator cabInvoice = new InvoiceGenerator(RideType.NORMAL);
                    Ride[] rides1 = { new Ride(15, 10), new Ride(35, 35), new Ride(25, 15), new Ride(15, 15), new Ride(50, 60) };
                    InvoiceSummary results = cabInvoice.CalculateMultipleRidesSummary(rides1);
                    Console.WriteLine("Total Number Of Rides = " + results.totalNumberOfRides + "\n" + "Total Cab Fare = " + results.totalFair + "\n" + "Average Cab Fare = " + results.averageFair);
                    break;
                case 4:
                    InvoiceGenerator invoiceSummary = new InvoiceGenerator(RideType.NORMAL);
                    Ride[] ride = { new Ride(15, 10), new Ride(35, 35), new Ride(25, 15), new Ride(15, 15), new Ride(50, 60) };
                    string userId = "1005abc";
                    invoiceSummary.MapUserId(userId, ride);
                    InvoiceSummary summary = invoiceSummary.GetRideInvoiceSummary("1005abc");
                    Console.WriteLine("Total Number of Rides = " + summary.totalNumberOfRides + "\n" + "Total Fare = " + summary.totalFair + "\n" + "Average Fare = " + summary.averageFair);
                    break;
                case 5:
                    verify = false;
                    break;
                default: Console.WriteLine("\nEnter Valid Option.. !\n"); break;
            }
        }
    }
}