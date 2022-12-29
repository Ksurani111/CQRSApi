using CQRSApi.Models;
using CQRSApi.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace CQRSApi.CreateUserDetails.GetUserDetails
{
    public class GetUserDetailsCommand : IRequestHandler<GetUserDetailsQuery, List<UserDetails>>
    {
        private IUserRepo _repo;

        public GetUserDetailsCommand(IUserRepo repo)
        {
            _repo = repo;
        }   

        public async Task<List<UserDetails>> Handle(GetUserDetailsQuery query, CancellationToken cancellationToken)
        { 
            return await _repo.GetAllUser();    
        }
        
    }
}
