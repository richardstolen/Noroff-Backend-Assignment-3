using AutoMapper;
using Backend_Development_Assignment_3.DTOs.MovieDTOs;
using Backend_Development_Assignment_3.Models;

namespace Backend_Development_Assignment_3.Profiles
{
    public class MovieProfile : Profile
    {
        /*
         * Movie profile for DTO mappings.
         */
        public MovieProfile()
        {
            // Map all the characters that is in the movie to the movie
            CreateMap<Movie, MovieReadDTO>()
                .ForMember(cdto => cdto.Characters, opt => opt
                    .MapFrom(c => c.Character.Select(c => c.FullName).ToArray()));

            CreateMap<MoviePostDTO, Movie>();
            CreateMap<MoviePutDTO, Movie>();
        }
    }
}
