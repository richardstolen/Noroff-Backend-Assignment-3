using AutoMapper;
using Backend_Development_Assignment_3.DTOs.CharacterDTOs;
using Backend_Development_Assignment_3.Models;

namespace Backend_Development_Assignment_3.Profiles
{
    public class CharacterProfile : Profile
    {
        /*
         * Character profile for DTO mappings.
         */
        public CharacterProfile()
        {
            // Map all the movies that the character is in to the character
            CreateMap<Character, CharacterReadDTO>()
                .ForMember(cdto => cdto.Movies, opt => opt
                    .MapFrom(c => c.Movies.Select(c => c.Title).ToArray()));

            CreateMap<CharacterPostDTO, Character>();
            CreateMap<CharacterPutDTO, Character>();
        }
    }
}
