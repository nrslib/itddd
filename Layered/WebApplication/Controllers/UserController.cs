using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SnsApplication.Users;
using SnsApplication.Users.Delete;
using SnsApplication.Users.Get;
using SnsApplication.Users.Register;
using SnsApplication.Users.Update;
using WebApplication.Models.Users.Post;
using WebApplication.Models.Users.Commons;
using WebApplication.Models.Users.Get;
using WebApplication.Models.Users.Index;
using WebApplication.Models.Users.Put;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserApplicationService userApplicationService;

        public UserController(UserApplicationService userApplicationService)
        {
            this.userApplicationService = userApplicationService;
        }

        [HttpGet]
        public UserIndexResponseModel Index()
        {
            var result = userApplicationService.GetAll();
            var users = result.Users.Select(x => new UserResponseModel(x.Id, x.Name)).ToList();

            return new UserIndexResponseModel(users);
        }

        [HttpGet("{id}")]
        public UserGetResponseModel Get(string id)
        {
            var command = new UserGetCommand(id);
            var result = userApplicationService.Get(command);

            var userModel = new UserResponseModel(result.User);

            return new UserGetResponseModel(userModel);
        }

        [HttpPost]
        public UserPostResponseModel Post([FromBody] UserPostRequestModel request)
        {
            var command = new UserRegisterCommand(request.UserName);
            var result = userApplicationService.Register(command);

            return new UserPostResponseModel(result.CreatedUserId);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] UserPutRequestModel request)
        {
            var command = new UserUpdateCommand(id, request.Name);
            userApplicationService.Update(command);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var command = new UserDeleteCommand(id);
            userApplicationService.Delete(command);
        }
    }
}
