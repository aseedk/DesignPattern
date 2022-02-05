using System;

namespace LabAssignment1
{
    internal enum MobileManufacturer
    {
        Iphone = 1,
        Xiaomi = 2,
        Samsung = 3 
    }
    internal enum SamsungMobilePhones
    {
        SamsungGalaxyZFold3 = 1,
        SamsungGalaxyZFold2 = 2,
        SamsungGalaxyZFlip = 3 
    }
    internal enum XiaomiMobilePhones
    {
        XiaomiMi10 = 1,
        XiaomiMi11 = 2,
        XiaomiPocophoneF2Pro = 3 
    }
    internal enum AppleMobilePhones
    {
        AppleiPhone12ProMax = 1,
        AppleiPhone11ProMax= 2,
        AppleiPhone12Pro = 3 
    }
    internal interface ISmartPhone  
    {  
        string GetModelDetails();  
    }

    internal interface IWhatMobile
    {
        ISmartPhone GetFactory(MobileManufacturer manufacturer, int mobileProduct);
    }

    internal class XiaomiMi10 : ISmartPhone  
    {  
        public string GetModelDetails()  
        {  
            return "Model: Xiaomi MI 10\n";  
        }  
    }
    internal class XiaomiMi11 : ISmartPhone  
    {  
        public string GetModelDetails()  
        {  
            return "Model: Xiaomi MI 11\n";  
        }  
    }
    internal class XiaomiMiPocophoneF2Pro : ISmartPhone  
    {  
        public string GetModelDetails()  
        {  
            return "Model: Xiaomi MI Pocophone F2 Pro\n";  
        }  
    }
    internal class Iphone12MaxPro : ISmartPhone  
    {  
        public string GetModelDetails()  
        {  
            return "Model: Iphone 12 Max Pro\n";  
        }  
    }
    internal class Iphone11MaxPro : ISmartPhone  
    {  
        public string GetModelDetails()  
        {  
            return "Model: Iphone 11 Max Pro\n";  
        }  
    }
    internal class Iphone12Pro : ISmartPhone  
    {  
        public string GetModelDetails()  
        {  
            return "Model: Iphone 12 Pro\n";  
        }  
    }
    internal class SamsungGalaxyZFold3 : ISmartPhone  
    {  
        public string GetModelDetails()  
        {  
            return "Model: Samsung Galaxy Z Fold 3\n";  
        }  
    }
    internal class SamsungGalaxyZFold2 : ISmartPhone  
    {  
        public string GetModelDetails()  
        {  
            return "Model: Samsung Galaxy Z Fold 2\n";  
        }  
    }
    internal class SamsungGalaxyZFlip : ISmartPhone  
    { 
        public string GetModelDetails()  
        {  
            return "Model: Samsung Galaxy Z Flip\n";  
        }  
    }
    internal class IphoneFactory
    {
        public static ISmartPhone GetSmartPhone(AppleMobilePhones manufacturer)
        {
            switch (manufacturer)
            {
                case AppleMobilePhones.AppleiPhone12ProMax:
                    return new Iphone12MaxPro();
                case AppleMobilePhones.AppleiPhone11ProMax:
                    return new Iphone11MaxPro();
                case AppleMobilePhones.AppleiPhone12Pro:
                    return new Iphone12Pro();
                default:
                    throw new ArgumentOutOfRangeException(nameof(manufacturer), manufacturer, null);
            }
        }
    }
    internal class XiaomiFactory
    {
        public static ISmartPhone GetSmartPhone(XiaomiMobilePhones manufacturer)
        {
            switch (manufacturer)
            {
                case XiaomiMobilePhones.XiaomiMi11:
                    return new XiaomiMi11();
                case XiaomiMobilePhones.XiaomiMi10:
                    return new XiaomiMi10();
                case XiaomiMobilePhones.XiaomiPocophoneF2Pro:
                    return new XiaomiMiPocophoneF2Pro();
                default:
                    throw new ArgumentOutOfRangeException(nameof(manufacturer), manufacturer, null);
            }
        }
    }
    internal class SamsungFactory
    {
        public static ISmartPhone GetSmartPhone(SamsungMobilePhones manufacturer)
        {
            switch (manufacturer)
            {
                case SamsungMobilePhones.SamsungGalaxyZFold3:
                    return new SamsungGalaxyZFold3();
                case SamsungMobilePhones.SamsungGalaxyZFold2:
                    return new SamsungGalaxyZFold2();
                case SamsungMobilePhones.SamsungGalaxyZFlip:
                    return new SamsungGalaxyZFlip();
                default:
                    throw new ArgumentOutOfRangeException(nameof(manufacturer), manufacturer, null);
            }
        }
    }
    internal class WhatMobileFactory: IWhatMobile
    {
        public ISmartPhone GetFactory(MobileManufacturer manufacturer, int mobileProduct)
        {
            switch (manufacturer)
            {
                case MobileManufacturer.Iphone:
                    return IphoneFactory.GetSmartPhone((AppleMobilePhones) mobileProduct);
                case MobileManufacturer.Xiaomi:
                    return XiaomiFactory.GetSmartPhone((XiaomiMobilePhones) mobileProduct);
                case MobileManufacturer.Samsung:
                    return SamsungFactory.GetSmartPhone((SamsungMobilePhones) mobileProduct);
                default:
                    throw new ArgumentOutOfRangeException(nameof(manufacturer), manufacturer, null);
            }
        }
    }
    internal class Client
    {
        private readonly ISmartPhone _smartPhone;

