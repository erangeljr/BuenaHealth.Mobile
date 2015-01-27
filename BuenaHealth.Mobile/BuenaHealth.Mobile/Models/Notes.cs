using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace BuenaHealth.Mobile.Models
{
    [Table("notes")]
    public class Notes
    {
        [PrimaryKey, AutoIncrement]
        public int NoteId { get; set; }
        public string Summmary { get; set; }
    }
}
