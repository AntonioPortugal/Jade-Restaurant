﻿using Data.RestaurantInfo;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessObjects.RestaurantDataAccessObjects
{
    public class RestaurantDataAccessObject
    {
        private RestaurantContext _context;

        public RestaurantDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region C

        public void Create(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            _context.SaveChanges();

        }

        public async Task CreateAsync(Restaurant restaurant)
        {
            await _context.Restaurants.AddAsync(restaurant);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region R

        public Restaurant Read(Guid id)
        {
            return _context.Restaurants.FirstOrDefault(x => x.Id == id);

        }

        public async Task<Restaurant> ReadAsync(Guid id)
        {
            return await
                new Task<Restaurant>(() => _context.Restaurants.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(Restaurant restaurant)
        {
            _context.Entry(restaurant).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(Restaurant restaurant)
        {
            restaurant.IsDeleted = true;
            Update(restaurant);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(Restaurant restaurant)
        {
            restaurant.IsDeleted = true;
            await UpdateAsync(restaurant);

        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);

        }

        #endregion
    }
}