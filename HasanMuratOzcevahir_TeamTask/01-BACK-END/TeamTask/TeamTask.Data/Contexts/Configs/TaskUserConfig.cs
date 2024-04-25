using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamTask.Entity.Concrete;

namespace TeamTask.Data.Contexts.Configs
{
    public class TaskUserConfig : IEntityTypeConfiguration<TaskUser>
    {
        public void Configure(EntityTypeBuilder<TaskUser> builder)
        {
            builder.HasKey(tu => new { tu.UserId, tu.TaskId });
        }
    }
}
