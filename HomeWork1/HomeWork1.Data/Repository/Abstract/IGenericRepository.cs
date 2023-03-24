using System;
using System.Linq.Expressions;

namespace HomeWork1.Data;

public interface IGenericRepository<TEntity> where TEntity : class
{
    TEntity GetById(int id);
    List<TEntity> GetAll();
    void Insert(TEntity entity);
    void Remove(TEntity entity);
    void Remove(int id);
    void Update(TEntity entity);

    IEnumerable<TEntity> Filter(Expression<Func<TEntity,bool>> expression);

}

