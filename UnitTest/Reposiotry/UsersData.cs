using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CQRSApi.Repository;
using CQRSApi.Models;
using Newtonsoft.Json;
using CQRSApi.CreateUserDetails.Commands;
using CQRSApi.CreateUserDetails.GetUserDetails;

namespace UnitTest.Reposiotry
{
    public class UsersData
    {
        private readonly Mock<IUserRepo> _userrepo;
        public UsersData()
        {
            _userrepo = new Mock<IUserRepo>();
        }
        [Fact]
        public async Task GetAllUsers()
        {
            //Arrange
            var userlist = "[{\"id\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"userName\": \"string\",\"city\": \"string\",\"dateOfBirth\": \"2022-12-23T09:53:49.76\"},{\"id\": \"8fafa070-1edc-4699-90d1-66d2d7198b9f\",\"userName\": \"Keyur\",\"city\": \"Ahmedabad\",\"dateOfBirth\": \"1990-12-31T09:53:49.76\"}]";
            var userRes = JsonConvert.DeserializeObject<List<UserDetails>>(userlist);
            _userrepo.Setup(x => x.GetAllUser()).Returns(Task.FromResult(userRes));
            var result = _userrepo.Object;
            //Assert
            var userDetails = await result.GetAllUser();
            Assert.NotNull(userDetails);
        }

        [Fact]
        public async Task GetAllUsersCQRS()
        {
            //Arrange
            var userlist = "[{\"id\": \"3fa85f64-5717-4562-b3fc-2c963f66afa6\",\"userName\": \"string\",\"city\": \"string\",\"dateOfBirth\": \"2022-12-23T09:53:49.76\"},{\"id\": \"8fafa070-1edc-4699-90d1-66d2d7198b9f\",\"userName\": \"Keyur\",\"city\": \"Ahmedabad\",\"dateOfBirth\": \"1990-12-31T09:53:49.76\"}]";
            var userRes = JsonConvert.DeserializeObject<List<UserDetails>>(userlist);
            _userrepo.Setup(x => x.GetAllUser()).Returns(Task.FromResult(userRes));

            //Calling Command And Query
            var handler = new GetUserDetailsCommand(_userrepo.Object);
            var query = new GetUserDetailsQuery();

            var result = await handler.Handle(query, default(CancellationToken));

            //Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task CreateUser()
        {
            //Arrange
            var userList = new UserDetails();
            userList.UserName = "test";
            userList.Id = Guid.NewGuid();
            userList.City = "test city";
            userList.DateOfBirth = DateTime.Now;
            _userrepo.Setup(x => x.CreateUser(userList)).Returns(Task.FromResult(1));

            var handler = new CreateUserDetailsCommand.CreateUserDetailsCommandHandler(_userrepo.Object);
            var query = new CreateUserDetailsQuery(userList);

            var result = await handler.Handle(query, default(CancellationToken));

            //Assert
            Assert.NotNull(result.GetType());


        }
    }
}
