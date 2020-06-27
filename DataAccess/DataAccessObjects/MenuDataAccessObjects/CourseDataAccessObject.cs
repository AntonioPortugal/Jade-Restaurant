using RECODME.RD.Jade.Data.MenuInfo;
using RECODME.RD.Jade.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace RECODME.RD.Jade.DataAccess.DataAccessObjects.MenuDataAccessObjects
{
    public class CourseDataAccessObject
    {
        private RestaurantContext _context;

        public CourseDataAccessObject()
        {
            _context = new RestaurantContext();

        }


        #region C

        public void Create(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();

        }

        public async Task CreateAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();

        }

        #endregion

        #region R

        public Course Read(Guid id)
        {
            return _context.Courses.FirstOrDefault(x => x.Id == id);

        }

        public async Task<Course> ReadAsync(Guid id)
        {
            return await 
                new Task<Course>(() =>_context.Courses.FirstOrDefault(x => x.Id == id));

        }

        #endregion

        #region U

        public void Update(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            _context.SaveChanges();

        }

        public async Task UpdateAsync(Course course)
        {
            _context.Entry(course).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

        #endregion

        #region D

        public void Delete(Course course)
        {
            course.IsDeleted = true;
            Update(course);

        }

        public void Delete(Guid id)
        {
            var item = Read(id);
            if (item == null) return;
            Delete(item);

        }

        public async Task DeleteAsync(Course course)
        {
            course.IsDeleted = true;
            await UpdateAsync(course);

        }

        public async Task DeleteAsync(Guid id)
        {
            var item = ReadAsync(id).Result;
            if (item == null) return;
            await DeleteAsync(item);

        }

        #endregion

        #region List

        public List<Course> List()
        {
            return _context.Set<Course>().ToList();
        }
        public async Task<List<Course>> ListAsync()
        {
            return await _context.Set<Course>().ToListAsync();
        }

        #endregion

    }

}
