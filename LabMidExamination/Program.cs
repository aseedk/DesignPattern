/*
    Name: Aseed Ali Khokhar
    Registeration No: FA18-BSE-015
    Class: BSSE-7A
    Design Pattern Mid Lab Examination
*/


using System;

namespace LabMidExamination
{
    enum ComputerType
    {
        Desktop,
        Laptop
    }
    public interface IBuilder
    {
        void SetType(int type);
        void SetProcessor(int processor);
        void SetRam(int ram);
        void SetHardDisk(int hardDisk);
    }
    public class ComputerBuilder : IBuilder
    {
        private ComputerSystem _product = new ComputerSystem();
        public ComputerBuilder()
        {
            Reset();
        }
        public void SetType(int type)
        {
            _product.Type = type;
        }

        public void SetProcessor(int processor)
        {
            _product.Processor = processor;
        }

        public void SetRam(int ram)
        {
            _product.Ram = ram;
        }

        public void SetHardDisk(int hardDisk)
        {
            _product.HardDisk = hardDisk;
        }

        private void Reset()
        {
            _product = new ComputerSystem();
        }
        
        public ComputerSystem GetProduct()
        {
            var result = _product;
            Reset();
            return result;
        }
    }

    public class ComputerSystem
    {
        public int Type { get; set; }
        public int Processor { get; set; }
        public int Ram { get; set; }
        public int HardDisk { get; set; }

        public override string ToString()
        {
            var objectDetails = $" Type: {Type}\n Processor: {Processor}\n Ram: {Ram}\n Hard Disk: {HardDisk}";
            return objectDetails;
        }
    }
    internal static class Program
    {
        public static void Main(string[] args)
        {
            var computerBuilder = new ComputerBuilder();
            computerBuilder.SetType((int)ComputerType.Desktop);
            computerBuilder.SetProcessor(8);
            computerBuilder.SetRam(16);
            computerBuilder.SetHardDisk(1000);
            var computerObject = computerBuilder.GetProduct();
            Console.WriteLine(computerObject);
        }
    }
}