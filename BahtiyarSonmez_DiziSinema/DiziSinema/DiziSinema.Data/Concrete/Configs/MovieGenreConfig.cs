using DiziSinema.Entity.Concrete.JunctionClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Data.Concrete.Configs
{
    public class MovieGenreConfig : IEntityTypeConfiguration<MovieGenre>
    {
        public void Configure(EntityTypeBuilder<MovieGenre> builder)
        {
            builder.HasKey(m => new {m.MovieId, m.GenreId});
            builder.ToTable("MovieGenres");
            builder.HasData(
                new MovieGenre { MovieId = 1, GenreId = 1 },
                new MovieGenre { MovieId = 1, GenreId = 4 },

                new MovieGenre { MovieId = 2, GenreId = 2 },
                new MovieGenre { MovieId = 2, GenreId = 3 },

                new MovieGenre { MovieId = 3, GenreId = 2 },
                new MovieGenre { MovieId = 3, GenreId = 3 },
                new MovieGenre { MovieId = 3, GenreId = 4 },

                new MovieGenre { MovieId = 4, GenreId = 1 },
                new MovieGenre { MovieId = 4, GenreId = 3 },

                new MovieGenre { MovieId = 5, GenreId = 5 },
                new MovieGenre { MovieId = 5, GenreId = 3 },

                new MovieGenre { MovieId = 6, GenreId = 5 });
        }
    }
}
