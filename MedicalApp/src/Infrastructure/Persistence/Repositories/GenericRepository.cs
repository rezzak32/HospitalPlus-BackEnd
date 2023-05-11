
using Application.Abstract.Repositories;
using Application.Models.RequestModels.Register;
using Application.Models.ResponseModels;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly MedicalAppDbContext _medicalAppDbContext;

        public GenericRepository(MedicalAppDbContext medicalAppDbContext)
        {
            _medicalAppDbContext = medicalAppDbContext;
        }

        public DbSet<T> Table => _medicalAppDbContext.Set<T>();

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            var query = Table.AsQueryable();

            return await query.FirstOrDefaultAsync(predicate);
        }
        public async Task<bool> AddAsync(T entity)
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
         }

        public async Task<int> SaveChangesAsync()
        {
            return await _medicalAppDbContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return  await Table.FindAsync(id);
        }
    }
}
