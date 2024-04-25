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
    public class WorkingSpaceTaskConfig : IEntityTypeConfiguration<WorkingSpaceTask>
    {
        public void Configure(EntityTypeBuilder<WorkingSpaceTask> builder)
        {
           builder.HasKey(x => new { x.TaskId, x.WorkingSpaceId });
        }
    }
}
