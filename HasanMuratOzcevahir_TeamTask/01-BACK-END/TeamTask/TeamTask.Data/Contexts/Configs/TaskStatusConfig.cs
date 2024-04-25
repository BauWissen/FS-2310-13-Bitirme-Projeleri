using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTask.Data.Contexts.Configs
{
    public class TaskStatusConfig : IEntityTypeConfiguration<Entity.Concrete.TaskStatus>
    {
        public void Configure(EntityTypeBuilder<Entity.Concrete.TaskStatus> builder)
        {
           builder.HasKey(x => new { x.StatusId, x.TaskId });
        }
    }
}
