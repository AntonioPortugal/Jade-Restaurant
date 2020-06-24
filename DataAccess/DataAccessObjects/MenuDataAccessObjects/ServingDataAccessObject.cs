using Data.MenuInfo;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DataAccessObjects.MenuDataAccessObjects
{
    public class ServingDataAccessObject
    {
        private RestaurantContext _context;

        public ServingDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region C

        public void Create(Serving serving)
        {
            _context.Servings.Add(serving);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Serving serving)
        {
            await _context.Servings.AddAsync(serving);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region R

        public Serving Read(Guid id)
        {
            return _context.Servings.FirstOrDefault(x => x.Id == id);

        }

        public async Task<Serving> ReadAsync(Guid id)
        {
            return await
                new Task<Serving>(() => _context.Servings.FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region U

        public void Update(Serving serving)
        {
            _context.Entry(serving).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(Serving serving)
        {
            _context.Entry(serving).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(Serving serving)
        {
            serving.IsDeleted = true;
            Update(serving);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(Serving serving)
        {
            serving.IsDeleted = true;
            await UpdateAsync(serving);

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
