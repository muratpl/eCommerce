using eCommerce.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.BLL
{
    public class Repository<T,Parameter> where T:class

    {
        protected eCommerceEntities context = new eCommerceEntities();

        public List<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public T GetById (Parameter id)
        {
            return context.Set<T>().Find(id);
        }

        public bool Create(T data)
        {
            try
            {
                context.Set<T>().Add(data);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Update(T data)
        {
            try
            {
                context.Set<T>().Attach(data);
                context.Entry<T>(data).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Parameter id)
        {
            try
            {
                var data = context.Set<T>().Find(id);
                context.Set<T>().Remove(data);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;

            }
        }
    }
}
