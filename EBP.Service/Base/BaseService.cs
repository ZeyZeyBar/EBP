using EBP.Core.Entity;
using EBP.Core.Service;
using EBP.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EBP.Service.Base
{
    public class BaseService<T> : ICoreService<T> where T : CoreEntity
    {
        private readonly EBPContext _db;
        public BaseService(EBPContext db)
        {
            _db = db;
        }
        public bool Add(T entity)
        {
            try
            {
                _db.Set<T>().Add(entity);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _db.Set<T>().Remove(GetById(id));
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<T> GetAllRecords() => _db.Set<T>().ToList();
        

        public T GetById(int id)=>_db.Set<T>().Find(id);
       

        public T GetRecord(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return _db.Set<T>().FirstOrDefault(expression);
        }

        public int Save()
        {
           return _db.SaveChanges();
        }

        public bool Update(T entity)
        {
            try
            {
                _db.Set<T>().Update(entity);
                return Save() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
