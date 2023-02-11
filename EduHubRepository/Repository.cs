using EduHubEntity;
using EduHubInterface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHubRepository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly AppDbContext context;  
        
        public Repository(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            try
            {
                return  await this.context.Set<TEntity>().ToListAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<TEntity> GetAsync(long id)
        {
            try
            {
                return await this.context.Set<TEntity>().FindAsync(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<int> InsertAsync(TEntity entity)
        {
            try
            {
                this.context.Set<TEntity>().Add(entity);
                return await this.context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<int> UpdateAsync(TEntity entity)
        {
            try
            {
                this.context.Entry<TEntity>(entity).State = EntityState.Modified;
                return await this.context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<int> DeleteAsync(TEntity entity)
        {
            try
            {
                this.context.Set<TEntity>().Remove(entity);
                return await this.context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        
    }
}
