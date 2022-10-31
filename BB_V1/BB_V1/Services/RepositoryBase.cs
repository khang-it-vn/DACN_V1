using BB_V1.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BB_V1.Services
{
    public abstract class RepositoryBase<T> where T : class
    {
        protected DbBloodBank _db { get; set; }
        protected DbSet<T> _dbComponent { get; set; }
        public RepositoryBase(DbBloodBank db)
        {
            this._db = db;
            this._dbComponent = _db.Set<T>();
        }
        public bool Add(T t, out String errs)
        {
            try
            {
                _dbComponent.Add(t);
                errs = null;
                return true;
            }catch(Exception ex)
            {
                errs = ex.ToString();
                return false;
            }
        }

        public bool Delete(T t, out String errs)
        {
            try
            {
                _dbComponent.Remove(t);
                errs = null;
                return true;
            }catch(Exception ex)
            {
                errs = ex.Message;
                return false;
            }
        }

        /// <summary>
        /// Lấy danh sách các object <T> 
        /// </summary>
        /// <returns>danh sách của <T></returns>
        public IEnumerable<T> GetAll()
        {
            return _dbComponent.ToList();
        }

        public T GetById(object attr)
        {
            T t = _dbComponent.Find(attr);
            return t;
        }

        public bool Update(T t, out String errs)
        {
            try
            {
                _dbComponent.Attach(t);

                _db.Entry(t).State = EntityState.Modified;
                errs = null;
                return true;
            }
            catch (Exception ex)
            {
                errs = ex.ToString();
                return false;
            }
        }

        public IEnumerable<T> GetByCondition(Expression<Func<T, bool>> condition)
        {
            List<T> ts = _dbComponent.Where(condition).AsEnumerable().ToList();
            return ts;
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
