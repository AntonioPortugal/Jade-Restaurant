using Data.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data.RestaurantInfo
{
    public class Title
    {
        private string _position;

        [Required]
        [Display(Name = "Position")]
        public string Position
        {
            get => _position;

            set
            {
                _position = value;
                RegisterChange();
            }
        }


        private string _description;

        [Required]
        [Display(Name = "Description")]
        public string Description
        {
            get => _description;

            set
            {
                _description = value;
                RegisterChange();
            }
        }

    }
}
