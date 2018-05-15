using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WaterForLife
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StatsPage : ContentPage
	{
		public StatsPage ()
		{
			InitializeComponent ();
            Button u = new Button();
            u.Text = "lalala";
            Stack.Children.Add(u);
            
        }
	}
}