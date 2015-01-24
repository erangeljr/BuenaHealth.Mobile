using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuenaHealth.Mobile.WinPhone
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string fileName)
        {
            string path = Windows.Storage.ApplicationData.Current.LocalFolder.Path;

            return path + fileName;
        }
    }
}
