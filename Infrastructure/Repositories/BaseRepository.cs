using APIBanco.Domain.Model;
using APIBanco.Infrastructure.Context;
using APIBanco.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIBanco.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        private readonly AppDbContext _dbContext;
        public BaseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public virtual async Task<T> Create(T obj)
        {
            _dbContext.Add(obj);
           await _dbContext.SaveChangesAsync();
            return obj;
        }

        public virtual async Task Delete(long id)
        {
            var obj = await Get(id);

            if(obj!= null)
            {
                _dbContext.Remove(obj);
                await _dbContext.SaveChangesAsync();
            }
            
        }

        public virtual async Task<T> Get(long id)
        {
            var obj = await _dbContext.Set<T>().AsNoTracking().Where(x=>x.Id == id).FirstOrDefaultAsync();

            return obj;
        }

        public virtual async Task<List<T>> GetAll()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public virtual async Task<T> Update(T obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return obj;
        }
    }
}
