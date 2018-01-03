using System;
using Microsoft.Azure.Mobile.Server;

namespace XDogService.Models
{
    public class Dog : EntityData
    {
        public string MainOwnerId { get; set; }
        public string MainOwnerUserId { get; set; }

        public string PPPath { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Gender { get; set; }
        //public List<string> Interests { get; set; }
        public string Bio { get; set; }
        public DateTime DOB { get; set; }
    }
}

