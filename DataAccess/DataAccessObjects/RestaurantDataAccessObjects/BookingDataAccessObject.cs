using RECODME.RD.Jade.Data.RestaurantInfo;
using RECODME.RD.Jade.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RECODME.RD.Jade.DataAccess.DataAccessObjects.RestaurantDataAccessObjects
{
    public class BookingDataAccessObject
    {
        private RestaurantContext _context;

        public BookingDataAccessObject()
        {
            _context = new RestaurantContext();
        }

        #region C

        public void Create(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
        }

        public async Task CreateAsync(Booking booking)
        {
            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();
        }
        #endregion

        #region R

        public Booking Read(Guid id)
        {
            return _context.Bookings.FirstOrDefault(x => x.Id == id);

        }

        public async Task<Booking> ReadAsync(Guid id)
        {
            return await
                new Task<Booking>(() => _context.Bookings.FirstOrDefault(x => x.Id == id));

        }
        #endregion

        #region U

        public void Update(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(Booking booking)
        {
            booking.IsDeleted = true;
            Update(booking);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(Booking booking)
        {
            booking.IsDeleted = true;
            await UpdateAsync(booking);

        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);

        }

        #endregion

        #region List

        public List<Booking> List()
        {
            return _context.Set<Booking>().ToList();
        }
        public async Task<List<Booking>> ListAsync()
        {
            return await _context.Set<Booking>().ToListAsync();
        }

        #endregion
    }
}
