using Data.UserInfo;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DataAccessObjects.UserDataAccessObjects
{
    class StaffRecordDataAccessObject
    {
        private RestaurantContext _context;

        public StaffRecordDataAccessObject()
        {
            _context = new RestaurantContext();

        }

        #region C

        public void Create(StaffRecord staffRecord)
        {
            _context.StaffRecords.Add(staffRecord);
            _context.SaveChanges();

        }

        public async Task CreateAsync(StaffRecord staffRecord)
        {
            await _context.StaffRecords.AddAsync(staffRecord);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region R

        public StaffRecord Read(Guid id)
        {
            return _context.StaffRecords.FirstOrDefault(x => x.Id == id);

        }

        public async Task<StaffRecord> ReadAsync(Guid id)
        {
            return await
                new Task<StaffRecord>(() => _context.StaffRecords.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(StaffRecord staffRecord)
        {
            _context.Entry(staffRecord).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(StaffRecord staffRecord)
        {
            _context.Entry(staffRecord).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(StaffRecord staffRecord)
        {
            staffRecord.IsDeleted = true;
            Update(staffRecord);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(StaffRecord staffRecord)
        {
            staffRecord.IsDeleted = true;
            await UpdateAsync(staffRecord);

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
