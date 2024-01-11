using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAssetTrackingDb
{
    internal class HQ
    {
        public int Id { get; set; }
        public string HQName { get; set; }
        public string HQCountry { get; set; }
        public List<Office> Office { get; set; }
    }
}
