using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using CB.Database.EntityFramework;
using TodoTaskModel;


namespace TodoTaskDataContext
{
    public class TodoTaskEntityDataAccess: ModelDbContextBase<TodoTaskDbContext>, ITodoTaskDataAccess
    {
        #region Methods
        public void DeleteTask(int id)
        {
            UseDataContext(context => { if (RemoveTask(context, id)) context.SaveChanges(); });
        }

        public async Task DeleteTaskAsync(int id)
        {
            await UseDataContextAsync(async context =>
            {
                if (RemoveTask(context, id)) await context.SaveChangesAsync(); { }
            });
        }

        public TodoTask[] GetAllTasks()
        {
            return FetchDataContext(context => context.Tasks.ToArray());
        }

        public async Task<TodoTask[]> GetAllTasksAsync()
        {
            return await FetchDataContextAsync(context => context.Tasks.ToArrayAsync());
        }

        public TodoTask GetTask(int id)
        {
            return FetchDataContext(context => context.Tasks.Find(id));
        }

        public async Task<TodoTask> GetTaskAsync(int id)
        {
            return await FetchDataContextAsync(async context => await context.Tasks.FindAsync(id));
        }

        public TodoTask SaveTask(TodoTask task)
        {
            return FetchDataContext(context =>
            {
                var t = context.Tasks.Find(task.Id);
                if (t != null)
                {
                    t.CopyFrom(task);
                    context.SaveChanges();
                    return t;
                }
                context.Tasks.Add(task);
                context.SaveChanges();
                return task;
            });
        }

        public async Task<TodoTask> SaveTaskAsync(TodoTask task)
        {
            return await FetchDataContextAsync(async context =>
            {
                var t = await context.Tasks.FindAsync(task.Id);
                if (t != null)
                {
                    t.CopyFrom(task);
                    await context.SaveChangesAsync();
                    return t;
                }
                context.Tasks.Add(task);
                await context.SaveChangesAsync();
                return task;
            });
        }
        #endregion


        #region Implementation
        private static bool RemoveTask(TodoTaskDbContext context, int id)
        {
            var task = context.Tasks.Find(id);
            if (task == null) return false;

            context.Tasks.Remove(task);
            return true;
        }
        #endregion
    }
}