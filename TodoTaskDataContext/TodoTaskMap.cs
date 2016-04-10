using System.Data.Entity.ModelConfiguration;
using TodoTaskModel;


namespace TodoTaskDataContext
{
    public class TodoTaskMap: EntityTypeConfiguration<TodoTask>
    {
        public TodoTaskMap()
        {
            Property(t => t.Id).HasColumnOrder(50);
            Property(t => t.Content).HasColumnOrder(70).HasMaxLength(512).IsRequired();
            Property(t => t.Deadline).HasColumnOrder(90);
            Property(t => t.IsDone).HasColumnOrder(110);

            MapToStoredProcedures(s =>
            {
                s.Insert(i => i.HasName("InsertTask", "dbo"));
                s.Delete(d => d.HasName("DeleteTask", "dbo"));
                s.Update(u => u.HasName("UpdateTask", "dbo"));
            });
        }
    }
}