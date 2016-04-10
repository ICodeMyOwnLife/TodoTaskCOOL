using System.Threading.Tasks;


namespace TodoTaskModel
{
    public interface ITodoTaskDataAccessAsync
    {
        #region Abstract
        Task DeleteTaskAsync(int id);
        Task<TodoTask[]> GetAllTasksAsync();
        Task<TodoTask> GetTaskAsync(int id);
        Task<TodoTask> SaveTaskAsync(TodoTask task);
        #endregion
    }
}