using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuenaHealth.Mobile.Models;
using Xamarin.Forms;
using System.ComponentModel;

namespace BuenaHealth.Mobile
{
	public partial class DemographicPage : ContentPage, INotifyPropertyChanged 
    {
        private string _ethnicity;
        private string _race;
        private string _language;
        private string _sex;
        private DateTime _birthDate;

		private DemographicViewModel viewModel;

		public string Ethnicity
		{
			get { return _ethnicity; }
			set
			{
				_ethnicity = value;
				RaisePropertyChanged(nameof(_ethnicity));
			}
		}

		public string Race
		{
			get { return _race; }
			set
			{
				_race = value;
				RaisePropertyChanged(nameof(_race));
			}
		}

		public string Language
		{
			get { return _language; }
			set
			{
				_language = value;
				RaisePropertyChanged(nameof(_language));
			}
		}

		public string Sex
		{
			get { return _sex; }
			set
			{
				_sex = value;
				RaisePropertyChanged(nameof(_sex));
			}
		}

		public DateTime Birthdate
		{
			get { return _birthDate; }
			set
			{
				_birthDate = value;
				RaisePropertyChanged(nameof(_birthDate));
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}
        
        public DemographicPage()
        {
            InitializeComponent();
			viewModel = new DemographicViewModel ();
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

			statusMessage.Text = await SaveDemographic ();
        }

		public async Task<String> SaveDemographic()
		{
			var model = new Demographic
			{
				Ethnicity = _ethnicity,
				Race = _race,
				Language = _language,
				Sex = _sex,
				BirthDate = _birthDate

			};

			return await viewModel.AddNewDemographicAsync(model);;
			
		}



    }
}
