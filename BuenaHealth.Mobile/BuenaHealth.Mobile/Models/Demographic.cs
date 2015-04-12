using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuenaHealth.Mobile.Models
{
    public class Demographic
    {
        public int DemographicId { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Language { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
    }
}
