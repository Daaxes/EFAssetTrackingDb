using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssetTrackingDb
{
    internal class Computer
    {
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
