using Data.MenuInfo;
using DataAccess.Contexts;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataAccessObjects.RestarauntDataAccessObjects
{
    public class DietaryRestrictionDataAccessObject
    {
        private RestaurantContext _context;

        public DietaryRestrictionDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region C

        public void Create(DietaryRestriction dietaryRestriction)
        {
            _context.DietaryRestrictions.Add(dietaryRestriction);
            _context.SaveChanges();

        }

        public async Task CreateAsync(DietaryRestriction dietaryRestriction)
        {
            await _context.DietaryRestrictions.AddAsync(dietaryRestriction);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region R

        public DietaryRestriction Read(Guid id)
        {
            return _context.DietaryRestrictions.FirstOrDefault(x => x.Id == id);

        }

        public async Task<DietaryRestriction> ReadAsync(Guid id)
        {
            return await
                new Task<DietaryRestriction>(() => _context.DietaryRestrictions.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(DietaryRestriction dietaryRestriction)
        {
            _context.Entry(dietaryRestriction).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(DietaryRestriction dietaryRestriction)
        {
            _context.Entry(dietaryRestriction).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(DietaryRestriction dietaryRestriction)
        {
            dietaryRestriction.IsDeleted = true;
            Update(dietaryRestriction);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(DietaryRestriction dietaryRestriction)
        {
            dietaryRestriction.IsDeleted = true;
            await UpdateAsync(dietaryRestriction);

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