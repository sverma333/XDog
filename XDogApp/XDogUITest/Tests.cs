using System;
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
        [TestCase("", "Login Failed. Login information incomplete.")]
        [TestCase("fakeemail@s", "Login Failed. Please enter a valid email address.")]
        [TestCase("fake@gmail", "Login Failed. Please enter a valid email address.")]
        [TestCase("sandipverma222@gmail.com", "Sending Verification Code to sandipverma222@gmail.com")]
        public void TestIncompleteVerificationSend(string e, string res)
        {
            app.EnterText("LoginEntryEmail", e);

            app.Tap("btnSendVerification");

            Assert.IsTrue(LabelEquals("LoginLabelResponse", res));

        }

        [Test]
        [Category("FullLogin")]
        [TestCase("", "", "", "", "Login Failed. Login information incomplete.")]
        [TestCase("", "123", "123", "DOGGY", "Login Failed. Login information incomplete.")]
        [TestCase("", "", "", "DOGGY", "Login Failed. Login information incomplete.")]
        [TestCase("sandipverma222@gmail.com", "2017", "2016", "DOGGY", "Login Failed. Passwords do not match.")]
        [TestCase("fakeemail@gail", "2017", "2017", "DOGGY", "Login Failed. Please enter a valid email address.")]
        [TestCase("sandipverma222@gmail.com", "2017", "2017", "DOGGY", "Login Success")]
        public void TestIncompletLogin(string e, string p, string cp, string vc, string res)
        {
            app.EnterText("LoginEntryEmail", e);
            app.EnterText("LoginEntryPassword", p);
            app.EnterText("LoginEntryConfirmPassword", cp);
            app.EnterText("LoginEntryVerificationCode", vc);

            app.Tap("btnLogin");

            Assert.IsTrue(LabelEquals("LoginLabelResponse", res));
        }
    }
}

