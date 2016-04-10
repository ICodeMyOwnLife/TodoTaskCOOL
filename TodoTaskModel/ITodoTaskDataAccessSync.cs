namespace TodoTaskModel
{
    public interface ITodoTaskDataAccessSync
    {
        #region Abstract
        void DeleteTask(int id);
        TodoTask[] GetAllTasks();
        TodoTask GetTask(int id);
        TodoTask SaveTask(TodoTask task);
        #endregion
    }
}