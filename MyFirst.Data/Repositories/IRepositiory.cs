using MyFirst.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyFirst.Data.Repositories
{
    public interface IRepositiory<T>:IDisposable, IDependency where T : class
    {
        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<T> Query(Expression<Func<T, bool>> predicate);

        List<T> Query();
        /// <summary>
        /// 多表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        List<T> queryJoin(Expression<Func<T, bool>> predicate, string[] tableNames);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        void Edit(T model);

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="model"></param>
        void Edit(T model, dynamic[] propertys);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isadded"></param>
        int Delete(Expression<Func<T,bool>> predicate);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        void Add(T model);

        /// <summary>
        ///  创建一对象.
        /// </summary>
        /// <param name="model">T</param>
        /// <returns>返回创建的数据</returns>
        T Creat(T model);

        /// <summary>
        /// 查询单条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        T Find(Expression<Func<T,bool>> predicate);
    }
}
