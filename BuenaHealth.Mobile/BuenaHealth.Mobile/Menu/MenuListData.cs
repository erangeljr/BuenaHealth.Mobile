using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuenaHealth.Mobile.Menu
{
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {

            this.Add(new MenuItem()
            {
                Title = "Profile Summary",
                IconSource = "opportunities.png",
                TargetType = typeof(MainPage)
            });

            this.Add(new MenuItem()
            {
                Title = "User Profile",
                IconSource = "profile.png",
                TargetType = typeof(UserPage)
            });

            this.Add(new MenuItem()
            {
                Title = "Demographics",
                IconSource = "demographics.png",
                TargetType = typeof(DemographicPage)
            });

            this.Add(new MenuItem()
            {
                Title = "Vital Signs",
                IconSource = "vitalsigns.png",
                TargetType = typeof(VitalSignPage)
            });

        }
    }
}
