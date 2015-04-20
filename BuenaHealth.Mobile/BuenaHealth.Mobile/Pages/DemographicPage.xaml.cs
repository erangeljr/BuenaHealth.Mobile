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
        private string _ethnicity;
        private string _race;
        private string _language;
        private string _sex;
        private DateTime _birthDate;
        
        public DemographicPage()
        {
            InitializeComponent();
            AddPickerData();

            ethnicityPicker.SelectedIndexChanged += (sender, args) =>
            {
                _ethnicity = ethnicityPicker.Items[ethnicityPicker.SelectedIndex];
            };

            racePicker.SelectedIndexChanged += (sender, args) =>
            {
                _race = racePicker.Items[racePicker.SelectedIndex];
            };

            languagePicker.SelectedIndexChanged += (sender, args) =>
            {
                _language = languagePicker.Items[languagePicker.SelectedIndex];
            };

            sexPicker.SelectedIndexChanged += (sender, args) =>
            {
                _sex = sexPicker.Items[sexPicker.SelectedIndex];
            };

            dateOfBirthPicker.DateSelected += (sender, args) =>
            {
                _birthDate = dateOfBirthPicker.Date;
            };
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
                Ethnicity = _ethnicity,
                Race = _race,
                Language = _language,
                Sex = _sex,
                BirthDate = _birthDate

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
