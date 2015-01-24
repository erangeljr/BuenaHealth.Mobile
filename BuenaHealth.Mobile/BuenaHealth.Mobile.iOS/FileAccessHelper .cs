using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace BuenaHealth.Mobile.iOS
{
    public class FileAccessHelper
    {
        public static string GetLocalFilePath(string fileName)
        {
            string docFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string path = System.IO.Path.Combine(docFolder, "..", "Library");

            return path + fileName;
        }
    }
}