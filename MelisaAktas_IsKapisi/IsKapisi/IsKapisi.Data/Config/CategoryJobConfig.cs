using IsKapisi.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace IsKapisi.Data.Config
{
    public class CategoryJobConfig : IEntityTypeConfiguration<CategoryJob>
    {
        public void Configure(EntityTypeBuilder<CategoryJob> builder)
        {
           builder.HasKey(x => new { x.CategoryId, x.JobId });
            builder.ToTable("CategoryJob");
            builder.HasData(
               

                new CategoryJob { JobId = 1, CategoryId = 1 },


                new CategoryJob { JobId = 2, CategoryId = 4 },


                new CategoryJob { JobId = 3, CategoryId = 2 },


                new CategoryJob { JobId = 4, CategoryId = 3 },
                new CategoryJob { JobId = 4, CategoryId = 5 },

                new CategoryJob { JobId = 5, CategoryId = 5 },



                new CategoryJob { JobId = 6, CategoryId = 3 },

                new CategoryJob { JobId = 7, CategoryId = 3 },


                new CategoryJob { JobId = 8, CategoryId = 3 },
                new CategoryJob { JobId = 8, CategoryId = 5 },

                new CategoryJob { JobId = 9, CategoryId = 4 },

                new CategoryJob { JobId = 10, CategoryId = 3 },


                new CategoryJob { JobId = 11, CategoryId = 1 });
               
                                 




        }
    }
}
