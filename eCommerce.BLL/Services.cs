using eCommerce.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.BLL
{
    public class ProductService : Repository<Product,int>
    {
    }

    public class UserService : Repository<User,int>
    {
    }

    public class CategoryService : Repository<Category,int>
    {
        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            return context.Product.Where(x => x.CategoryId == categoryId).ToList();

        }
    }
}
