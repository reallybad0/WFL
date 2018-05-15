using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace WaterForLife
{
    public class LiquidRecord : ATable
    {
        //Database of drinking stuff
        public int DrinkID { get; set; }
        //dates
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
    }
}
