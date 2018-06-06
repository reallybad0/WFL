using System;
using System.Collections.Generic;
using System.Text;

namespace WaterForLife
{
    class BeanData : ATable
    {
        public int Height { get; set; }
        public string Name { get; set; }
        public double Health { get; set; }
        public bool IsAlive { get; set; }

        public BeanData()
        {
        }

        public BeanData(int height, string name, double health, bool isAlive)
        {
            Height = height;
            Name = name;
            Health = health;
            IsAlive = isAlive;
        }
    }
}
