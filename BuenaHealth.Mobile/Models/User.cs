using SQLite.Net.Attributes;

namespace BuenaHealth.Mobile.Models
{
    [Table("user")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int UserId { get; set; }
        [MaxLength(250)]
        public string FirstName { get; set; }
        [MaxLength(250)]
        public string LastName { get; set; }
        [MaxLength(250), Unique]
        public string UserName { get; set; }
    }
}
