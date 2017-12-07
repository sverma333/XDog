using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XDogService.Models
{
    public class DogOwner
    {
        public List<string> RelationshipStatusTypes = new List<string>(new string[] { "Single", "Married", "In a Relationship", "It's Complicated" });
        public List<string> InterestTypes = new List<string>(new string[] { "Films", "Books", "Travel", "Sports" });
        public List<string> EducationTypes = new List<string>(new string[] { "High School", "Degree", "Masters", "PhD" });

        public string Id { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public string ScreenName { get; set; }
        public int AgeRangeMin { get; set; }
        public string CurrentTown { get; set; }
        public string HomeTown { get; set; }
        public List<string> Interests { get; set; }
        public string Bio { get; set; }
        public string RelationshipStatus { get; set; }
        public string Job { get; set; }
        public string WorkPlace { get; set; }
        public List<string> Education { get; set; }
        public List<string> Address { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }
        public string TelphoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DOB { get; set; }
        public List<Dog> Dogs { get; set; }
        public List<Dog> RelatedDogs { get; set; }


    }
}