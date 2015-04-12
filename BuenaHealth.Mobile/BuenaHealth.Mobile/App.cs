using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuenaHealth.Mobile;
using SQLite.Net.Interop;
using Xamarin.Forms;

namespace BuenaHealth.Mobile
{
    public class App : Application
    {
        public static UserRepository userRepository { get; private set; }
        public static VitalSignsRepository vitalSignsRepository { get; private set; }
        public static DemographicRepository demographicRepository { get; private set; }

        public App(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            //set database path first, then retrieve main page
           // userRepository = new UserRepository(sqlitePlatform, dbPath);
            vitalSignsRepository = new VitalSignsRepository(sqlitePlatform, dbPath);
            //demographicRepository = new DemographicRepository(sqlitePlatform, dbPath);


            this.MainPage = new VitalSignPage();
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
