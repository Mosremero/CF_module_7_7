using System;

namespace CF_module_7_7
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderStruct OrderStruct;
            OrderStruct.weight = 25.10;
            OrderStruct.height = 20.05;
            OrderStruct.price = 35.75;

            Order<HomeDelivery, OrderStruct> order = new(new HomeDelivery(5, 3) , new OrderStruct(35.16, 25.14, 46.46));

            Console.WriteLine(order.Description);
        }
    }

    abstract class Delivery
    {

        public string Address;
        public abstract byte CountryNum { get; set; }

    }

    enum ECountryNum : byte
    {
         Russia = 1,
         England = 2,
         USA = 3
    }
    class HomeDelivery: Delivery
    {
        public int CourierNum { get; set; }
        public int AutoNum
        {
            get
            {
                return AutoNum;
            }
            set
            {
                AutoNum = value;
            }
        }

        /// <summary>
        /// зона покрытия
        /// </summary>
        public string CoverageArea { get; set; }
        public override byte CountryNum
        {
            get
            {
                return CountryNum;
            }
            set => CountryNum = (byte)ECountryNum.Russia;
        }
        public HomeDelivery (int AutoNum, int CourierNum)
        {
            this.AutoNum = AutoNum;
            this.CourierNum = CourierNum;
        }
    }
    class PickPointDelivery: Delivery
    {
        public override byte CountryNum
        {
            get
            {
                return CountryNum;
            }
            set => CountryNum = (byte)ECountryNum.USA;
        }
        public int PickPointID { get; set; }
        public string PickSaveType {
            get
            {
                return PickSaveType;
            }
            set
            {
                PickSaveType = SetSaveType(PickPointID);
            }
        }
        public PickPointDelivery(int PickPointID)
        {
            this.PickPointID = PickPointID;
        }
        static string SetSaveType (int PickPointID)
        {
            if (PickPointID <= 1000)
            {
                return "BoxType";
            }
            {
                return "BigBoxTYpe";
            }
        }
    }
    class ShopDelivery: Delivery
    {
        public override byte CountryNum
        {
            get
            {
                return CountryNum;
            }
            set => CountryNum = (byte)ECountryNum.England;
        }
        public string regularity_of_delivery { get; set; }

    }

    /// <summary>
    /// глобальная доставка (заказ является ее частью)
    /// </summary>
    class GlobalSupply
    {
        public int GlobalOrderNum;
        public void ChangeGlobalSupply(int newGlobalSupply)
        {
            GlobalOrderNum = newGlobalSupply;
        }
    }

    /// <summary>
    /// условия перевозки
    /// </summary>
    class ConditionsOfCarriage
    {
        public int maxTemp;
        public int minTemp;
        public string Description;
    }

    /// <summary>
    /// характеристики товара
    /// </summary>
    struct OrderStruct
    {
        public double weight;
        public double height;
        public double price;

        public OrderStruct(double weight, double height, double price)
        {
            this.weight = weight;
            this.height = height;
            this.price = price;
        }
    }

    class CompanyInfo
    {
        public string CompanyDescription;
        public string Address;
        public string MobilePhone;
        public string Fax;

        public string Director;

        public CompanyInfo (string CompanyDescription, string Address, string MobilePhone, string Fax, string Director)
        {
            this.CompanyDescription = CompanyDescription;
            this.Address = Address;
            this.MobilePhone = MobilePhone;
            this.Fax = Fax;
            this.Director = Director;
        }
        public CompanyInfo()
        {
            CompanyDescription = "Не известно";
            Director = "Не известен";
        }
    }

    class Order <TDelivery, TStruct> where TDelivery: Delivery
    {
        public TDelivery Delivery;
        public TStruct Struct;
        private readonly CompanyInfo Company;

        private GlobalSupply globalSupply;
        private ConditionsOfCarriage Condition;

        public int Number;
        
        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        public void DisplayGlobalSupply()
        {
            Console.WriteLine(globalSupply.GlobalOrderNum);
        }

        public Order(TDelivery Delivery, TStruct Struct)
        {
            this.Delivery = Delivery;
            this.Struct = Struct;

            globalSupply = new GlobalSupply();
            Condition = new ConditionsOfCarriage();
        }

        public Order(TDelivery Delivery, TStruct Struct, CompanyInfo Company)
        {
            this.Delivery = Delivery;
            this.Struct = Struct;
            this.Company = Company;

            globalSupply = new GlobalSupply();
            Condition = new ConditionsOfCarriage();
        }
    }
}
