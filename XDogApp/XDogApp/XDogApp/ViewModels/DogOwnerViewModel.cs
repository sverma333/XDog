﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XDogApp.Models;
using Microsoft.WindowsAzure.MobileServices;
using XDogApp;

using XDogApp.Services;
using XDogApp.Helpers;
using XDogApp.ServiceData;

namespace XDogApp.ViewModels
{
    class DogOwnerViewModel : BaseViewModel
    {
        private IDataStore<BaseId> DataStore = null;

        public ICommand ClickCreate { get; private set; }

        public DogOwnerViewModel()
        {
            //SV initialise backend framework
            DataStore = (IDataStore<BaseId>)DependencyService.Get<DataStore<DogOwner>>() ?? new MockDataStore<DogOwner>();
            DataStore.InitializeAsync();

            this.ScreenName = Settings.ScreenName;
            
            ClickCreate = new Command(async () =>
            {
                DogOwner item = new DogOwner
                {
                    ScreenName = this.ScreenName, FirstName = this.FirstName, Surname = this.Surname, AgeRangeMin = Int32.Parse(this.AgeRangeMin),
                    CurrentTown = this.CurrentTown, HomeTown = this.HomeTown,
                    Bio = this.Bio, RelationshipStatus = this.RelationshipStatus, Job = this.Job, WorkPlace = this.WorkPlace,
                    //Education = new List<string>(new string[] { this.Education }), Address = new List<string>(new string[] { this.Address }),
                    //PostCode = this.PostCode, Country = this.Country, TelphoneNumber = this.TelphoneNumber, MobileNumber = this.MobileNumber,
                    //EmailAddress = this.EmailAddress,
                    DOB = Convert.ToDateTime(this.DOB)
                    //, Dogs = new List<string>(new string[] { this.Dogs }),RelatedDogs = new List<string>(new string[] { this.RelatedDogs })
                };


                bool res = await DataStore.AddItemAsync(item);
                ResponseType = (res ? 1 : 2);
                ResponseText = (res ? "Successfully Saved" : "Failed to Save");

                Settings.ScreenName = this.ScreenName;
            });
        }


        #region Attributes

        public List<string> RelationshipStatusTypes = new List<string>(new string[] { "Single", "Married", "In a Relationship", "It's Complicated" });
        public List<string> InterestTypes = new List<string>(new string[] { "Films", "Books", "Travel", "Sports" });
        public List<string> EducationTypes = new List<string>(new string[] { "High School", "Degree", "Masters", "PhD" });
        public List<string> AgeRanges = new List<string>(new string[] { "-15", "16-21", "22-30", "31-40", "41-50", "51-60", "61+" });


        private string _ScreenName = "";
        public string ScreenName { get { return _ScreenName; } set { if (_ScreenName == value) return; _ScreenName = value; OnPropertyChanged(); }}

        private string _Gender = "";
        public string Gender { get { return _Gender; } set { if (_Gender == value) return; _Gender = value; OnPropertyChanged(); } }

        private string _FirstName = "";
        public string FirstName { get { return _FirstName; } set { if (_FirstName == value) return; _FirstName = value; OnPropertyChanged(); } }

        private string _Surname = "";
        public string Surname { get { return _Surname; } set { if (_Surname == value) return; _Surname = value; OnPropertyChanged(); } }

        private string _AgeRangeMin = "";
        public string AgeRangeMin { get { return _AgeRangeMin; } set { if (_AgeRangeMin == value) return; _AgeRangeMin = value; OnPropertyChanged(); } }

        private string _CurrentTown = "";
        public string CurrentTown { get { return _CurrentTown; } set { if (_CurrentTown == value) return; _CurrentTown = value; OnPropertyChanged(); } }

        private string _HomeTown = "";
        public string HomeTown { get { return _HomeTown; } set { if (_HomeTown == value) return; _HomeTown = value; OnPropertyChanged(); } }

        private string _Interests = "";
        public string Interests { get { return _Interests; } set { if (_Interests == value) return; _Interests = value; OnPropertyChanged(); } }

        private string _Bio = "";
        public string Bio { get { return _Bio; } set { if (_Bio == value) return; _Bio = value; OnPropertyChanged(); } }

        private string _RelationshipStatus = "";
        public string RelationshipStatus { get { return _RelationshipStatus; } set { if (_RelationshipStatus == value) return; _RelationshipStatus = value; OnPropertyChanged(); } }

        private string _Job = "";
        public string Job { get { return _Job; } set { if (_Job == value) return; _Job = value; OnPropertyChanged(); } }

        private string _WorkPlace = "";
        public string WorkPlace { get { return _WorkPlace; } set { if (_WorkPlace == value) return; _WorkPlace = value; OnPropertyChanged(); } }

        private string _Education = "";
        public string Education { get { return _Education; } set { if (_Education == value) return; _Education = value; OnPropertyChanged(); } }

        private string _Address = "";
        public string Address { get { return _Address; } set { if (_Address == value) return; _Address = value; OnPropertyChanged(); } }

        private string _PostCode = "";
        public string PostCode { get { return _PostCode; } set { if (_PostCode == value) return; _PostCode = value; OnPropertyChanged(); } }

        private string _Country = "";
        public string Country { get { return _Country; } set { if (_Country == value) return; _Country = value; OnPropertyChanged(); } }

        private string _TelphoneNumber = "";
        public string TelphoneNumber { get { return _TelphoneNumber; } set { if (_TelphoneNumber == value) return; _TelphoneNumber = value; OnPropertyChanged(); } }

        private string _MobileNumber = "";
        public string MobileNumber { get { return _MobileNumber; } set { if (_MobileNumber == value) return; _MobileNumber = value; OnPropertyChanged(); } }

        private string _EmailAddress = "";
        public string EmailAddress { get { return _EmailAddress; } set { if (_EmailAddress == value) return; _EmailAddress = value; OnPropertyChanged(); } }

        private string _DOB = "";
        public string DOB { get { return _DOB; } set { if (_DOB == value) return; _DOB = value; OnPropertyChanged(); } }

        private string _Dogs = "";
        public string Dogs { get { return _Dogs; } set { if (_Dogs == value) return; _Dogs = value; OnPropertyChanged(); } }

        private string _RelatedDogs = "";
        public string RelatedDogs { get { return _RelatedDogs; } set { if (_RelatedDogs == value) return; _RelatedDogs = value; OnPropertyChanged(); } }

        private string _ResponseText = "";
        public string ResponseText { get { return _ResponseText; } set { if (_ResponseText == value) return; _ResponseText = value; OnPropertyChanged(); } }

        private int _ResponseType = 1;
        public int ResponseType { get { return _ResponseType; } set { if (_ResponseType == value) return; _ResponseType = value; OnPropertyChanged(); } }

        #endregion

    }
}
