using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;
using Xamarin.Forms;

namespace WaterForLife
{
    class BeanData : ATable
    {
        public int Height;
        public int Health;
        public bool IsAlive;
        public int Type;
    }
}
