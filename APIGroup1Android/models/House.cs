using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIGroup1Android.models
{
    public class House
    {
        public int id { get; set; }
        public string title { get; set; }
        public double weeklyRent { get; set; }
        public int numBedrooms { get; set; }
        public int numBathrooms { get; set; }
        public string Address { get; set; }
        public int AgentID { get; set; }

    }
}