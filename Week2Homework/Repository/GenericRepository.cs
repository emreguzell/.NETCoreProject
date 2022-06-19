using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;

using Week2Homework.DBOperations;
using Week2Homework.DataModel;
using System.Linq.Dynamic.Core;

namespace Week2Homework.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected CustomerDbContext context;
        public DbSet<T> DbSet;
        public readonly ILogger logger;

        public GenericRepository(CustomerDbContext _context, ILogger _logger)
        {
            context = _context;
            logger = _logger;

            DbSet = context.Set<T>();

        }

        public void Delete(long Id)
        {
            var deletedItem = DbSet.Find(Id);
            DbSet.Remove(deletedItem);
        }

        public void DeleteAll()
        {
            DbSet.RemoveRange(GetAll());
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public T GetById(long Id)
        {
            return DbSet.Find(Id);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbSet.Update(entity);
        }
    }
}
