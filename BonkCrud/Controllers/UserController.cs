using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BonkCrud.Models;

namespace BonkCrud.Controllers
{
    public class UserController : Controller
    {
        DataAccess objUser = new DataAccess();

        //get list of users
        [HttpGet]
        [Route("api/User/Index")]
        public IEnumerable<User> Index()
        {
            return objUser.GetAllUsers();
        }

        //get details of specific user
        [HttpPost]
        [Route("api/User/Details/{id}")]
        public User Details(int id)
        {
            return objUser.GetUserData(id);
        }

        //add new user
        [HttpGet]
        [Route("api/User/Create")]
        public int Create(User user)
        {
            return objUser.AddUser(user);
        }

        //update user
        [HttpPost]
        [Route("api/User/Edit")]
        public int Edit(User user)
        {
            try
            {
                return objUser.UpdateUser(user);
            }
            catch
            {
                throw;
            }
        }

        //delete user
        [HttpDelete]
        [Route("api/USer/Delete/{id}")]
        public int Delete(int id)
        {
            return objUser.DeleteItem(id);
        }
    }
}
