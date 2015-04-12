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
        }

        public async void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            var user = new User
            {
                UserName = "username",
                FirstName = "firstname",
                LastName = "lastname"
            };
            await App.buenaHealthRepository.AddNewUserAsync(user);
            statusMessage.Text = App.buenaHealthRepository.StatusMessage;
        }

        public async void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";

            List<User> pplList = await App.buenaHealthRepository.GetAllUsersAsync();

            ObservableCollection<User> pplCollection = new ObservableCollection<User>(pplList);
            peopleList.ItemsSource = pplCollection;
        }
    }
}
