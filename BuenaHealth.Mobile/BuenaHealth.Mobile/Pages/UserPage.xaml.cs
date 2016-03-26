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
    public partial class UserPage : ContentPage, INotifyPropertyChanged 
    {
		private string username;
		private string firstname;
		private string lastname;

		public string UserName
		{
			get { return username; }
			set
			{
				username = value;
				RaisePropertyChanged(nameof(username));
			}
		}

		public string FirstName
		{
			get { return firstname; }
			set
			{
				firstname = value;
				RaisePropertyChanged(nameof(firstname));
			}
		}

		public string LastName
		{
			get { return lastname; }
			set
			{
				lastname = value;
				RaisePropertyChanged(nameof(lastname));
			}
		}

        public UserPage()
        {
            InitializeComponent();
        }

		public event PropertyChangedEventHandler PropertyChanged;
		protected void RaisePropertyChanged(string name)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(name));
			}
		}

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            var user = new User
            {
                UserName = userName.Text,
                FirstName = firstName.Text,
                LastName = lastName.Text
            };
            await App.buenaHealthRepository.AddNewUserAsync(user);
            statusMessage.Text = App.buenaHealthRepository.StatusMessage;
        }

    }
}
