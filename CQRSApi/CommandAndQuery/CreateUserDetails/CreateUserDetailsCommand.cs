using CQRSApi.Models;
using CQRSApi.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace CQRSApi.CreateUserDetails.Commands
{
    public class CreateUserDetailsCommand : IRequest<int>
    {
        public class CreateUserDetailsCommandHandler : IRequestHandler<CreateUserDetailsQuery, int>
        {
            private IUserRepo _repo;
            public CreateUserDetailsCommandHandler(IUserRepo repo)
            {
                _repo = repo;
            }
            public async Task<int> Handle(CreateUserDetailsQuery request, CancellationToken cancellationToken)
            {
                var userdetails = request.UserDetailsModel;
                userdetails.Id = Guid.NewGuid();
                return await _repo.CreateUser(request.UserDetailsModel);
             }
        }
    }
}
