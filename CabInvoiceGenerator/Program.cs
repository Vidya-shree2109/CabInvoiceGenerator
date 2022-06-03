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
            Console.WriteLine("\nEnter :\n1.Display Cab Fare\n2.Display Fare Of Multiple Rides\n3.Stop the Execution\n");
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
                    verify = false;
                    break;
                default: Console.WriteLine("\nEnter Valid Option.. !\n"); break;
            }
        }
    }
}