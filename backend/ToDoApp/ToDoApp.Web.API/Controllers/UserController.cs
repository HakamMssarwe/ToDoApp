using System.Web.Http;
using System.Web.Http.Cors;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Web.API.Controllers
{
    public class UserController : ApiController
    {
        readonly ToDoAppDbContext _context;
        readonly IDataAccess _dataAccess;

        public UserController(ToDoAppDbContext context)
        {
            _context = context;
            _dataAccess = new DataAccess();
        }


        // POST api/user/validate
        [HttpPost]
        [Route("api/user/validate")]
        public IHttpActionResult ValidateUser(User user)
        {
            if (_dataAccess.ValidateUser(user))
                return Ok();

            return BadRequest();
        }



        // PUT api/user/changepassword
        [HttpPost]
        [Route("api/user/changepassword")]
        public IHttpActionResult ChangePassword(User user)
        {
            if (_dataAccess.ChangePassword(user))
                return Ok();

            return BadRequest();
        }


        // POST api/user/create
        [HttpPost]
        [Route("api/user/create")]
        public IHttpActionResult CreateUser(User user)
        {

            if (_dataAccess.CreateUser(user))
                return Ok();


            return BadRequest();

        }



    }
}
