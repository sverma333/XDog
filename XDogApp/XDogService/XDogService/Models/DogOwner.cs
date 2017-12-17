using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Azure.Mobile.Server;

namespace XDogService.Models
{
    public class DogOwner : EntityData
    {
        public string UserId { get; set; }
        public string ScreenName { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int AgeRangeMin { get; set; }
        public string CurrentTown { get; set; }
        public string HomeTown { get; set; }
        //public List<string> Interests { get; set; }
        public string Bio { get; set; }
        public string RelationshipStatus { get; set; }
        public string Job { get; set; }
        public string WorkPlace { get; set; }
        public string Education1 { get; set; }
        public string Education2 { get; set; }
        public string Education3 { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string TelphoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DOB { get; set; }
        //public List<Dog> Dogs { get; set; }
        //public List<Dog> RelatedDogs { get; set; }
    }
}