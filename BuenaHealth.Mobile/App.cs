using BuenaHealth.Mobile.Repositories;
using BuenaHealth.Mobile.Menu;
﻿using SQLite.Net.Interop;
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
          
            this.MainPage = new RootPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
			StartLogging();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
			GoingToSleep();
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
			ResumeLogging();
        }

		void StartLogging ()
		{
			//Startup up logging service
		}

		void GoingToSleep()
		{
			//Close/Stop stuff that need closing/stoping
		}

		void ResumeLogging()
		{
			//fire it all backup 
		}
    }
}
