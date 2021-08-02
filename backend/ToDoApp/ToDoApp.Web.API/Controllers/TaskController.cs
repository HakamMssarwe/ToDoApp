using System.Web.Http;
using ToDoApp.Data;
using ToDoApp.Models;

namespace ToDoApp.Web.API.Controllers
{
    public class TaskController : ApiController
    {
        readonly ToDoAppDbContext _context;
        readonly IDataAccess _dataAccess;

        public TaskController(ToDoAppDbContext context)
        {
            _context = context;
        }


        // GET api/task/getusertasks
        [HttpPost]
        [Route("api/task/getusertasks")]
       
        public IHttpActionResult GetAllTasks(User user)
        {
            var temp = _dataAccess.GetTasks(user);
            if (temp == null)
                return BadRequest();

            return Ok(temp);

        }

        // DELETE api/task/delete
        [HttpDelete]
        [Route("api/task/delete")]
        public IHttpActionResult DeleteTask(Task task)
        {
            if (_dataAccess.DeleteTask(task))
                return Ok();

            return BadRequest();

        }


        // PUT api/task/updatestatus
        [HttpPut]
        [Route("api/task/updatestatus")]
        public IHttpActionResult UpdateStatus(Task task)
        {

            if (_dataAccess.EditTaskStatus(task))
                return Ok();

            return BadRequest();
        }



        // PUT api/task/updatetext
        [HttpPut]
        [Route("api/task/updatetext")]
        public IHttpActionResult UpdateText(Task task)
        {

            if (_dataAccess.EditTaskText(task))
                return Ok();

            return BadRequest();
        }



        // POST api/task/create
        [HttpPost]
        [Route("api/task/create")]
        public IHttpActionResult CreateTask(Task task)
        {

            if (_dataAccess.CreateTask(task))
                return Ok();

            return BadRequest();
        }




    }
}
