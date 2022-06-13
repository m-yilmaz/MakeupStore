using ApplicationCore.Entities;
using Ardalis.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);

        Task<List<T>> GetAllAsync();

        Task<List<T>> GetAllAsync(ISpecification<T> specification);

        Task<T> AddAsnyc(T entity);

        Task UpdateAsnyc(T entity);

        Task<T> DeleteAsnyc(T entity);

        Task<int> CountAsync(ISpecification<T> specification);

        Task<T> FirstAsync(ISpecification<T> specification);

        Task<T> FirstOrDefaultAsync(ISpecification<T> specification);

    }
}
