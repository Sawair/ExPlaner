using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExPlaner.API.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace ExPlaner.API.DAL.Repository
{
    public class UserRepository
    {
        protected DbSet<AppUser> Users;

        public UserRepository(AppDbContext dbContext)
        {
            Users = dbContext.Users;
        }

        public string GetUserId(string mail) => Users.First(u => u.Email == mail).Id;

        public AppUser GetUser(string userId) => Users.First(u => u.Id == userId);

    }
}
