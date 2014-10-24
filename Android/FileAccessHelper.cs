using System;

namespace BuenaHealth.Mobile.Android
{
	/// <summary>
	/// File access helper.
	/// </summary>
	public class FileAccessHelper
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="BuenaHealth.Mobile.Android.FileAccessHelper"/> class.
		/// </summary>
		public FileAccessHelper()
		{
		}

		/// <summary>
		/// Gets the local file path.
		/// </summary>
		/// <returns>The local file path.</returns>
		/// <param name="filename">Filename.</param>
		public static string GetLocalFilePath(string filename)
		{
			var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			return System.IO.Path.Combine(path, filename);
		}
	}
}

