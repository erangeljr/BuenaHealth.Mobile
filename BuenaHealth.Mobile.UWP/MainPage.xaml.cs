using SQLite.Net.Platform.WinRT;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace BuenaHealth.Mobile.UWP
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage
	{
		public MainPage()
		{
			this.InitializeComponent();

			StorageFolder localFolder = ApplicationData.Current.LocalFolder;
			string pathToDB = System.IO.Path.Combine(localFolder.Path, Mobile.App.DB_FILENAME);
			LoadApplication(new BuenaHealth.Mobile.App(new SQLitePlatformWinRT(), pathToDB));
		}
	}
}
