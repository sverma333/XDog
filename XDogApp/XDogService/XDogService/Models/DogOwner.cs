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
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int AgeRangeMin { get; set; }
        public string CurrentTown { get; set; }
        public string HomeTown { get; set; }
        //public List<string> Interests { get; set; }
        //public List<string> Address { get; set; }
        //public List<string> ContactDetails { get; set; }
        public string Bio { get; set; }
        public string RelationshipStatus { get; set; }
        public string Job { get; set; }
        public string WorkPlace { get; set; }
        public DateTime DOB { get; set; }
        //public List<Dog> Dogs { get; set; }
        //public List<Dog> RelatedDogs { get; set; }
    }
}