        public Client(IWhatMobile factory, MobileManufacturer manufacturer, int mobileProduct)
        {
            _smartPhone = factory.GetFactory(manufacturer, mobileProduct);
        }

        public string GetSmartPhoneDetails()
        {
            return _smartPhone.GetModelDetails();
        }
    }
    internal static class Program
    {
        public static void Main(string[] args)
        {
            IWhatMobile whatMobileFactory = new WhatMobileFactory();
            Console.WriteLine("********* Iphone **********");  
            var iphoneClient = new Client(whatMobileFactory,MobileManufacturer.Iphone, (int) AppleMobilePhones.AppleiPhone12ProMax);
            Console.WriteLine(iphoneClient.GetSmartPhoneDetails());
            iphoneClient = new Client(whatMobileFactory,MobileManufacturer.Iphone, (int) AppleMobilePhones.AppleiPhone11ProMax);
            Console.WriteLine(iphoneClient.GetSmartPhoneDetails());
            iphoneClient = new Client(whatMobileFactory,MobileManufacturer.Iphone, (int) AppleMobilePhones.AppleiPhone12Pro);
            Console.WriteLine(iphoneClient.GetSmartPhoneDetails());
            
            Console.WriteLine("******* Xiaomi **********");  
            var xiaomiClient = new Client(whatMobileFactory, MobileManufacturer.Xiaomi, (int) XiaomiMobilePhones.XiaomiMi11);
            Console.WriteLine(xiaomiClient.GetSmartPhoneDetails());
            xiaomiClient = new Client(whatMobileFactory, MobileManufacturer.Xiaomi, (int) XiaomiMobilePhones.XiaomiMi10);
            Console.WriteLine(xiaomiClient.GetSmartPhoneDetails());
            xiaomiClient = new Client(whatMobileFactory, MobileManufacturer.Xiaomi, (int) XiaomiMobilePhones.XiaomiPocophoneF2Pro);
            Console.WriteLine(xiaomiClient.GetSmartPhoneDetails());


            Console.WriteLine("******* Samsung **********");  
            var samsungClient = new Client(whatMobileFactory, MobileManufacturer.Samsung, (int) SamsungMobilePhones.SamsungGalaxyZFold3);
            Console.WriteLine(samsungClient.GetSmartPhoneDetails());
            samsungClient = new Client(whatMobileFactory, MobileManufacturer.Samsung, (int) SamsungMobilePhones.SamsungGalaxyZFold2);
            Console.WriteLine(samsungClient.GetSmartPhoneDetails());  
            samsungClient = new Client(whatMobileFactory, MobileManufacturer.Samsung, (int) SamsungMobilePhones.SamsungGalaxyZFlip);
            Console.WriteLine(samsungClient.GetSmartPhoneDetails());  
            Console.ReadKey();
        }
    }
}