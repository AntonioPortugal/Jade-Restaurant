using Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text;

namespace Data.MenuInfo
{
    public class Meal : NamedEntity
    {
        private string _startingHours;
        private string _endingHours;

        [Display(Name = "Starting Hours")]
        public string StartingHours
        {
            get => _startingHours;
            set
            {
                _startingHours = value;
                RegisterChange();
            }
        }

        [Display(Name = "Ending Hours")]
        public string EndingHours
        {
            get => _endingHours;
            set
            {
                _endingHours = value;
                RegisterChange();
            }
        }

        public virtual ICollection<Menu> MenuRecords { get; set; }


        public Meal(string name, string startingHours, string endingHours) : base(name)
        {
            _startingHours = startingHours;
            _endingHours = endingHours;
        }

        public Meal(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name, string startingHours, string endingHours) : base(id, createdAt, updatedAt, isDeleted, name)
        {
            _startingHours = startingHours;
            _endingHours = endingHours;
        }


    }
}
