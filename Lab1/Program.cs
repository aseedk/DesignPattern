using System;

namespace Lab1
{
    class Customer
    {
        public Customer(string email, string fullName)
        {
            Email = email;
            FullName = fullName;
        }

        public string Email { get; }
        public string FullName { get; }
        public bool visitor { get; set; }
        
        public void sendEmail()
        {
            if (visitor)
            {
                Console.WriteLine("Email Sent Succesfully to " + FullName);
            }
            else
            {
                Console.WriteLine("Email Not sent to " + FullName + " As " + FullName + " is A visior.");
            }
        }
    }

    class VisitingCustomer : Customer
    {
        public VisitingCustomer(string email, string fullName) : base(email, fullName)
        {
            this.visitor = true;
        }
    }

    class PermanentCustomer : Customer
    {
        public PermanentCustomer(string email, string fullName, string phoneNumber) : base(email, fullName)
        {
            PhoneNumber = phoneNumber;
            visitor = false;
        }

        public string PhoneNumber{ get; set; }
    }
    internal class Program
    {
        private static void SendEmail(Customer customer)
        {
            if (customer.GetType() == typeof(VisitingCustomer))
            {
                Console.WriteLine("Email Sent Successfully to " + customer.FullName);
            }
            else
            {
                Console.WriteLine("Email Not sent to " + customer.FullName + " As " + customer.FullName + " is A visitor.");
            }
        }
        public static void Main(string[] args)
        {
            var v1 = new VisitingCustomer("aseedk@hotmail.com", "Aseed Ali Khokhar");
            //v1.sendEmail();
            var p1 = new PermanentCustomer("aseedk@hotmail.com", "Waleed Umar", "6969");
            //p1.sendEmail();
            SendEmail(p1);
            Console.WriteLine();
        }
    }
}