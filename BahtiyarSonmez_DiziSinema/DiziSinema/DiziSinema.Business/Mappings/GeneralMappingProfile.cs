using AutoMapper;
using DiziSinema.Entity.Concrete.Entitys;
using DiziSinema.Shared.DTOs;
using DiziSinema.Shared.DTOs.Core.Add;
using DiziSinema.Shared.DTOs.Core.Edit;
using DiziSinema.Shared.DTOs.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiziSinema.Business.Mappings
{
    public class GeneralMappingProfile: Profile
    {
        public GeneralMappingProfile()
        {
            #region Genre
            CreateMap<Genre, AddGenreDTO>().ReverseMap();
            CreateMap<Genre, EditGenreDTO>().ReverseMap();
            CreateMap<Genre, InGenreDTO>().ReverseMap();

            CreateMap<Genre, GenreDTO>()

                .ForMember(gdto=>gdto.MovieList, options=>options.MapFrom(m=>m.MovieGenres.Select(mg=>mg.Movie)))

                .ForMember(gdto => gdto.SerialTvList, options => options.MapFrom(s => s.SerialTvGenres.Select(sg => sg.SerialTv)))

                .ReverseMap();
            #endregion

            #region Movie
            CreateMap<Movie, AddMovieDTO>().ReverseMap();
            CreateMap<Movie, EditMovieDTO>().ReverseMap();
            CreateMap<Movie, InMovieDTO>().ReverseMap();

            CreateMap<Movie, MovieDTO>()
                .ForMember(mdto=>mdto.GenreList, options =>options.MapFrom(m=>m.MovieGenres.Select(mg=>mg.Genre)))
                .ReverseMap();
            #endregion

            #region SerialTv
            CreateMap<SerialTv, AddSerialTvDTO>().ReverseMap();
            CreateMap<SerialTv, EditSerialTvDTO>().ReverseMap();
            CreateMap<SerialTv, InSerialTvDTO>().ReverseMap();

            CreateMap<SerialTv, SerialTvDTO>()
                .ForMember(sdto=>sdto.GenreList, options=>options.MapFrom(s=>s.SerialTvGenres.Select(sg=>sg.Genre)))
                .ReverseMap();
            #endregion
        }
    }
}
