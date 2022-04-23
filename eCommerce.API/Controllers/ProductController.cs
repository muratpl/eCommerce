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
    public class ProductController : ApiController
    {
        public List<Product> Get()
        {
            return new ProductService().GetAll();
        }

        public Product Get(int id)
        {
            return new ProductService().GetById(id);
        }

        public List<Product> Post(Product product)
        {
            ProductService Productservis = new ProductService();
            bool response = Productservis.Create(product);
            if (response)
            {
                return Productservis.GetAll();
            }
            else
            {
                return new List<Product>();
            }
        }

        public Product Put(int id, Product product)
        {
            ProductService Productservis = new ProductService();
            bool response = Productservis.Update(product);
            if (response)
            {
                return Productservis.GetById(id);
            }
            else
            {
                return new Product();
            }
        }

        public bool Delete(int id)
        {
            ProductService Productservis = new ProductService();
            bool response = Productservis.Delete(id);
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
