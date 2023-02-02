using AutoMapper;
using Backend_Development_Assignment_3.DTOs.FranchiseDTOs;
using Backend_Development_Assignment_3.Models;

namespace Backend_Development_Assignment_3.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<Franchise, FranchiseReadDTO>();


            CreateMap<FranchisePostDTO, Franchise>();
            CreateMap<FranchisePutDTO, Franchise>();
        }
    }
}
