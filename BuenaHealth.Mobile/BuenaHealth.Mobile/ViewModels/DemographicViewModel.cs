using System;
using BuenaHealth.Mobile.Models;
using System.Threading.Tasks;

namespace BuenaHealth.Mobile
{
	public class DemographicViewModel
	{
		public DemographicViewModel ()
		{
		}

		public async Task<string> AddNewDemographicAsync(Demographic model)
		{
			try
			{
				await App.buenaHealthRepository.AddNewDemographicAsync(model);
				var result = App.buenaHealthRepository.StatusMessage;
				return result;
				
			}
			catch(Exception ex) {
				throw new Exception("Saving Broke: {0}",ex);
			}

		}
	}
}

