using AutoMapper;
using Backend_Development_Assignment_3.DTOs.MovieDTOs;
using Backend_Development_Assignment_3.Models;

namespace Backend_Development_Assignment_3.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieReadDTO>();


            CreateMap<MoviePostDTO, Movie>();
            CreateMap<MoviePutDTO, Movie>();
        }
    }
}
