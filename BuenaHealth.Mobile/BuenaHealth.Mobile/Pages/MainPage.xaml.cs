using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuenaHealth.Mobile.Models;
using Xamarin.Forms;

namespace BuenaHealth.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            GetUserDetail();
        }

        private async void GetUserDetail()
        {
            var user = await App.buenaHealthRepository.GetUser();
            if (user == null)
                return;
            firstNameMessage.Text = user.FirstName + " " + user.LastName + "'s" + " " + "Profile";

        }

    }
}
