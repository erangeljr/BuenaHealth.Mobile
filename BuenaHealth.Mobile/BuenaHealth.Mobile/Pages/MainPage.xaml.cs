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
            if (user != null)
            {
                firstNameMessage.Text = user.FirstName + " " + user.LastName + "'s" + " " + "Profile";

            }
            List<Demographic> demographics = await BuenaHealth.Mobile.App.buenaHealthRepository.GetAllDemographicsAsync();

            if (demographics != null)
            {
                demographicMessage.Text = "Demographics";
                ObservableCollection<Demographic> collection = new ObservableCollection<Demographic>(demographics);
                demographicList.ItemsSource = collection;
            }
            List<VitalSign> vitalSigns = await BuenaHealth.Mobile.App.buenaHealthRepository.GetAllVitalSignsAsync();
            if (vitalSigns != null)
            {
              
                vitalSignsMessage.Text = "Vital Signs";
                List<VitalSign> list = await BuenaHealth.Mobile.App.buenaHealthRepository.GetAllVitalSignsAsync();

                ObservableCollection<VitalSign> collection = new ObservableCollection<VitalSign>(vitalSigns);
                vitalSignList.ItemsSource = collection;
            }

        }

    }
}
