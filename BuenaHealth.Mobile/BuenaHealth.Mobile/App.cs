using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BuenaHealth.Mobile;
using BuenaHealth.Mobile.Repositories;
using SQLite.Net.Interop;
using Xamarin.Forms;

namespace BuenaHealth.Mobile
{
    public class App : Application
    {
        public static BuenaHealthRepository buenaHealthRepository { get; private set; }

        public App(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            //set database path first, then retrieve main page
            buenaHealthRepository = new BuenaHealthRepository(sqlitePlatform, dbPath);
          
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
