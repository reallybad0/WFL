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
        public Bean()
        {
            InitializeComponent();
            var drinkTypesDB = new ObservableCollection<Liquid>(App.Database.GetItems<Liquid>().Result);
            //TYPES == 0 - BEST , 5 - WORST
            var BD = new ObservableCollection<BeanData>(App.Database.GetItems<BeanData>().Result);
            BeanData UserBean = BD[0];

            


            NameLabel.Text = "Bean Name : " + UserBean.Name.ToString();
            ScoreLabel.Text = "Height : " + UserBean.Height.ToString();
            HealthLabel.Text = "Health: " + UserBean.Health.ToString("0.00");

            FillScrollView(drinkTypesDB);


            //to update on user bean
            //            UserBean.Height = 200;
            //            App.Database.UpdateItem<BeanData>(BD[0]);


        }
        void OnButtonClicked(object sender, EventArgs e) {

            Button button = sender as Button;
            var drinkTypesDB = new ObservableCollection<Liquid>(App.Database.GetItems<Liquid>().Result);
            string ct = button.Text.ToString();
            var selectedItem = drinkTypesDB.Single(i => i.Title == ct);

            DateTime today = DateTime.Now;
            int Day = today.Day;
            int Month = today.Month;
            int Year = today.Year;
            int Hour = today.Hour;
            int Minute = today.Minute;
            CheckDailyAmount();
            HealthUpdate(selectedItem);
            LiquidRecord lr = new LiquidRecord(selectedItem.ID, selectedItem.Amount, selectedItem.Type, Day, Month, Year, Hour, Minute);
            App.Database.SaveItems<LiquidRecord>(lr);

            DisplayAlert("Alert", selectedItem.ID.ToString(), "OK");


        }
        void FillScrollView(ObservableCollection<Liquid> itemsFromDb)
        {
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
        void HealthUpdate(Liquid liquid)
        {
            var BD = new ObservableCollection<BeanData>(App.Database.GetItems<BeanData>().Result);
            BeanData UserBean = BD[0];
            if (liquid.Type == 0)
            { 
                double ubp = UserBean.Health * 5;
                double divided = ubp / 100;
                double total = UserBean.Health + divided;
                UserBean.Health = total;

            }
            else if (liquid.Type < 3 && liquid.Type>0)
            {
                double ubp = UserBean.Health * 3;
                double divided = ubp / 100;
                double total = UserBean.Health + divided;
                UserBean.Health = total;

            }
            else if(liquid.Type > 3)
            {
                double smt = liquid.Amount / 100;
                double ubp = smt * liquid.Type;
                double divided = ubp / 100;
                double total = UserBean.Health- divided;
                UserBean.Health = total;
            }

            App.Database.UpdateItem<BeanData>(UserBean);
            //FLOORNOUT TO

            string x = UserBean.Health.ToString("0.00");
            HealthLabel.Text = "Health: " + x;
        }
        void HeightUpdate(Liquid liquid)
        {
            var BD = new ObservableCollection<BeanData>(App.Database.GetItems<BeanData>().Result);
            BeanData UserBean = BD[0];

            






        }
        
        bool CheckDailyAmount()
        {
            DateTime today = DateTime.Now;
            int Day = today.Day;
            int Month = today.Month;
            int Year = today.Year;
            int Hour = today.Hour;
            int Minute = today.Minute;

            
            var LiquidRecords = new ObservableCollection<LiquidRecord>(App.Database.GetItems<LiquidRecord>().Result);
            var recordsfromtoday = LiquidRecords.Where(x => x.Day == Day && x.Month == Month && x.Year == Year);
            int i = 0;
            foreach (var item in recordsfromtoday)
            {
                i++;
            }

            DisplayAlert("Alert", i.ToString(), "OK");
            //IF DAILY AMOUNT OKAY = RETURN TRUE
            return true;
        }

    }
}