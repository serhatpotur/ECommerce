using Core.Exceptions;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;

        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<T> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                throw new AppException($"Error getting entity by id: {id}", ex);
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();
            }
            catch (Exception ex)
            {
                throw new AppException("Error getting all entities", ex);
            }
        }

        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return await _context.Set<T>().Where(predicate).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new AppException("Error finding entities", ex);
            }
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
            }
            catch (Exception ex)
            {
                throw new AppException("Error adding entity", ex);
            }
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            try
            {
                await _context.Set<T>().AddRangeAsync(entities);
            }
            catch (Exception ex)
            {
                throw new AppException("Error adding range of entities", ex);
            }
        }

        public void Update(T entity)
        {
            try
            {
                _context.Set<T>().Update(entity);
            }
            catch (Exception ex)
            {
                throw new AppException("Error updating entity", ex);
            }
        }

        public void Remove(T entity)
        {
            try
            {
                _context.Set<T>().Remove(entity);
            }
            catch (Exception ex)
            {
                throw new AppException("Error removing entity", ex);
            }
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            try
            {
                _context.Set<T>().RemoveRange(entities);
            }
            catch (Exception ex)
            {
                throw new AppException("Error removing range of entities", ex);
            }
        }
    }
}
