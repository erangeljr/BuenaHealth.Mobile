using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BuenaHealth.Mobile.Models;
using SQLite.Net;
using SQLite.Net.Async;
using SQLite.Net.Interop;

namespace BuenaHealth.Mobile
{
    public class DemographicRepository
    {
         private SQLiteAsyncConnection dbConn;
        
        public string StatusMessage { get; set; }

        public DemographicRepository(ISQLitePlatform sqlitePlatform, string dbPath)
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
                dbConn.CreateTableAsync<User>();
            }
        }

        public async Task AddNewUserAsync(Demographic demographic)
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
                    Name = demographic.Name,
                    BirthDate = demographic.BirthDate,
                    Language = demographic.Language,
                    Sex = demographic.Sex,
                    Race = demographic.Race,
                    Ethnicity = demographic.Ethnicity
                });
                StatusMessage = string.Format("{0} record(s) added [Demographic: {1})", result, demographic.Name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", demographic.Name, ex.Message);
            }

        }

        public async Task<List<Demographic>> GetAllUsersAsync()
        {
            //return a list of people saved to the Person table in the database
            List<Demographic> demographic = await dbConn.Table<Demographic>().ToListAsync();
            return demographic;
        }
    
    }
}
