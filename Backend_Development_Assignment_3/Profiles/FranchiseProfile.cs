using AutoMapper;
using Backend_Development_Assignment_3.DTOs.FranchiseDTOs;
using Backend_Development_Assignment_3.Models;

namespace Backend_Development_Assignment_3.Profiles
{
    public class FranchiseProfile : Profile
    {
        /*
         * Franchise profile for DTO mappings.
         */
        public FranchiseProfile()
        {
            // Map all the movies that the franchise contains to the character
            CreateMap<Franchise, FranchiseReadDTO>()
                .ForMember(cdto => cdto.Movies, opt => opt
                    .MapFrom(c => c.Movies.Select(c => c.Title).ToArray())); ;


            CreateMap<FranchisePostDTO, Franchise>();
            CreateMap<FranchisePutDTO, Franchise>();
        }
    }
}
