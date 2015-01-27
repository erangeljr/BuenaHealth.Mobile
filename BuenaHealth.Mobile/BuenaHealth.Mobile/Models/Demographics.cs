using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace BuenaHealth.Mobile.Models
{
    [Table("demographics")]
    public class Demographics
    {
        [PrimaryKey, AutoIncrement]
        public int DemographicId { get; set; }
        public string Language { get; set; }
        public string Sex { get; set; }
        public string Race { get; set; }
        public string Ethnicity { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
