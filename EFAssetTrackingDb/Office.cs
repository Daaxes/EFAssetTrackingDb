using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssetTrackingDb
{
    internal class Office
    {
        public int Id { get; set; }
        public int HQId { get; set; }
        public string OfficeName { get; set; }
        public string OfficeCountry {  get; set; }
        public List<Phone> PhoneList { get; set;}
        public List<Computer> ComputerList { get; set;}
    }
}
