using RECODME.RD.Jade.Data.RestaurantInfo;
using RECODME.RD.Jade.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RECODME.RD.Jade.DataAccess.DataAccessObjects.RestaurantDataAccessObjects
{
    public class TitleDataAccessObject
    {
        private RestaurantContext _context;

        public TitleDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region C

        public void Create(Title title)
        {
            _context.Titles.Add(title);
            _context.SaveChanges();

        }

        public async Task CreateAsync(Title title)
        {
            await _context.Titles.AddAsync(title);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region R

        public Title Read(Guid id)
        {
            return _context.Titles.FirstOrDefault(x => x.Id == id);

        }

        public async Task<Title> ReadAsync(Guid id)
        {
            return await
                new Task<Title>(() => _context.Titles.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(Title title)
        {
            _context.Entry(title).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(Title title)
        {
            _context.Entry(title).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(Title title)
        {
            title.IsDeleted = true;
            Update(title);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(Title title)
        {
            title.IsDeleted = true;
            await UpdateAsync(title);

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
