using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WebApi2.DAL.Interfaces;
using System.Data.Entity;
using WebApi2.Models;

namespace WebApi2.DAL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private ApplicationDbContext _context = null;
        private DbSet<T> dbTable = null;

        public GenericRepository(ApplicationDbContext context)
        {
            this._context = context;
            dbTable = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return dbTable.ToList();
        }

        public T GetById(object id)
        {
            return dbTable.Find(id);
        }

        public void Insert(T obj)
        {
            dbTable.Add(obj);
            //_context.SaveChanges();
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(T obj)
        {
            dbTable.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
            Save();
        }

        public void Delete(object id)
        {
            T existing = dbTable.Find(id);
            dbTable.Remove(existing);
            Save();
        }
    }
}