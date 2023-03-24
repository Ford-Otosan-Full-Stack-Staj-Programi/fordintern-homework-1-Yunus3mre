using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HomeWork1.Data;

public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly AppDbContext context;
    private DbSet<TEntity> entities;
    public GenericRepository(AppDbContext context)
    {
        this.context = context;
        this.entities = this.context.Set<TEntity>();
    }

    public List<TEntity> GetAll() => entities.ToList();


    public TEntity GetById(int id) => entities.Find(id);

    public void Insert(TEntity entity)
    {
       entities.Add(entity);
      
    }

    public void Remove(TEntity entity) => entities.Remove(entity);

    public void Remove(int id)
    {
        var staff = GetById(id);
        entities.Remove(staff);
    }

    public void Update(TEntity entity)
    {
        entities.Update(entity);
    }

    public IEnumerable<TEntity> Filter(Expression<Func<TEntity, bool>> expression)
    {
        return entities.Where(expression);  
    }
}

