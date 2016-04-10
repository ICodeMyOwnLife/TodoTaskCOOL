using System.Data.Entity;
using TodoTaskModel;


namespace TodoTaskDataContext
{
    public class TodoTaskDbContext: DbContext
    {
        #region  Constructors & Destructor
        public TodoTaskDbContext(): base("name=todoTaskContext") { }
        #endregion


        #region  Properties & Indexers
        public DbSet<TodoTask> Tasks { get; set; }
        #endregion


        #region Override
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new TodoTaskMap());
        }
        #endregion
    }
}