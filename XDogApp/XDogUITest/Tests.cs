﻿using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XDogUITest
{
    [TestFixture(Platform.Android)]
    // [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;


        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        //[Test]
        //public void AppLaunches()
        //{
        //   app.Screenshot("First screen.");
        //}

        private bool LabelEquals(string autoId, string dersiredVal)
        {
            var res = app.Query(autoId).First(r => r.Text == dersiredVal);
            return (res != null);
        }

        [Test]
        [Category("EmailVerification")]
        [TestCase("", "Registration Failed. Registration information incomplete.")]
        [TestCase("fakeemail@s", "Registration Failed. Please enter a valid email address.")]
        [TestCase("fake@gmail", "Registration Failed. Please enter a valid email address.")]
        [TestCase("sandipverma222@gmail.com", "Sending Verification Code to sandipverma222@gmail.com")]
        public void TestIncompleteVerificationSend(string e, string res)
        {
            app.EnterText("RegisterEntryEmail", e);

            app.Tap("btnSendVerification");

            Assert.IsTrue(LabelEquals("RegisterLabelResponse", res));

        }

        [Test]
        [Category("FullRegister")]
        [TestCase("", "", "", "", "Registration Failed. Registration information incomplete.")]
        [TestCase("", "123", "123", "DOGGY", "Registration Failed. Registration information incomplete.")]
        [TestCase("", "", "", "DOGGY", "Registration Failed. Registration information incomplete.")]
        [TestCase("sandipverma222@gmail.com", "2017", "2016", "DOGGY", "Registration Failed. Passwords do not match.")]
        [TestCase("fakeemail@gail", "2017", "2017", "DOGGY", "Registration Failed. Please enter a valid email address.")]
        [TestCase("sandipverma222@gmail.com", "2017", "2017", "DOGGY", "Registration has been successful.")]
        public void TestIncompletRegister(string e, string p, string cp, string vc, string res)
        {
            app.EnterText("RegisterEntryEmail", e);
            app.EnterText("RegisterEntryPassword", p);
            app.EnterText("RegisterEntryConfirmPassword", cp);
            app.EnterText("RegisterEntryVerificationCode", vc);

            app.Tap("btnRegister");

            Assert.IsTrue(LabelEquals("RegisterLabelResponse", res));
        }
    }
}

