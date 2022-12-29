using CQRSApi.Models;
using MediatR;

namespace CQRSApi.CreateUserDetails.Commands
{
    public class CreateUserDetailsQuery : IRequest<int>
    {
        public UserDetails UserDetailsModel { get; set;}

        public CreateUserDetailsQuery(UserDetails userDetailsModel)
        {
            UserDetailsModel = userDetailsModel;
        }   
    }
}
