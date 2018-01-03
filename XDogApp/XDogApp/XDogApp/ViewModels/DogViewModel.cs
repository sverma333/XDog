using System;
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
using Plugin.Media;
using Plugin.Media.Abstractions;
using XDogApp.Utils;
using Plugin.MediaManager;
using PCLStorage;
using System.IO;

namespace XDogApp.ViewModels
{
    class DogViewModel : BaseViewModel
    {
        private IDataStore<BaseId> DataStore = null;

        public ICommand ClickCreate { get; private set; }
        public ICommand ClickTakePhoto { get; private set; }
        public ICommand ClickPickPhoto { get; private set; }
        public ICommand ClickTakeVideo { get; private set; }
        public ICommand ClickPickVideo { get; private set; }


        public DogViewModel()
        {
            //SV initialise backend framework
            DataStore = (IDataStore<BaseId>)DependencyService.Get<DataStore<Dog>>() ?? new MockDataStore<Dog>();
            DataStore.InitializeAsync();
            Initialize();
            
            ClickCreate = new Command(async () =>
            {
                Dog item = new Dog { Name = this.Name, Breed = this.Breed, Bio = this.Bio, DOB = Convert.ToDateTime(this.DOB) };
                if (MainImageByteArray != null)
                    await FileUtils.SaveToFile("Images", $"DogMainPic_{item.Id}.png", MainImageByteArray);

                bool res = await DataStore.AddItemAsync(item);
                ResponseType = (res ? 1 : 2);
                ResponseText = (res ? "Successfully Saved" : "Failed to Save");

            });

            ClickTakePhoto = new Command(async () =>
            {
                var res = await CameraUtils.TakePhotoAsync();
                ResponseType = res.Item1;
                ResponseText = res.Item3;
                if (ResponseType == 1 && res.Item2 != null)
                {
                   //MainImageByteArray = CameraUtils.StreamToByteArray(res.Item2);
                   MainImageSource = ImageSource.FromStream(() => { return res.Item2; });
                }
            });

            ClickPickPhoto = new Command(async () =>
            {
                var res = await CameraUtils.PickPhotoAsync();
                ResponseType = res.Item1;
                ResponseText = res.Item3;
                if (ResponseType == 1 && res.Item2 != null)
                {
                    MainImageSource = ImageSource.FromStream(() => { return res.Item2; });
                    //MainImageByteArray = CameraUtils.StreamToByteArray(res.Item2);
                }
            });

            ClickTakeVideo = new Command(async () =>
            {
                var res = await CameraUtils.TakeVideoAsync();
                ResponseType = res.Item1;
                ResponseText = res.Item3;
                if (ResponseType == 1)
                {
                    //await CrossMediaManager.Current.Play(mediaFile);
                }

            });

            ClickPickVideo = new Command(async () =>
            {
                var res = await CameraUtils.PickVideoAsync();
                ResponseType = res.Item1;
                ResponseText = res.Item3;
                if (ResponseType == 1)
                {
                    //await CrossMediaManager.Current.Play(mediaFile);
                }
            });

        }

        public void Initialize()
        {
            Task<Stream> tStr = FileUtils.ReadFromFile("Images", $"DogMainPic_.png");
            if (tStr != null || tStr.Result != null)
                MainImageSource = ImageSource.FromStream(() => { return tStr.Result; });
        }

        #region Attributes
        private string _MainOwnerId = "";
        public string MainOwnerId { get { return _MainOwnerId; } set { if (_MainOwnerId == value) return; _MainOwnerId = value; OnPropertyChenged(); } }

        private string _MainOwnerUserId = "";
        public string MainOwnerUserId { get { return _MainOwnerUserId; } set { if (_MainOwnerUserId == value) return; _MainOwnerUserId = value; OnPropertyChenged(); } }

        private string _Name = "";
        public string Name { get { return _Name; } set { if (_Name == value) return; _Name = value; OnPropertyChenged(); }}

        private string _Breed = "";
        public string Breed { get { return _Breed; } set { if (_Breed == value) return; _Breed = value; OnPropertyChenged(); }}

        private string _Gender = "";
        public string Gender { get { return _Gender; } set { if (_Gender == value) return; _Gender = value; OnPropertyChenged(); } }

        private string _Interests = "";
        public string Interests { get { return _Interests; } set { if (_Interests == value) return; _Interests = value; OnPropertyChenged(); } }

        private string _Bio = "";
        public string Bio { get { return _Bio; } set { if (_Bio == value) return; _Bio = value; OnPropertyChenged(); } }


        private string _DOB = "";
        public string DOB { get { return _DOB; } set { if (_DOB == value) return; _DOB = value; OnPropertyChenged(); } }

        private ImageSource _MainImageSource;
        public ImageSource MainImageSource { get { return _MainImageSource; } set { if (_MainImageSource == value) return; _MainImageSource = value; OnPropertyChenged(); } }

        private byte[] _MainImageByteArray = null;
        public byte[] MainImageByteArray { get { return _MainImageByteArray; } set { if (_MainImageByteArray == value) return; _MainImageByteArray = value; OnPropertyChenged(); } }

        private string _ResponseText = "";
        public string ResponseText { get { return _ResponseText; } set { if (_ResponseText == value) return; _ResponseText = value; OnPropertyChenged(); } }

        private int _ResponseType = 1;
        public int ResponseType { get { return _ResponseType; } set { if (_ResponseType == value) return; _ResponseType = value; OnPropertyChenged(); } }

        #endregion

    }
}
