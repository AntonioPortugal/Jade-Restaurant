using Data.Base;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Data.MenuInfo
{
    public class Meal : NamedEntity
    {
        private string StartingHours { get; set; }
        private string EndingHours { get; set; }


        public Meal(string startingHours, string endingHours)
        {
            StartingHours = startingHours;
            EndingHours = endingHours;
        }
     
    }
}
