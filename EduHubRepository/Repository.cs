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

        public List<TEntity> GetAll()
        {
            try
            {
                return this.context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public TEntity Get(long id)
        {
            try
            {
                return this.context.Set<TEntity>().Find(id);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int Insert(TEntity entity)
        {
            try
            {
                this.context.Set<TEntity>().Add(entity);
                return this.context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public int Update(TEntity entity)
        {
            try
            {
                this.context.Entry<TEntity>(entity).State = EntityState.Modified;
                return this.context.SaveChanges();
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
    }
}
