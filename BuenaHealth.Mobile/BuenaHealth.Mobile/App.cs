using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite.Net.Interop;
using Xamarin.Forms;

namespace BuenaHealth.Mobile
{
    public class App : Application
    {
        public static UserRepository _userRepository { get; private set; }
        public static VitalSignsRepository _vitalSignsRepository { get; private set; }
        public static DemographicRepository _demographicRepository { get; private set; }

        public static Page GetMainPage(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            //set database path first, then retrieve main page
            _userRepository = new UserRepository(sqlitePlatform, dbPath);
            _vitalSignsRepository = new VitalSignsRepository(sqlitePlatform, dbPath);
            _demographicRepository = new DemographicRepository(sqlitePlatform, dbPath);

            return new UserPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
