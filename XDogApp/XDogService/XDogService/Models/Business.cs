using System;
using Microsoft.Azure.Mobile.Server;

namespace XDogService.Models
{
    public class Business : EntityData
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Bio { get; set; }
        public string OpeningTimes { get; set; }
        public DateTime DOB { get; set; }
    }
}

