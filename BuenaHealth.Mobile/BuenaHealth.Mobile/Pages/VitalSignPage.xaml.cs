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
    public partial class VitalSignPage : ContentPage
    {
        public VitalSignPage()
        {
            InitializeComponent();
        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            var vitalSign = new VitalSign
            {
                Height = float.Parse(height.Text),
                Weight = float.Parse(weight.Text),
                Systolic = int.Parse(systolic.Text),
                Diastolic = int.Parse(diastolic.Text)
            };
            await App.vitalSignsRepository.AddNewVitalSignAsync(vitalSign);
            statusMessage.Text = App.userRepository.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<VitalSign> list = await BuenaHealth.Mobile.App.vitalSignsRepository.GetAllVitalSignsAsync();

            ObservableCollection<VitalSign> collection = new ObservableCollection<VitalSign>(list);
            vitalSignList.ItemsSource = collection;
        }
    }
}
