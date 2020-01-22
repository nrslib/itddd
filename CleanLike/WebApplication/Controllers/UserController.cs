using System.Linq;
using ClArc.Sync;
using Microsoft.AspNetCore.Mvc;
using SnsApplicationPort.Users.Delete;
using SnsApplicationPort.Users.Get;
using SnsApplicationPort.Users.GetAll;
using SnsApplicationPort.Users.Register;
using SnsApplicationPort.Users.Update;
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
        private readonly UseCaseBus bus;

        public UserController(UseCaseBus bus)
        {
            this.bus = bus;
        }

        [HttpGet]
        public UserIndexResponseModel Index()
        {
            var inputData = new UserGetAllInputData();
            var outputData = bus.Handle(inputData);
            var users = outputData.Users.Select(x => new UserResponseModel(x.Id, x.Name)).ToList();

            return new UserIndexResponseModel(users);
        }

        [HttpGet("{id}")]
        public UserGetResponseModel Get(string id)
        {
            var inputData = new UserGetInputData(id);
            var outputData = bus.Handle(inputData);

            var userModel = new UserResponseModel(outputData.User);

            return new UserGetResponseModel(userModel);
        }

        [HttpPost]
        public UserPostResponseModel Post([FromBody] UserPostRequestModel request)
        {
            var inputData = new UserRegisterInputData(request.UserName);
            var outputData = bus.Handle(inputData);

            return new UserPostResponseModel(outputData.CreatedUserId);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] UserPutRequestModel request)
        {
            var inputData = new UserUpdateInputData(id, request.Name);
            bus.Handle(inputData);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var inputData = new UserDeleteInputData(id);
            bus.Handle(inputData);
        }
    }
}
