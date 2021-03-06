﻿using RECODME.RD.Jade.Data.MenuInfo;
using RECODME.RD.Jade.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RECODME.RD.Jade.DataAccess.DataAccessObjects.MenuDataAccessObjects
{
    public class MenuDataAccessObject
    {

        private RestaurantContext _context;

        public MenuDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region C

        public void Create(Menu menu)
        {
            _context.Menus.Add(menu);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Menu menu)
        {
            await _context.Menus.AddAsync(menu);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region R

        public Menu Read(Guid id)
        {
            return _context.Menus.FirstOrDefault(x => x.Id == id);

        }

        public async Task<Menu> ReadAsync(Guid id)
        {
            return await
                new Task<Menu>(() => _context.Menus.FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region U

        public void Update(Menu menu)
        {
            _context.Entry(menu).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(Menu menu)
        {
            _context.Entry(menu).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(Menu menu)
        {
            menu.IsDeleted = true;
            Update(menu);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(Menu menu)
        {
            menu.IsDeleted = true;
            await UpdateAsync(menu);

        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);

        }
        #endregion

        #region List
        public List<Menu> List()
        {
            return _context.Set<Menu>().ToList();
        }
        public async Task<List<Menu>> ListAsync()
        {
            return await _context.Set<Menu>().ToListAsync();
        }
        #endregion
    }
}
