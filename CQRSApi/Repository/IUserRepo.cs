using CQRSApi.Models;

namespace CQRSApi.Repository
{
    public interface IUserRepo
    {
        Task<List<UserDetails>> GetAllUser();
        Task<UserDetails> GetUser(Guid UserId);
        Task<int> CreateUser(UserDetails userDetails);
    }
}
