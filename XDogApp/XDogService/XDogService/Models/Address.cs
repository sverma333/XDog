using System;
using Microsoft.Azure.Mobile.Server;

namespace XDogService.Models
{
    public class Address : EntityData
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }

        public string Town { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
    }
}

