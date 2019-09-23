using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExPlaner.API.DAL.EF;
using ExPlaner.API.DAL.Repository;
using Microsoft.AspNetCore.Http;

namespace ExPlaner.API.Service
{
    public class AccountService
    {
        private readonly UserRepository _userRepository;
        private readonly IHttpContextAccessor _httpContext;

        public AccountService(UserRepository userRepository, IHttpContextAccessor httpContext)
        {
            _userRepository = userRepository;
            _httpContext = httpContext;
        }

        public string GetCurrentUserId() =>
            _httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;

        public AppUser GetCurrentUser() =>
            _userRepository.GetUser(this.GetCurrentUserId());

    }
}
