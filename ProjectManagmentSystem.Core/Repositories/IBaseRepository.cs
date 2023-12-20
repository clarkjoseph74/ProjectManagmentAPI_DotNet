using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagmentSystem.Core.Repositories;
public interface IBaseRepository<T> where T : class
{
    T GetById(int id);
    IEnumerable<T> GetAll(Expression<Func<T,bool>>? criteria = null);

    T UpdateOne(T entity);
    T DeleteOne(int id);
    T CreateOne(T entity);
}
