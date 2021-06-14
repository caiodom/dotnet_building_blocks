﻿using Core.Domain;
using Core.Domain.Interfaces;
using Core.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infra.Data.Repositories
{
    public class BaseRepository<T>: IBaseRepository<T> where T:BaseEntity,new()
    {
        protected MainContext Db; 
        protected DbSet<T> DbSet;
        public BaseRepository(IConfiguration config)
        {
            Db = new MainContext(config);
            DbSet = Db.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(bool asNoTracking=true)
        {
            if (asNoTracking)
            {
                return await DbSet.AsNoTracking()
                                    .ToListAsync();
            }

            return await DbSet.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T,bool>> expression,bool asNoTracking = true)
        {
            if(asNoTracking)
            {
                return await DbSet.AsNoTracking()
                                    .Where(expression)
                                    .ToListAsync();
            }

            return await  DbSet.Where(expression).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAsync( Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderBy,bool asNoTracking = true)
        {

            if (asNoTracking)
                return await DbSet.AsNoTracking().OrderBy(orderBy).Where(expression).ToListAsync().ConfigureAwait(false);
               


            return await DbSet.OrderBy(orderBy)
                                .Where(expression)
                                .ToListAsync()
                                .ConfigureAwait(false);
             
        }

        public virtual async Task<T> GetByIdAsync(int entityId, bool asNoTracking = true)
        {
            return asNoTracking
                ? await DbSet.AsNoTracking().SingleOrDefaultAsync(entity => entity.Id == entityId).ConfigureAwait(false)
                : await DbSet.FindAsync(entityId).ConfigureAwait(false);
        }

        public virtual async Task AddAsync(T entity)
        {
            DbSet.Add(entity);
          
            await SaveChangesAsync();
        }

        public virtual async Task AddCollectionAsync(IEnumerable<T> entities)
        {
             DbSet.AddRange(entities);
            await SaveChangesAsync();
        }

        public virtual IEnumerable<T> AddCollectionWithProxy(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                DbSet.Add(entity);
                yield return entity;
            }
        }


        public virtual Task UpdateAsync(T entity)
        {
            DbSet.Update(entity);
            return Task.CompletedTask;
        }

        public virtual Task UpdateCollectionAsync(IEnumerable<T> entities)
        {
            DbSet.UpdateRange(entities);
            return Task.CompletedTask;
        }


        public virtual IEnumerable<T> UpdateCollectionWithProxy(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                DbSet.Update(entity);
                yield return entity;
            }
        }

        public virtual Task RemoveByAsync(Func<T, bool> where)
        {
            DbSet.RemoveRange(DbSet.ToList().Where(where));
            return Task.CompletedTask;
        }

        public virtual Task RemoveAsync(T entity)
        {
            DbSet.Remove(entity);
            return Task.CompletedTask;
        }

        public virtual async Task SaveChangesAsync()
        {
            await Db.SaveChangesAsync().ConfigureAwait(false);
        }



        public virtual IEnumerable<T> Get(bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return  DbSet.AsNoTracking();
            }

            return  DbSet;
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> expression, bool asNoTracking = true)
        {
            if (asNoTracking)
            {
                return  DbSet.AsNoTracking()
                                    .Where(expression);
            }

            return  DbSet.Where(expression);
        }

        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> expression, Expression<Func<T, object>> orderBy, bool asNoTracking = true)
        {

            if (asNoTracking)
                return  DbSet.AsNoTracking().OrderBy(orderBy).Where(expression);



            return  DbSet.OrderBy(orderBy)
                                .Where(expression);

        }

        public virtual T GetById(int entityId, bool asNoTracking = true)
        {
            return asNoTracking
                ?  DbSet.AsNoTracking().SingleOrDefault(entity => entity.Id == entityId)
                :  DbSet.Find(entityId);
        }
    }
}
