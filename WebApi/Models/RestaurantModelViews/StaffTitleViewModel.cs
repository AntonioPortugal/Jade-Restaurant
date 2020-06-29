﻿using RECODME.RD.Jade.Data.RestaurantInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.RestaurantModelViews
{
    public class StaffTitleViewModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid TitleId { get; set; }
        public Guid StaffRecordId { get; set; }

        public StaffTitle ToDietaryRestriction()
        {
            return new StaffTitle(Id, DateTime.UtcNow, DateTime.UtcNow, IsDeleted, StartDate, EndDate, TitleId, StaffRecordId);
        }

        public static StaffTitleViewModel Parse(StaffTitle staffTitle)
        {
            return new StaffTitleViewModel()
            {
                Id = staffTitle.Id,
                IsDeleted = staffTitle.IsDeleted,
                StartDate = staffTitle.StartDate,
                EndDate = staffTitle.EndDate,
                TitleId = staffTitle.TitleId,
                StaffRecordId = staffTitle.StaffRecordId
            };
        }
    }
}
