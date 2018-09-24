using ECommerce.Models;
using ECommerce.Models.ApplicationDBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;

namespace ECommerce.Controllers
{
    public class UserController : ApiController
    {
        private readonly ApplicationDBContext _applicationDBContext;
        public UserController()
        {
            _applicationDBContext = new ApplicationDBContext();
        }

        [Route("api/User/Create")]
        [HttpPost]
        public void RegisterUser([FromBody]User user)
        {
            if (user != null)
            {
                user.Password = CreateHash(user.Password);
                _applicationDBContext.Users.Add(user);
                _applicationDBContext.SaveChanges();
            }
        }
        [Route("api/User/Login")]
        [HttpPost]
        public User Login([FromBody]User user)
        {
            if (user != null)
            {
                if (_applicationDBContext.Users.Count(u => u.EmailId == user.EmailId && u.Password == CreateHash(user.Password)) > 0)
                {
                    return user;
                }
            }
            return null;
        }
        [Route("api/User/Update")]
        [HttpPut]
        public User Update([FromBody]User user, int id)
        {
            User dbUser = _applicationDBContext.Users.SingleOrDefault(u => u.User_Id == id);
            if(dbUser != null)
            {
                Mapper.Map<User, User>(user, dbUser);
                _applicationDBContext.SaveChanges();
            }
            return dbUser;
        }
        [Route("api/User/Delete")]
        [HttpDelete]
        public void DeleteUser(int id)
        {
            User user = _applicationDBContext.Users.SingleOrDefault(u => u.User_Id == id);
            if (user != null)
            {
                _applicationDBContext.Users.Remove(user);
                _applicationDBContext.SaveChanges();
            }
        }
        [NonAction]
        public string CreateHash(string inputPassword)
        {
            return Convert.ToBase64String(SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(inputPassword)));
        }
    }
}
