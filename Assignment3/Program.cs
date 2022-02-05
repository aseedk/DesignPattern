using System.Collections.Generic;

namespace Assignment3
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            ICustomer customer = new CompositeCustomer("Aseed");
            customer.TotalProfit = 2.0;
            customer.GetDetails();
            customer.GetProfit(40);
            customer.SellProduct();
        }
    }
    internal interface ICustomer{
        ICustomer Parent{ get; set; }
        double TotalProfit{ get; set; }
        string FullName{ get; set; }
        void SellProduct();
        string GetDetails();
        void GetProfit(double profit);
    }
    
    internal abstract class Customer : ICustomer{
        public ICustomer Parent{ get; set; }
        public double TotalProfit{ get; set; }
        public string FullName{ get; set; }

        public void SellProduct(){
            var sellPrice = 100;
            GetProfit(sellPrice);
        }

        public string GetDetails(){
            return FullName + " has profit " + TotalProfit;
        }

        public void GetProfit(double profit){
            TotalProfit += profit * 90/100;
            if (Parent != null){
                Parent.GetProfit(profit * 10/100);
            }else{
                TotalProfit += profit * 10/100;
            }
        }
    }

    internal class CompositeCustomer : Customer{
        private List<ICustomer> children;

        public CompositeCustomer(string name){
            this.FullName = name;
            children = new List<ICustomer>();
        }

        public void AddChildCustomer(ICustomer newChild){
            children.Add(newChild);
            newChild.Parent = this;
        }
    }

    internal class LeafCustomer : Customer{
        public LeafCustomer(string name){
            this.FullName = name;
        }
    }
}