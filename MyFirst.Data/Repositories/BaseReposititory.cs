using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyFirst.Data.Repositories
{
    public  class BaseRepostitory<T> : IRepositiory<T>, IDisposable  where T:class
    {
        //protected EFDbContext Context;
         EFDbContext Context = new EFDbContext();
        protected DbSet<T> _dbSet;
        public BaseRepostitory()
        {
            this._dbSet = Context.Set<T>();
        }

        /// <summary>
        /// 单表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<T> Query(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).ToList();
        }

        public List<T> Query()
        {
            return _dbSet.ToList();
        }
        /// <summary>
        /// 多表查询
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="tableNames"></param>
        /// <returns></returns>
        public List<T> queryJoin(Expression<Func<T, bool>> predicate, string[] tableNames)
        {
            if (tableNames == null && tableNames.Any() == false)
            {
                throw new Exception("缺少连表名称");
            }
            DbQuery<T> query = _dbSet;
            foreach (var table in tableNames)
            {
                query = query.Include(table);
            }
            return query.Where(predicate).ToList();
        }

        /// <summary>
        /// 通过传入的model加需求修改的字段来更改数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="propertys"></param>
        public void Edit(T model, dynamic[] propertys)
        {
            if (model == null)
            {
                throw new Exception("实体不能为空");
            }
            if (propertys.Any() == false)
            {
                throw new Exception("要修改的属性至少要一个");
            }
            //将model追击到EF容器
            DbEntityEntry entry = Context.Entry(model);

            entry.State = EntityState.Unchanged;

            foreach (var item in propertys)
            {
                entry.Property(item).IsModified = true;
            }
            //关闭EF对实体的合法性验证参数
            Context.Configuration.ValidateOnSaveEnabled = false;
            Context.SaveChanges();
        }

        /// <summary>
        /// 直接查询之后再修改
        /// </summary>
        /// <param name="model"></param>
        public void Edit(T model)
        {
            Context.Entry(model).State = EntityState.Modified;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="model"></param>
        /// <param name="isadded"></param>
        public int Delete(Expression<Func<T, bool>> predicate)
        {
           
            IQueryable<T> source = this._dbSet.Where(predicate);
            foreach (T current in source)
            {
                this._dbSet.Remove(current);
            }
            return this.Context.SaveChanges();
                
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        public void Add(T model)
        {
            _dbSet.Add(model);
            Context.SaveChanges();
        }

        public T Creat(T model)
        {
           return _dbSet.Add(model);
        }
        /// <summary>
        /// 查找单条数据
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T Find(Expression<Func<T,bool>> predicate)
        {
            return this._dbSet.FirstOrDefault(predicate);
        }
        private bool disposed = false;
        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
