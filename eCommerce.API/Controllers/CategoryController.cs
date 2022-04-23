using eCommerce.BLL;
using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace eCommerce.API.Controllers
{
    public class CategoryController : ApiController
    {
        public List<Category> Get()
        {
            return new CategoryService().GetAll();
        }

        public Category Get(int id)
        {
            return new CategoryService().GetById(id);
        }

        public List<Category> Post(Category category)
        {
            CategoryService catservis = new CategoryService();
            bool response = catservis.Create(category);
            if (response)
            {
                return catservis.GetAll();
            }
            else
            {
                return new List<Category>();
            }
        }

        public Category Put(int id, Category category)
        {
            CategoryService catservis = new CategoryService();
            bool response = catservis.Update(category);
            if (response)
            {
                return catservis.GetById(id);
            }
            else
            {
                return new Category();
            }
        }

        public bool Delete(int id)
        {
            CategoryService catservis = new CategoryService();
            bool response = catservis.Delete(id);
            if (response)
            {
                return response;
            }
            else
            {
                return false;
            }
        }
    }
}
