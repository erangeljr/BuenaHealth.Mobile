using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace BuenaHealth.Mobile.Models
{
    [Table("vitalsign")]
    public class VitalSign
    {
        [PrimaryKey, AutoIncrement]
        public int VitalSignId { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
    }
}
