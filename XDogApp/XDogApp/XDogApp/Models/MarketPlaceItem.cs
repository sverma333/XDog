using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XDogApp.ServiceData;

namespace XDogApp.Models
{
    public class MarketPlaceItem : BaseId
    {
        public string Description { get; set; }
        public string OwnerId { get; set; }
        public string Currency { get; set; }
        public double Price { get; set; }
    }
}
