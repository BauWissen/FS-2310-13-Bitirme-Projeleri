using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Entity.Concrete.Identity;
using TeamTask.Entity.Concrete;
using TeamTask.Shared.Types;

namespace TeamTask.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        static readonly List<Role> _roles;
        static readonly List<User> _users;
        static ModelBuilderExtension()
        {
            #region _roles Generation
            _roles = new List<Role>
            {
                new Role{Name="Admin",  NormalizedName="ADMIN"},
                new Role{Name="User",  NormalizedName="USER"}
            };
            #endregion
            #region _user Generation
            _users = new List<User>
            {
                new User
                {
                    FirstName="Murat",
                    LastName="Öz",
                    UserName="muratoz",
                    NormalizedUserName="MURATOZ",
                    Email="muratoz@gmail.com",
                    NormalizedEmail="MURATOZ@GMAIL.COM",
                    PhoneNumber="5555555555",
                    EmailConfirmed=true
                },
                new User
                {
                    FirstName="Engin",
                    LastName="Niyazi",
                    UserName="engin",
                    NormalizedUserName="ENGIN",
                    Email="engin@gmail.com",
                    NormalizedEmail="ENGIN@GMAIL.COM",
                    PhoneNumber="5555555554",
                    EmailConfirmed=true
                }
            };
            var passwordHasher = new PasswordHasher<User>();
            _users[0].PasswordHash = passwordHasher.HashPassword(_users[0], "123456");
            _users[1].PasswordHash = passwordHasher.HashPassword(_users[1], "123456");
            #endregion
        }
        public static void GenerateUserData(this ModelBuilder mb)
        {
            #region User role asignation
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                     UserId=_users[0].Id,
                     RoleId=_roles[0].Id
                     //RoleId=roles.Where(x=>x.Name=="Admin").FirstOrDefault().Id,
                },
                   new IdentityUserRole<string>
                {
                     UserId=_users[0].Id,
                     RoleId=_roles[1].Id
                     //RoleId=roles.Where(x=>x.Name=="Admin").FirstOrDefault().Id,
                },
                new IdentityUserRole<string>
                {
                    UserId=_users[1].Id,
                    RoleId=_roles[1].Id
                }

            };
            mb.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
            #region User Notes
            List<UserNote> userNote = new List<UserNote> {
                new() { Id=1, Content="Bu benim test notumdur!", UserId=_users[0].Id,NoteTitle="Bunu unutma", Priority=UserNotePriorityType.High},
                 new() { Id=2, Content="Bu benim test notumdur2!", UserId=_users[1].Id,NoteTitle="Bunu unutma 2", Priority=UserNotePriorityType.Medium},
                  new() { Id=3, Content="Bu benim test notumdur3!", UserId=_users[0].Id,NoteTitle="Bunu unutma 3", Priority=UserNotePriorityType.Low},

            };
            #endregion

            mb.Entity<UserNote>().HasData(userNote);
            mb.Entity<User>().HasData(_users);
            mb.Entity<Role>().HasData(_roles);
        }
        public static void GenerateTaskData(this ModelBuilder mb)
        {
            #region Generate Task Status 
            mb.Entity<Status>().HasData(
            new Status { Id = 1, Color = "gray", DisplayText = "Başlanmadı" },
            new Status { Id = 2, Color = "yellow", DisplayText = "Sürüyor" },
            new Status { Id = 3, Color = "green", DisplayText = "Bitti" }
            );
            #endregion
            #region Generate Task
            mb.Entity<Entity.Concrete.Task>().HasData(
             new() { Id = 1, Title = "Task 1", EndDate = DateTime.Now.AddDays(1), Priority = TaskPriorityType.Low },
             new() { Id = 2, Title = "Task 2", EndDate = DateTime.Now.AddDays(2), Priority = TaskPriorityType.High },
             new() { Id = 3, Title = "Task 3", EndDate = DateTime.Now.AddDays(3), Priority = TaskPriorityType.Medium },
             new() { Id = 4, Title = "Task 4", EndDate = DateTime.Now.AddDays(1), Priority = TaskPriorityType.Low },
             new() { Id = 5, Title = "Task 5", EndDate = DateTime.Now.AddDays(2), Priority = TaskPriorityType.Medium }
             );
            #endregion
            #region Asign task status
            mb.Entity<Entity.Concrete.TaskStatus>().HasData(
             new Entity.Concrete.TaskStatus { TaskId = 1, StatusId = 1 },
             new Entity.Concrete.TaskStatus { TaskId = 2, StatusId = 2 },
             new Entity.Concrete.TaskStatus { TaskId = 3, StatusId = 1 },
             new Entity.Concrete.TaskStatus { TaskId = 4, StatusId = 3 },
             new Entity.Concrete.TaskStatus { TaskId = 5, StatusId = 3 }

             );
            #endregion
            #region Asign task to user
            mb.Entity<TaskUser>().HasData(
               new TaskUser { TaskId = 1, UserId = _users[0].Id },
               new TaskUser { TaskId = 2, UserId = _users[1].Id },
               new TaskUser { TaskId = 3, UserId = _users[0].Id },
               new TaskUser { TaskId = 4, UserId = _users[1].Id },
               new TaskUser { TaskId = 5, UserId = _users[0].Id });
            #endregion
        }
        public static void GenerateWorkingSpaceData(this ModelBuilder mb)
        {
            #region WorkingSpace Generation
            List<WorkingSpace> workingSpaces = new List<WorkingSpace> {
                new WorkingSpace
                {
                  Id =1,
                  UserId = _users[0].Id,
                  Color = "#ff0000",
                  Title = "Benim çalışma alanım 1",
                    Description = "Benim çalışma alanım 1 harika bir çalışma alanı!"
                 },
                 new WorkingSpace
                {
                     Id =2,
                     UserId = _users[0].Id,
                     Color = "#00ff00",
                     Title = "Benim çalışma alanım 2",
                     Description = "Benim çalışma alanım 2 harika bir çalışma alanı!"
                 }
            };
            mb.Entity<WorkingSpace>().HasData(workingSpaces);
            #endregion
            #region WorkingSpace Task asignation 
            mb.Entity<WorkingSpaceTask>().HasData(
             new WorkingSpaceTask { TaskId = 1, WorkingSpaceId = 1 },
             new WorkingSpaceTask { TaskId = 2, WorkingSpaceId = 2 },
             new WorkingSpaceTask { TaskId = 3, WorkingSpaceId = 1 },
             new WorkingSpaceTask { TaskId = 4, WorkingSpaceId = 2 },
             new WorkingSpaceTask { TaskId = 5, WorkingSpaceId = 2 }
         );
            #endregion
            #region WorkingSpaceComment Generation
            List<WorkingSpaceComment> wsCommentList = new List<WorkingSpaceComment>
            {
                new WorkingSpaceComment{Id=1, Comment="Harika bir çalışma alanı",UserId=_users[0].Id, WorkingSpaceId=workingSpaces[0].Id},
                new WorkingSpaceComment{Id=2, Comment="Güzel bir çalışma olacak",UserId=_users[1].Id, WorkingSpaceId=workingSpaces[1].Id},
                new WorkingSpaceComment{Id=3, Comment="Tekrar yorum yaptım",UserId=_users[0].Id, WorkingSpaceId=workingSpaces[0].Id},

            };
            mb.Entity<WorkingSpaceComment>().HasData(wsCommentList);
            #endregion
        }
    }

}
