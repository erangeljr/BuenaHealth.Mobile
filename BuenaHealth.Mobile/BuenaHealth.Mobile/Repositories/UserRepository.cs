using SQLite.Net;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using SQLite.Net.Async;
using System.Threading.Tasks;
using BuenaHealth.Mobile.Models;

namespace BuenaHealth.Mobile
{
    public class UserRepository
    {
        private SQLiteAsyncConnection dbConn;
        
        public string StatusMessage { get; set; }

        public UserRepository(ISQLitePlatform sqlitePlatform, string dbPath)
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

        public async Task<List<User>> GetAllUsersAsync()
        {
            //return a list of people saved to the Person table in the database
            List<User> user = await dbConn.Table<User>().ToListAsync();
            return user;
        }
    
    }
}
