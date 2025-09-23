using ECommerce.Core.Entities;
using ECommerce.Data;
using ECommerce.Service.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.Service.Concrete
{
    public class Service<T> : IService<T> where T : class, IEntity, new()
    {

        internal DatabaseContext _context;

        public Service(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        internal DbSet<T> _dbSet; //database deki tablolarla eşleşecek.


        public void Add(T entity)
        {
          _dbSet.Add(entity);
        }

        public  async Task AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
        }

        public void Delete(T entity)
        {
          _dbSet.Remove(entity);
        }

        public async  Task<T> FindAsync(int id)
        {
         return  await _dbSet.FindAsync(id);
        }

        public T Find(int id)
        {
         return  _dbSet.Find(id);
        }

        public T Get(Expression<Func<T, bool>> expression)
        {
           return _dbSet.FirstOrDefault(expression);
        }

        public List<T> GetAll()
        {
                return _dbSet.AsNoTracking().ToList();
            //performans için asnotracking ekledik.
        }

        public List<T> GetAll(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression).AsNoTracking().ToList();
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.Where(expression).AsNoTracking().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbSet.AsNoTracking().ToListAsync();
        }

        public  async Task<T> GetAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbSet;
        }

        public  int SaveChanges()
        {
          return  _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
           _dbSet.Update(entity);
        }
    }
}
