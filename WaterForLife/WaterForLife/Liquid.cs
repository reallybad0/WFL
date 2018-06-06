using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;
using Xamarin.Forms;

namespace WaterForLife
{
    public class Liquid : ATable
    {
        public string Title { get; set; }
        public int Amount { get; set; }
        public int Type { get; set; }
        public Liquid()
        {
        }

        public Liquid( string title, int amount, int type)
        {
            Title = title;
            Amount = amount;
            Type = type;
        }


    }
}
