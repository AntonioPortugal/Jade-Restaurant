﻿using RECODME.RD.Jade.Data.UserInfo;
using RECODME.RD.Jade.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RECODME.RD.Jade.DataAccess.DataAccessObjects.UserDataAccessObjects
{
    public class PersonDataAccessObject
    {
        private RestaurantContext _context;

        public PersonDataAccessObject()
        {
            _context = new RestaurantContext();

        }

        #region C

        public void Create(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();

        }

        public async Task CreateAsync(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region R

        public Person Read(Guid id)
        {
            return _context.People.FirstOrDefault(x => x.Id == id);

        }

        public async Task<Person> ReadAsync(Guid id)
        {
            return await
                new Task<Person>(() => _context.People.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(Person person)
        {
            _context.Entry(person).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(Person person)
        {
            person.IsDeleted = true;
            Update(person);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(Person person)
        {
            person.IsDeleted = true;
            await UpdateAsync(person);

        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);

        }

        #endregion

        #region List
        public List<Person> List()
        {
            return _context.Set<Person>().ToList();
        }
        public async Task<List<Person>> ListAsync()
        {
            return await _context.Set<Person>().ToListAsync();
        }
        #endregion

    }

}
