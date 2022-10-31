using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace BB_V1.Services.IRepositories
{
    public interface IRepository<T> where T : class
    {
       
        /// <summary>
        /// Lấy danh sách các object <T> 
        /// </summary>
        /// <returns>danh sách của <T></returns>
        IEnumerable<T> GetAll();

        T GetById(object pk);

        bool Add(T t, out string errs);

        bool Update(T t, out string errs);

        bool Delete(T t, out string errs);

        void Save();

        IEnumerable<T> GetByCondition(Expression<Func<T, bool>> condition);

    }
}
