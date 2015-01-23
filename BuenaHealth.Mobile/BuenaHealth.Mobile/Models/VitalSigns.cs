using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuenaHealth.Mobile.Models
{
    public class VitalSigns
    {
        public int VitalSignId { get; set; }
        public float Height { get; set; }
        public float Weight { get; set; }
        public int Systolic { get; set; }
        public int Diastolic { get; set; }
    }
}
