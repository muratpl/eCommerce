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
    public class UserController : ApiController
    {
        UserService userService = new UserService();

        public List<User> Get()
        {
            return new UserService().GetAll();
        }

        public User Get(int id)
        {
            return new UserService().GetById(id);
        }

        public List<User> Post(User user)
        {
            bool response = userService.Create(user);
            if (response)
            {
                return userService.GetAll();
            }
            else
            {
                return new List<User>();
            }
        }

        public User Put(int id, User user)
        {
            bool response = userService.Update(user);
            if (response)
            {
                return userService.GetById(id);
            }
            else
            {
                return new User();
            }
        }

        public bool Delete(int id)
        {
            bool response = userService.Delete(id);
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
