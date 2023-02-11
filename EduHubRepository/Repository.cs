using EduHubEntity;
using EduHubInterface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHubRepository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly AppDbContext context;
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
        public async Task<TEntity> Get(long id)
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

        public async Task<int> Insert(TEntity entity)
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

        public async Task<int> Update(TEntity entity)
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

        public int Delete(TEntity entity)
        {
            try
            {
                this.context.Set<TEntity>().Remove(entity);
                return this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        List<TEntity> IRepository<TEntity>.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        TEntity IRepository<TEntity>.Get(long id)
        {
            throw new NotImplementedException();
        }

        int IRepository<TEntity>.Insert(TEntity entity)
        {
            throw new NotImplementedException();
        }

        int IRepository<TEntity>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
