namespace TodoTaskDataContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTablesAndStoredProcedures : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TodoTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 512),
                        Deadline = c.DateTime(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateStoredProcedure(
                "dbo.InsertTask",
                p => new
                    {
                        Content = p.String(maxLength: 512),
                        Deadline = p.DateTime(),
                        IsDone = p.Boolean(),
                    },
                body:
                    @"INSERT [dbo].[TodoTasks]([Content], [Deadline], [IsDone])
                      VALUES (@Content, @Deadline, @IsDone)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[TodoTasks]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[TodoTasks] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.UpdateTask",
                p => new
                    {
                        Id = p.Int(),
                        Content = p.String(maxLength: 512),
                        Deadline = p.DateTime(),
                        IsDone = p.Boolean(),
                    },
                body:
                    @"UPDATE [dbo].[TodoTasks]
                      SET [Content] = @Content, [Deadline] = @Deadline, [IsDone] = @IsDone
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.DeleteTask",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[TodoTasks]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.DeleteTask");
            DropStoredProcedure("dbo.UpdateTask");
            DropStoredProcedure("dbo.InsertTask");
            DropTable("dbo.TodoTasks");
        }
    }
}
