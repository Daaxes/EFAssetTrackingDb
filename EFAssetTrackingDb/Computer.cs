using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssetTrackingDb
{
    internal class Computer
    {
        public Computer()
        {
        }

        public Computer(string brand, string model, string type, int price, DateTime purchaseDate, int officeId)
        {
            Brand = brand;
            Model = model;
            Type = type;
            Price = price;
            PurchaseDate = purchaseDate;
            OfficeId = officeId;
        }

        //public Computer(int id, int officeId, string type, string brand, string model, DateTime purchaseDate, int price, Office office)
        //{
        //    Id = id;
        //    OfficeId = officeId;
        //    Type = type;
        //    Brand = brand;
        //    Model = model;
        //    PurchaseDate = purchaseDate;
        //    Price = price;
        //    Office = office;
        //}

        public int Id { get; set; }
        public int OfficeId { get; set; }
        public string Type { get; set; } // Type of Computer, Laptop, Desktop, osv
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public Office Office { get; set; }
    }
}
