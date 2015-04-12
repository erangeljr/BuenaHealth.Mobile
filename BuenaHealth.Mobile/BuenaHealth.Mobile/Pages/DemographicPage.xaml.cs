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
    public partial class DemographicPage : ContentPage
    {
        
        public DemographicPage()
        {
            InitializeComponent();
            AddPickerData();
        
        }

        private void AddPickerData()
        {
            ethnicityPicker.Items.Add(StringKeys.Mexican);
            ethnicityPicker.Items.Add(StringKeys.Hispanic);
            ethnicityPicker.Items.Add(StringKeys.NotHispanic);

            racePicker.Items.Add(StringKeys.Asian);
            racePicker.Items.Add(StringKeys.Black);
            racePicker.Items.Add(StringKeys.Native);
            racePicker.Items.Add(StringKeys.White);

            languagePicker.Items.Add(StringKeys.English);
            languagePicker.Items.Add(StringKeys.Spanish);

            sexPicker.Items.Add(StringKeys.Male);
            sexPicker.Items.Add(StringKeys.Female);
            sexPicker.Items.Add(StringKeys.Transgender);
        }
        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            var demographic = new Demographic
            {
                Ethnicity = ethnicityPicker.Items[0]
            };
            await App.buenaHealthRepository.AddNewDemographicAsync(demographic);
            statusMessage.Text = App.buenaHealthRepository.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<Demographic> list = await BuenaHealth.Mobile.App.buenaHealthRepository.GetAllDemographicsAsync();

            ObservableCollection<Demographic> collection = new ObservableCollection<Demographic>(list);
            demographicList.ItemsSource = collection;
        }
    }
}
