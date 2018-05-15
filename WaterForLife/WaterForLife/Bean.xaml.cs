using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterForLife
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Bean : ContentPage
	{
		public Bean ()
		{
			InitializeComponent ();
            var itemsFromDb = new ObservableCollection<Liquid>(App.Database.GetItems<Liquid>().Result);

            string[] drinks = new string[] { "Lahev vody","Malá lahev vody","Velká lahev vody","Sklenice vody","Sklenička vody"};
            int[] amounts = new int[] { 1500, 500, 2000, 300, 200 };
            //TYPES == 0 - BEST , 5 - WORST

            for (int i = 0; i < itemsFromDb.Count(); i++)
            {

                StackLayout Lab = new StackLayout();
                Lab.WidthRequest = 100;
                Lab.HeightRequest = 100;

                Button n = new Button();
                n.Text = itemsFromDb[i].Title;
                n.WidthRequest = 70;
                n.HeightRequest = 70;
                n.Clicked += OnButtonClicked;


                Label tt = new Label();
                tt.Text = itemsFromDb[i].Amount.ToString() + " ml";
                tt.HorizontalTextAlignment = TextAlignment.Center;
                Lab.Children.Add(n);
                Lab.Children.Add(tt);


                SL.Children.Add(Lab);

            }

        }
        void OnButtonClicked(object sender, EventArgs e) {

            Button button = sender as Button;
            string ct = button.Text.ToString();
        }

    }
}