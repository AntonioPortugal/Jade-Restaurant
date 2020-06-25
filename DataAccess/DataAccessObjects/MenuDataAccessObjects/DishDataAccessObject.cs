using RECODME.RD.Jade.Data.MenuInfo;
using RECODME.RD.Jade.DataAccess.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RECODME.RD.Jade.DataAccess.DataAccessObjects.MenuDataAccessObjects
{
    public class DishDataAccessObject
    {
        private RestaurantContext _context;

        public DishDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region C

        public void Create(Dish dish)
        {
            _context.Dishes.Add(dish);
            _context.SaveChanges();

        }

        public async Task CreateAsync(Dish dish)
        {
            await _context.Dishes.AddAsync(dish);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region R

        public Dish Read(Guid id)
        {
            return _context.Dishes.FirstOrDefault(x => x.Id == id);

        }

        public async Task<Dish> ReadAsync(Guid id)
        {
            return await
                new Task<Dish>(() => _context.Dishes.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(Dish dish)
        {
            _context.Entry(dish).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(Dish dish)
        {
            _context.Entry(dish).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(Dish dish)
        {
            dish.IsDeleted = true;
            Update(dish);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(Dish dish)
        {
            dish.IsDeleted = true;
            await UpdateAsync(dish);

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
