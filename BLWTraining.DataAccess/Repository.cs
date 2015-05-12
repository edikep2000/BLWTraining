using System;
using System.Linq;
using System.Linq.Expressions;
using Telerik.OpenAccess;

namespace BLWTraining.DataAccess
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly OpenAccessContext Context;

        public Repository(OpenAccessContext ctx)
        {
            Context = ctx;
        }
        public IQueryable<T> GetAll()
        {
            return Context.GetAll<T>();

        }

        public IQueryable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.GetAll<T>().Where(predicate);
        }

        public T GetSingle(Object id)
        {
            var objectKey = new ObjectKey(typeof(T).Name, id);
            var entity = Context.GetObjectByKey<T>(objectKey);
            return entity;
        }

        public void Delete(int id)
        {
            var t = GetSingle(id);
            if (t != null)
                Delete(t);
        }

        public void Delete(T t)
        {
            this.Context.Delete(t);
        }

        public void Insert(T t)
        {
            if (t != null)
                Context.Add(t);
        }
    }
}