
using CQRSApi.CreateUserDetails.Commands;
using CQRSApi.CreateUserDetails.GetUserDetails;
using CQRSApi.Models;
using CQRSApi.Repository;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CQRSApi.Controllers
{ 
    public class UserDataController : Controller
    {
        private IMediator _mediator;
        private IUserRepo _userrepo;
        public UserDataController(IMediator mediator, IUserRepo userRepo)
        {
           _mediator = mediator;
            _userrepo = userRepo;
        }
       
        [HttpPost("CreateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult> Create([FromBody] UserDetails payload)
        {
            var query = new CreateUserDetailsQuery(payload);
            var result = await _mediator.Send(query);
            return Ok(result);
        }
      
        [HttpGet("GetUsers")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserDetails>> GetUser()
        { 
            var result = await _userrepo.GetAllUser();
            return Ok(result);
        }
        
        [HttpGet("GetUsersCQRS")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<UserDetails>> GetUsersCQRS()
        {
            var query = new GetUserDetailsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
