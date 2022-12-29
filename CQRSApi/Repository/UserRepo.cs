using Azure.Core;
using CQRSApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CQRSApi.Repository
{
    public class UserRepo : IUserRepo
    {
        private UserDetailsContext context;

        public UserRepo(UserDetailsContext context)
        { 
            this.context = context;
        }
        public async Task<int> CreateUser(UserDetails userDetails)
        {
            context.UserDetails.Add(userDetails);
            return await context.SaveChangesAsync();
        }

        public async Task<List<UserDetails>> GetAllUser()
        {
            return await context.UserDetails.ToListAsync();
        }

        public Task<UserDetails> GetUser(Guid UserId)
        {
            throw new NotImplementedException();
        }
    }
}
