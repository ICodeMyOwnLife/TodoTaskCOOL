using System.Threading.Tasks;
using System.Web.Http;
using TodoTaskDataContext;
using TodoTaskModel;


namespace TodoTaskCOOL.Controllers
{
    public class TasksController: ApiController, ITodoTaskDataAccessAsync
    {
        #region Fields
        private readonly TodoTaskEntityDataAccess _dataAccess = new TodoTaskEntityDataAccess();
        #endregion


        #region Methods
        [HttpDelete]
        public async Task DeleteTaskAsync(int id)
        {
            await _dataAccess.DeleteTaskAsync(id);
        }

        [HttpGet]
        public async Task<TodoTask[]> GetAllTasksAsync()
        {
            return await _dataAccess.GetAllTasksAsync();
        }

        public async Task<TodoTask> GetTaskAsync(int id)
        {
            return await _dataAccess.GetTaskAsync(id);
        }

        [HttpPost]
        public async Task<TodoTask> SaveTaskAsync(TodoTask task)
        {
            return await _dataAccess.SaveTaskAsync(task);
        }
        #endregion
    }
}