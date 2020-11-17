using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Auth.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.User.Queries.GetUserWithToken
{
    public class GetUserWithTokenQueryHandler : IRequestHandler<GetUserWithTokenQuery, UserWithTokenAm>
    {
        private readonly IUserManager _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public GetUserWithTokenQueryHandler(IUserManager userManager, IMapper mapper, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public async Task<UserWithTokenAm> Handle(GetUserWithTokenQuery request, CancellationToken cancellationToken)
        {
            ApplicationUser applicationUser = await _userManager.GetByEmail(request.Email);

            if (applicationUser == null)
            {
                throw new UnauthorizedException(nameof(ApplicationUser), request.Email);
            }

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(applicationUser, request.Password, false);

            if (!result.Succeeded)
            {
                throw new UnauthorizedException($"Invalid password: {request.Email}", result);
            }

            var userWithToken = _mapper.Map<UserWithTokenAm>(applicationUser);
            userWithToken.Token = _userManager.GenerateToken(applicationUser);
            
            return userWithToken;
        }
    }
}