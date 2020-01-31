using AllNotes.Domain.EF.IRepositories;
using AllNotes.Domain.Models.BaseModel;
using AllNotes.Domain.EF.AllNotesContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AllNotes.Domain.EF.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly AllNotesDbContext _context;

        public BaseRepository(AllNotesDbContext context)
        {
            _context = context;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            EntityEntry<T> result = await _context.Set<T>().AddAsync(entity);
            return result.Entity;
        }

        public T Update(T entity)
        {
            EntityEntry<T> result = _context.Set<T>().Update(entity);
            return result.Entity;
        }

        public T Delete(T entity)
        {
            EntityEntry<T> result = _context.Set<T>().Remove(entity);
            return result.Entity;
        }

    }
}
