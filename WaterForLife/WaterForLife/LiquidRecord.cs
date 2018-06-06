using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace WaterForLife
{
    public class LiquidRecord : ATable
    {
        public LiquidRecord()
        {
        }

        public LiquidRecord(int drinkID, int amount, int health, int day, int month, int year, int hour, int minute)
        {
            DrinkID = drinkID;
            Amount = amount;
            Health = health;
            Day = day;
            Month = month;
            Year = year;
            Hour = hour;
            Minute = minute;
        }



        //Database of drinking stuff
        public int DrinkID { get; set; }
        public int Amount { get; set; }
        public int Health { get; set; }
        //dates
        public int Day { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }


    }
}
