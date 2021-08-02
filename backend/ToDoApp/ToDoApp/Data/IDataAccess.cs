using System.Collections.Generic;
using ToDoApp.Models;

namespace ToDoApp.Data
{
    public interface IDataAccess
    {
        bool CreateUser(User user);

        bool ValidateUser(User user);

        bool ChangePassword(User user);

        IEnumerable<User> GetAllUsers();

        bool CreateTask(Models.Task task);

        bool EditTaskText(Models.Task task);

        bool EditTaskStatus(Models.Task task);

        bool DeleteTask(Models.Task task);


        IEnumerable<Models.Task> GetTasks(User user);
    }
}