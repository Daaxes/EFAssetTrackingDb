﻿using Microsoft.EntityFrameworkCore.Storage.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssetTrackingDb
{
   internal class Asset
    {
        public Asset()
        {
        }

        public Asset(int id, string type, string brand, string model, DateTime purchaseDate, int price)
        {
            Id = id;
            Type = type;
            Brand = brand;
            Model = model;
            PurchaseDate = purchaseDate;
            Price = price;
        }

        public Asset(string brand, string model, string type, int price, DateTime purchaseDate,  int officeId)
        {
            Brand = brand;
            Model = model;
            Type = type;
            Price = price;
            PurchaseDate = purchaseDate;
            OfficeId = officeId;
        }

        public Asset(int warrenty, string computerPhone, int id, string brand, string model, string type, DateTime purchaseDate, int price)
        {
            Warrenty = warrenty;
            ComputerPhone = computerPhone;
            Id = id;
            Brand = brand;
            Model = model;
            Type = type;
            PurchaseDate = purchaseDate;
            Price = price;
        }

        public int Id { get; set; }
//        public int OfficeId { get; set; }
        public string ComputerPhone { get; set; }
        public string Type { get; set; } // // Type of Mobile, SmartPhone, Home phone, Pad, osv
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Price { get; set; }
        public int Warrenty { get; set; }
        public int OfficeId { get; set; }
        public string OfficeName { get; set; }
        public string OfficeCountry { get; set; }
        public string HQName { get; set; }
        public string HQCountry { get; set; }


        //        public Office Office { get; set; }

    }

}
