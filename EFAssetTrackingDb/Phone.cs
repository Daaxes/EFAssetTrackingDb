using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssetTrackingDb
{
    internal class Phone
    {
        public Phone()
        {
        }

        public Phone(string brand, string model, string type, int price, DateTime purchaseDate, int officeId)
        {
            Brand = brand;
            Model = model;
            Type = type;
            Price = price;
            PurchaseDate = purchaseDate;
            OfficeId = officeId;
        }

        public Phone(int id, string brand, string model, int price, int officeId, DateTime purchaseDate, string type)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Price = price;
            OfficeId = officeId;
            PurchaseDate = purchaseDate;
            Type = type;
        }

        public int Id { get; set; }
        public int OfficeId { get; set; }
        public string Type { get; set; } // // Type of Mobile, SmartPhone, Home phone, Pad, osv
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public Office Office { get; set; }
    }
}
