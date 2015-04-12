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
    public class VitalSignsRepository
    {
        private SQLiteAsyncConnection dbConn;
        
        public string StatusMessage { get; set; }

        public VitalSignsRepository(ISQLitePlatform sqlitePlatform, string dbPath)
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
                dbConn.CreateTableAsync<VitalSign>();
            }
        }

        public async Task AddNewVitalSignAsync(VitalSign vitalSign)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (vitalSign == null)
                    throw new ArgumentNullException("Valid vitalSign required");

                //insert a new VitalSign into the Person table
                result = await dbConn.InsertAsync(new VitalSign
                {
                    Height = vitalSign.Height,
                    Weight = vitalSign.Weight,
                    Diastolic = vitalSign.Diastolic,
                    Systolic = vitalSign.Systolic
                });
                StatusMessage = string.Format("{0} record(s) added Vital Sign", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add vitalSign. Error: {0}", ex.Message);
            }

        }

        public async Task<List<VitalSign>> GetAllVitalSignsAsync()
        {
            //return a list of people saved to the Person table in the database
            List<VitalSign> vitalSign = await dbConn.Table<VitalSign>().ToListAsync();
            return vitalSign;
        }
    }
}
