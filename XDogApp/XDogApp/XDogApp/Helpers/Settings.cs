// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System.Runtime.CompilerServices;

namespace XDogApp.Helpers
{
	/// <summary>
	/// This is the Settings static class that can be used in your Core solution or in any
	/// of your client applications. All settings are laid out the same exact way with getters
	/// and setters. 
	/// </summary>
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		#region Setting Constants

		private const string SettingsKey = "settings_key";
		private static readonly string SettingsDefault = string.Empty;

        public static string GeneralSettings
        {
            get
            {
                return AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(SettingsKey, value);
            }
        }

        #endregion

        #region base getter, Setter
        private static string StringGetter(string def = "", [CallerMemberName] string propertyName = null) 
        {
            return AppSettings.GetValueOrDefault(propertyName, def);
        }

        private static void StringSetter(string val = "", [CallerMemberName] string propertyName = null)
        {
            AppSettings.AddOrUpdateValue(propertyName, val);
        }

        private static bool BoolGetter(bool def = default(bool), [CallerMemberName] string propertyName = null) 
        {
            return AppSettings.GetValueOrDefault(propertyName, def);
        }

        private static void BoolSetter(bool val = default(bool), [CallerMemberName] string propertyName = null)
        {
            AppSettings.AddOrUpdateValue(propertyName, val);
        }
        #endregion

        public static string Email { get { return StringGetter(); } set { StringSetter(value); } }
        public static string Password { get { return StringGetter(); } set { StringSetter(value); } }
        public static string Token { get { return StringGetter(); } set { StringSetter(value); } }
        public static string ScreenName { get { return StringGetter(); } set { StringSetter(value); } }
        public static bool UseMetric { get { return BoolGetter(); } set { BoolSetter(value); } }


	}
}