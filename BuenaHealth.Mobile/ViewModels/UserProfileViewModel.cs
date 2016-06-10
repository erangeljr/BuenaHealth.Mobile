using System;
using BuenaHealth.Mobile.Models;
using System.Threading.Tasks;

namespace BuenaHealth.Mobile
{
	public class UserProfileViewModel
	{
		public UserProfileViewModel ()
		{
		}

		public async Task<string> AddNewUserAsync(User model)
		{
			await App.buenaHealthRepository.AddNewUserAsync(model);
			var result = App.buenaHealthRepository.StatusMessage;
			return result;
		}
	}
}

