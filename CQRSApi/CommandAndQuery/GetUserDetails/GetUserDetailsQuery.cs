using CQRSApi.Models;
using MediatR;

namespace CQRSApi.CreateUserDetails.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<List<UserDetails>>
    {
        public GetUserDetailsQuery()
        {
          
        }
    }
}
