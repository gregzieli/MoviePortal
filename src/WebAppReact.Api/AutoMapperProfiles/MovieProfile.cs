using AutoMapper;
using System.Linq;
using WebAppReact.Contract;
using WebAppReact.Domain.Models;

namespace WebAppReact.Api.AutoMapperProfiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieItem>()
                .ForMember(dest => dest.ReviewCount, x => x.MapFrom(src => src.Reviews.Count))
                .ForMember(dest => dest.DirectorName, x => x.MapFrom(src => src.Director.Name));

            CreateMap<Movie, MovieDetail>()
                .ForMember(dest => dest.Cast, x => x.MapFrom(src => src.Cast.Select(e => e.Actor)));

            CreateMap<Director, DirectorDto>();
            CreateMap<Actor, ActorDto>();
            CreateMap<Review, ReviewDto>();
        }
    }
}
