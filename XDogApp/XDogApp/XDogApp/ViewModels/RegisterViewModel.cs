﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XDogApp.Models;

namespace XDogApp.ViewModels
{
    class RegisterViewModel : BaseViewModel
    {

        public ICommand ClickVerification { get; private set; }
        public ICommand ClickRegister { get; private set; }

        public RegisterViewModel()
        {
            ClickVerification = new Command(() =>
            {
                Tuple<bool, string> res = GetVerificationResponse(Email);
                ResponseType = (res.Item1 ? 1 : 2);
                ResponseText = res.Item2;
            }) ;

            ClickRegister = new Command(() =>
            {
                Tuple<bool, string> res = GetRegResponse(Email, VerficationCode, Password, ConfirmPassword);
                ResponseType = (res.Item1 ? 1 : 2);
                ResponseText = res.Item2;
            });
        }


        #region Attributes
        private string _Email = "";
        public string Email
        {
            get { return _Email; }
            set
            {
                if (_Email == value) return;
                _Email = value; 
                OnPropertyChenged();
            }
        }


        private string _VerficationCode = "";
        public string VerficationCode
        {
            get { return _VerficationCode; }
            set
            {
                if (_VerficationCode == value) return;
                _VerficationCode = value;
                OnPropertyChenged();
            }
        }

        private string _Password = "";
        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password == value) return;
                _Password = value;
                OnPropertyChenged();
            }
        }

        private string _ConfirmPassword = "";
        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set
            {
                if (_ConfirmPassword == value) return;
                _ConfirmPassword = value;
                OnPropertyChenged();
            }
        }

        private string _ResponseText = "Please Register";
        public string ResponseText
        {
            get { return _ResponseText; }
            set
            {
                if (_ResponseText == value) return;
                _ResponseText = value;
                OnPropertyChenged();
            }
        }

        private int _ResponseType = 1;
        public int ResponseType
        {
            get { return _ResponseType; }
            set
            {
                if (_ResponseType == value) return;
                _ResponseType = value;
                OnPropertyChenged();
            }
        }

        #endregion


        public Tuple<bool, string> GetRegResponse(string email, string verificationCode, string password, string confirmPassword)
        {
            Tuple<bool, string> res = null;

            RegisterUser u = new RegisterUser(email, verificationCode, password, confirmPassword);

            if (u.IsValid())
                res = new Tuple<bool, string>(true, "Registration has been successful.");
            else
            {
                if (u.HasBlanks())
                    res = new Tuple<bool, string>(false, "Registration failed. Registration information incomplete.");
                else if (u.InValidEmail())
                    res = new Tuple<bool, string>(false, "Registration failed. Please enter a valid email address.");
                else if (u.PasswordMisMatch())
                    res = new Tuple<bool, string>(false, "Registration failed. Passwords do not match.");
            }

            return res;
        }

        public Tuple<bool, string> GetVerificationResponse(string email)
        {
            Tuple<bool, string> res = null;

            VertifyUser u = new VertifyUser(email);

            if (u.IsValid())
                res = new Tuple<bool, string>(true, $"Sending Verification Code to {email}");
            else
            {
                if (u.HasBlanks())
                    res = new Tuple<bool, string>(false, "Registration failed. Registration information incomplete.");
                else if (u.InValidEmail())
                    res = new Tuple<bool, string>(false, "Registration failed. Please enter a valid email address.");
            }

            return res;
        }
    }
}
