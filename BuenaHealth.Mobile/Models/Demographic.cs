using System;
using SQLite.Net.Attributes;

namespace BuenaHealth.Mobile.Models
{
    [Table("demographic")]
    public class Demographic
    {
        [PrimaryKey, AutoIncrement]
        public int DemographicId { get; set; }
        [MaxLength(250)]
        public DateTime BirthDate { get; set; }
        [MaxLength(250)]
        public string Language { get; set; }
        [MaxLength(250)]
        public string Sex { get; set; }
        [MaxLength(250)]
        public string Race { get; set; }
        [MaxLength(250)]
        public string Ethnicity { get; set; }
    }
}
