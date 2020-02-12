using System.Linq;
using _04_to_12.Application.Users;
using _04_to_12.Application.Users.Delete;
using _04_to_12.Application.Users.Get;
using _04_to_12.Application.Users.Register;
using _04_to_12.Application.Users.Update;
using _04_to_12.ViewModels.Users.Commons;
using _04_to_12.ViewModels.Users.Get;
using _04_to_12.ViewModels.Users.Index;
using _04_to_12.ViewModels.Users.Post;
using _04_to_12.ViewModels.Users.Put;
using Microsoft.AspNetCore.Mvc;

namespace _04_to_12.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly UserApplicationService userApplicationService;

        // IoC Containerと連携して依存の解決が行われる
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
        public void Post([FromBody] UserPostRequestModel request)
        {
            var command = new UserRegisterCommand(request.UserName);
            userApplicationService.Register(command);
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
