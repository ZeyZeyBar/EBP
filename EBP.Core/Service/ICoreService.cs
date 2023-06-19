using EBP.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EBP.Core.Service
{
    public interface ICoreService<T> where T : CoreEntity
    {
        bool Add(T entity);
        bool Delete(int id);
        bool Update(T entity);
        T GetById(int id);
        T GetRecord(Expression<Func<T,bool>> expression);
        List<T> GetAllRecords();
        int Save();
    }
}
