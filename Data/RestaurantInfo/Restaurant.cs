﻿using Data.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Data.RestaurantInfo
{
    public class Restaurant : NamedEntity
    {
        private string _address;

        [Required]
        [Display(Name = "Address")]
        public string Address
        {
            get => _address;

            set
            {
                _address = value;
                RegisterChange();
            }
        }

        private string _openingHours;

        [Required]
        [Display(Name = "Opening Hours")]
        public string OpeningHours
        {
            get => _openingHours;

            set
            {
                _openingHours = value;
                RegisterChange();
            }
        }

        private string _closingHours;

        [Required]
        [Display(Name = "Closing Hours")]
        public string ClosingHours
        {
            get => _closingHours;

            set
            {
                _closingHours = value;
                RegisterChange();
            }
        }

        private string _closingDays;

        [Required]
        [Display(Name = "Closing Days")]
        public string ClosingDays
        {
            get => _closingDays;

            set
            {
                _closingDays = value;
                RegisterChange();
            }
        }

        private int _tableCount;

        [Required]
        [Display(Name = "Table Count")]
        public int TableCount
        {
            get => _tableCount;

            set
            {
                _tableCount = value;
                RegisterChange();
            }
        }

        public Restaurant(Guid id, DateTime createdAt, DateTime updatedAt, bool isDeleted, string name, string address, string openingHours, string closingHours, string closingDays, int tableCount) : base(id, createdAt, updatedAt, isDeleted, name)
        {
            _address = address;
            _openingHours = openingHours;
            _closingHours = closingHours;
            _closingDays = closingDays;
            _tableCount = tableCount;
        }
    }
}
