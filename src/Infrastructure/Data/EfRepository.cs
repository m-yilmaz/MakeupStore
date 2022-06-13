using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Ardalis.Specification;
using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly StoreContext _context;

        public EfRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<T> AddAsnyc(T entity)
        {
            _context.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> CountAsync(ISpecification<T> specification)
        {
            return await _context.Set<T>().WithSpecification(specification).CountAsync();
        }

        public async Task<T> DeleteAsnyc(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> FirstAsync(ISpecification<T> specification)
        {
            return await _context.Set<T>().WithSpecification(specification).FirstAsync();
        }

        public async Task<T> FirstOrDefaultAsync(ISpecification<T> specification)
        {
            return await _context.Set<T>().WithSpecification(specification).FirstOrDefaultAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllAsync(ISpecification<T> specification)
        {
            return await _context.Set<T>().ToListAsync(specification);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.FindAsync<T>(id);
        }

        public async Task UpdateAsnyc(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
