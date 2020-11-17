using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.User.Queries.GetUserWithToken
{
    public class UserWithTokenAm : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Token { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<ApplicationUser, UserWithTokenAm>()
                .ForMember(d => d.Token, opt => opt.Ignore())
                ;
        }
    }
}