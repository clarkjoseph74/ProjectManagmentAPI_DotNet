using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProjectManagmentSystem.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystem.EF.Repositories;
public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
    }

   

    public IEnumerable<T> GetAll(Expression<Func<T, bool>>? criteria = null)
    {
        IQueryable<T> query = _context.Set<T>();
        if (criteria != null)
            query = query.Where(criteria);
        return query.ToList();
    }

    public T? GetById(int id)
    {
        return _context.Set<T>().Find(id);
    }

    public T UpdateOne(T entity)
    {
        _context.Set<T>().Update(entity);
        return entity;
    }
    public T CreateOne(T entity)
    {
        _context.Set<T>().Add(entity);
        return entity;
    }

    public T DeleteOne(int id)
    {
        var itemToDelete = _context.Set<T>().Find(id);
        if(itemToDelete != null)
        {
            _context.Set<T>().Remove(itemToDelete);
            return itemToDelete;
        }
        return null;
    }
}
