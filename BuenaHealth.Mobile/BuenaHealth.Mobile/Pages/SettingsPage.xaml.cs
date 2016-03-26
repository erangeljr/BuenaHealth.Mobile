using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.ComponentModel;

namespace BuenaHealth.Mobile
{
	public partial class SettingsPage : ContentPage, INotifyPropertyChanged
	{
		public SettingsPage ()
		{
			InitializeComponent ();
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
		}


	}
}

