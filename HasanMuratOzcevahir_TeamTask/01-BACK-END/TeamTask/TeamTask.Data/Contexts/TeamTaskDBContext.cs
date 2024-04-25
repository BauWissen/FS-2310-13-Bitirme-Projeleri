using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeamTask.Data.Contexts.Configs;
using TeamTask.Data.Extensions;
using TeamTask.Entity.Concrete;
using TeamTask.Entity.Concrete.Identity;

namespace TeamTask.Data.Contexts
{
    public class TeamTaskDBContext : IdentityDbContext<User, Role, string>
    {
        public TeamTaskDBContext(DbContextOptions options) : base(options) { }
        public DbSet<WorkingSpace> WorkingSpaces { get; set; }
        public DbSet<Entity.Concrete.Task> Tasks { get; set; }
        public DbSet<WorkingSpaceTask> WorkingSpaceTasks { get; set; }
        public DbSet<TaskUser> TaskUsers { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Entity.Concrete.TaskStatus> TaskStatuses { get; set; }
        public DbSet<WorkingSpaceComment> WorkingSpaceComments { get; set; }    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.GenerateUserData();
            modelBuilder.GenerateWorkingSpaceData();
            modelBuilder.GenerateTaskData();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WorkingSpaceTaskConfig).Assembly);
            base.OnModelCreating(modelBuilder);
        }


    }
}
