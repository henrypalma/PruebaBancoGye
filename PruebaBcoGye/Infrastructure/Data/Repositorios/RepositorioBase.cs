using Domain.Repositorios;
using Infrastructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;
//using EFCore.BulkExtensions;
using EFCore.BulkExtensions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositorios
{
    public class RepositorioBase<T>(ApplicationDbContext context) : IRepositorioBase<T>
    where T : class
    {
        protected readonly ApplicationDbContext Context = context;
        protected readonly DbSet<T> DbSet = context.Set<T>();

        public virtual async Task<T> ConsultarPorIdAsync(int id) => (await Context.FindAsync<T>(id))!;

        public virtual async Task<IEnumerable<T>> ConsultarTodosAsync() => await DbSet.ToListAsync();

        public virtual async Task GrabarAsync(T entity)
        {
            await Context.AddAsync(entity);
            await Context.SaveChangesAsync();
        }


        public virtual async Task GrabarArregloAsync(List<T> entity)
        {
            await Context.AddRangeAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task BulkInsertAsync(List<T> entity)
        {
            await Context.BulkInsertAsync(entity);
        }


        public virtual async Task ActualizarAsync(T entity)
        {
            Context.Update(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task ActualizarArregloAsync(List<T> entity)
        {
            Context.UpdateRange(entity);
            await Context.SaveChangesAsync();
        }
    }
}
