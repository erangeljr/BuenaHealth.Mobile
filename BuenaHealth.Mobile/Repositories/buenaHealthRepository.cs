using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuenaHealth.Mobile.Models;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;

namespace BuenaHealth.Mobile.Repositories
{
    public class BuenaHealthRepository
    {
        private SQLiteAsyncConnection dbConn;
        
        /// <summary>
        /// Gets or sets the status message.
        /// </summary>
        /// <value>The status message.</value>
		public string StatusMessage { get; set; }

		/// <summary>
		/// Initializes a new instance of the <see cref="BuenaHealth.Mobile.Repositories.BuenaHealthRepository"/> class.
		/// </summary>
		/// <param name="sqlitePlatform">Sqlite platform.</param>
		/// <param name="dbPath">Db path.</param>
        public BuenaHealthRepository(ISQLitePlatform sqlitePlatform, string dbPath)
        {
            //initialize a new SQLiteConnection 
            if (dbConn == null)
            {
                var connectionFunc = new Func<SQLiteConnectionWithLock>(() =>
                    new SQLiteConnectionWithLock
                        (
                            sqlitePlatform,
                            new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: false)
                        )
                );

                dbConn = new SQLiteAsyncConnection(connectionFunc);
                dbConn.CreateTablesAsync<User,VitalSign,Demographic>();
            }
        }

        /// <summary>
        /// Adds the new user async.
        /// </summary>
        /// <returns>The new user async.</returns>
        /// <param name="user">User.</param>
		public async Task AddNewUserAsync(User user)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(user.UserName))
                    throw new Exception("Valid UserName required");

                //insert a new person into the Person table
                result = await dbConn.InsertAsync(new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName
                });
                StatusMessage = string.Format("{0} record(s) added [UserName: {1})", result, user.UserName);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", user.UserName, ex.Message);
            }

        }

        /// <summary>
        /// Adds the new vital sign async.
        /// </summary>
        /// <returns>The new vital sign async.</returns>
        /// <param name="vitalSign">Vital sign.</param>
		public async Task AddNewVitalSignAsync(VitalSign vitalSign)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (vitalSign == null)
                    throw new ArgumentNullException("Valid vitalSign required");

                //insert a new VitalSign into the VitalSign table
                var item = new VitalSign()
                {
                    Height = vitalSign.Height,
                    Weight = vitalSign.Weight,
                    Systolic = vitalSign.Systolic,
                    Diastolic = vitalSign.Diastolic
                };
                result = await dbConn.InsertAsync(item);
                StatusMessage = string.Format("{0} record(s) added Vital Sign", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add vitalSign. Error: {0}", ex.Message);
            }

        }

        /// <summary>
        /// Adds the new demographic async.
        /// </summary>
        /// <returns>The new demographic async.</returns>
        /// <param name="demographic">Demographic.</param>
		public async Task AddNewDemographicAsync(Demographic demographic)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (demographic == null)
                    throw new Exception("Valid FirstName required");

                //insert a new person into the Person table
                result = await dbConn.InsertAsync(new Demographic
                {
                    BirthDate = demographic.BirthDate,
                    Language = demographic.Language,
                    Sex = demographic.Sex,
                    Race = demographic.Race,
                    Ethnicity = demographic.Ethnicity
                });
                StatusMessage = string.Format("{0} record(s) added [Demographic: {1})", result, demographic.Ethnicity);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", demographic.Ethnicity, ex.Message);
            }

        }

        /// <summary>
        /// Gets all demographics async.
        /// </summary>
        /// <returns>The all demographics async.</returns>
		public async Task<List<Demographic>> GetAllDemographicsAsync()
        {
            //return a list of people saved to the Person table in the database
            List<Demographic> demographic = await dbConn.Table<Demographic>().ToListAsync();
            return demographic;
        }

        /// <summary>
        /// Gets all vital signs async.
        /// </summary>
        /// <returns>The all vital signs async.</returns>
		public async Task<List<VitalSign>> GetAllVitalSignsAsync()
        {
            //return a list of people saved to the Person table in the database
            List<VitalSign> vitalSign = await dbConn.Table<VitalSign>().ToListAsync();
            return vitalSign;
        }

        /// <summary>
        /// Gets all users async.
        /// </summary>
        /// <returns>The all users async.</returns>
		public async Task<List<User>> GetAllUsersAsync()
        {
            //return a list of people saved to the Person table in the database
            List<User> user = await dbConn.Table<User>().ToListAsync();
            return user;
        }

        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <returns>The user.</returns>
		public async Task<User> GetUser()
        {
            var user = await dbConn.Table<User>().FirstOrDefaultAsync();
            return user;
        }
    }
}
