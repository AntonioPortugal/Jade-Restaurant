﻿using RECODME.RD.Jade.Data.MenuInfo;
using RECODME.RD.Jade.DataAccess.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace RECODME.RD.Jade.DataAccess.DataAccessObjects.MenuDataAccessObjects
{
    public class MealDataAccessObject
    {
        private RestaurantContext _context;

        public MealDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region C

        public void Create(Meal meal)
        {
            _context.Meals.Add(meal);
            _context.SaveChanges();

        }

        public async Task CreateAsync(Meal meal)
        {
            await _context.Meals.AddAsync(meal);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region R

        public Meal Read(Guid id)
        {
            return _context.Meals.FirstOrDefault(x => x.Id == id);

        }

        public async Task<Meal> ReadAsync(Guid id)
        {
            return await
                new Task<Meal>(() => _context.Meals.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(Meal meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(Meal meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(Meal meal)
        {
            meal.IsDeleted = true;
            Update(meal);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(Meal meal)
        {
            meal.IsDeleted = true;
            await UpdateAsync(meal);

        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);

        }

        #endregion

        #region List
        public List<Meal> List()
        {
            return _context.Set<Meal>().ToList();
        }
        public async Task<List<Meal>> ListAsync()
        {
            return await _context.Set<Meal>().ToListAsync();
        }
        #endregion
    }
}