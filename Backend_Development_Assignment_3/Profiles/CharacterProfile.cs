using AutoMapper;
using Backend_Development_Assignment_3.DTOs;
using Backend_Development_Assignment_3.Models;

namespace Backend_Development_Assignment_3.Profiles
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<Character, CharacterReadDTO>()
                .ForMember(cdto => cdto.Movies, opt => opt
                    .MapFrom(c => c.Movies.Select(c => c.Id).ToArray()));
            ;
        }
    }
}
