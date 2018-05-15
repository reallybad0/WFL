using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace WaterForLife
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            MainPage = new NavigationPage(new WaterForLife.FirstPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
        private static LiquidDatabase _database;
        public static LiquidDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new LiquidDatabase(DependencyService.Get<IFileHelpers>().GetLocalFilePath("Databejs.db3"));
                }
                return _database;
            }
        }
    }
}
