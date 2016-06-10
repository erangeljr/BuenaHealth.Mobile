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

            var h = decimal.Parse(height.Text);
            var w = decimal.Parse(weight.Text);
            var s = int.Parse(systolic.Text);
            var d = int.Parse(diastolic.Text);

            VitalSign vitalSign;
            vitalSign = new VitalSign
            {
                Height = h,
                Weight = w,
                Systolic = s,
                Diastolic = d
            };
            await App.buenaHealthRepository.AddNewVitalSignAsync(vitalSign);
            statusMessage.Text = App.buenaHealthRepository.StatusMessage;
        }

    }
}
