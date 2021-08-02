using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public class DataAccess : IDataAccess
    {

        public bool CreateUser(User user)
        {
            using(ToDoAppDbContext context = new ToDoAppDbContext())
            {
                if (context.Users.FirstOrDefault(userInDB => userInDB.Username == user.Username) != null)
                    return false;

                try
                {
                    context.Users.Add(new User() { Username = user.Username, Password = user.Password });
                    return context.SaveChanges() > 0;

                }
                catch
                {

                    return false;
                }
            }

        }

        public  bool ValidateUser(User user)
        {
            using (ToDoAppDbContext context = new ToDoAppDbContext())
            {
                if (context.Users.FirstOrDefault(userInDB => userInDB.Username == user.Username && userInDB.Password == user.Password) == null)
                    return false;

                return true;

            }
        }

        public  bool ChangePassword(User user)
        {
            using (ToDoAppDbContext context = new ToDoAppDbContext())
            {
                var tempUser = context.Users.FirstOrDefault(userInDB => userInDB.Username == user.Username);

                if (tempUser == null)
                    return false;

                try
                {
                    tempUser.Password = user.Password;
                    return context.SaveChanges() > 0;

                }
                catch 
                {

                    return false; 
                }
               
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            using (ToDoAppDbContext context = new ToDoAppDbContext())
            {
                return context.Users;
            }
        }

        public  bool CreateTask(Models.Task task)
        {
            using (ToDoAppDbContext context = new ToDoAppDbContext())
            {
                if (context.Tasks.FirstOrDefault(taskInDb => taskInDb.Text == task.Text && taskInDb.User.Username == task.User.Username) != null)
                    return false;


                try
                {
                    context.Tasks.Add(new Models.Task() {Text = task.Text, User = context.Users.Find(task.User.Username)});
                    return context.SaveChanges() > 0;
            
                }
                catch
                {
                    return false;
                }

                

            }
        }

        public  bool EditTaskText(Models.Task task)
        {
            using (ToDoAppDbContext context = new ToDoAppDbContext())
            {
                try
                {
                    var tempTask = context.Tasks.FirstOrDefault(taskInDb => taskInDb.Id == task.Id);

                    if (tempTask == null)
                        return false;


                    tempTask.Text = task.Text;
                    return context.SaveChanges() > 0;
                  
                }
                catch
                {
                    return false;
                }
               
            }
        }

        public  bool EditTaskStatus(Models.Task task)
        {
            using (ToDoAppDbContext context = new ToDoAppDbContext())
            {

                try
                {
                    var tempTask = context.Tasks.FirstOrDefault(taskInDb => taskInDb.Id == task.Id);

                    if (tempTask == null)
                        return false;

                    tempTask.IsCompleted = !tempTask.IsCompleted;

                    return context.SaveChanges() > 0;

                }
                catch (Exception)
                {

                    return false;
                }
                
            }
        }

        public  bool DeleteTask(Models.Task task)
        {
            using (ToDoAppDbContext context = new ToDoAppDbContext())
            {
                try
                {
                    var temp = context.Tasks.Find(task.Id);
                    context.Tasks.Remove(temp);
                    return context.SaveChanges() > 0;

                }
                catch
                {
                    return false;
                }
 
            }
        }


        public  IEnumerable<Models.Task> GetTasks(User user)
        {
            try
            {
                if (!ValidateUser(user))
                    return null;

                var context = new ToDoAppDbContext();
                return context.Tasks.Where(taskInDb => taskInDb.User.Username == user.Username);

            }
            catch
            {
                 return new List<Models.Task>(); ;
            }

        }


    }
}
