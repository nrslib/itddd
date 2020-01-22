using System.Linq;
using ClArc.Sync;
using Microsoft.AspNetCore.Mvc;
using SnsApplicationPort.Circles.Create;
using SnsApplicationPort.Circles.Delete;
using SnsApplicationPort.Circles.Get;
using SnsApplicationPort.Circles.GetAll;
using SnsApplicationPort.Circles.GetCandidates;
using SnsApplicationPort.Circles.Join;
using SnsApplicationPort.Circles.Update;
using SnsApplicationPort.Users.Get;
using WebApplication.Models.Circles.Post;
using WebApplication.Models.Circles.Commons;
using WebApplication.Models.Circles.Get;
using WebApplication.Models.Circles.GetCandidates;
using WebApplication.Models.Circles.Index;
using WebApplication.Models.Circles.JoinMember;
using WebApplication.Models.Circles.Put;
using WebApplication.Models.Users.Commons;

namespace WebApplication.Controllers
{
    [Route("api/[controller]")]
    public class CircleController : Controller
    {
        private readonly UseCaseBus bus;

        public CircleController(UseCaseBus bus)
        {
            this.bus = bus;
        }
        
        [HttpGet]
        public CircleIndexResponseModel Index()
        {
            var inputData = new CircleGetAllInputData();
            var result = bus.Handle(inputData);

            var circles = result.Circles.Select(x => new CircleResponseModel(x)).ToList();

            return new CircleIndexResponseModel(circles);
        }

        [HttpGet("{id}")]
        public CircleGetResponseModel Get(string id)
        {
            var getCircleCommand = new CircleGetInputData(id);
            var getCircleResult = bus.Handle(getCircleCommand);

            var circle = new CircleResponseModel(getCircleResult.Circle);

            if (circle.OwnerId == null)
            {
                return new CircleGetResponseModel(circle, new UserResponseModel("", ""));
            }

            var getOwnerCommand = new UserGetInputData(circle.OwnerId);
            var getOwnerResult = bus.Handle(getOwnerCommand);

            var owner = new UserResponseModel(getOwnerResult.User);

            return new CircleGetResponseModel(circle, owner);
        }

        [HttpGet("{id}/[action]")]
        public CircleGetCandidatesResponseModel GetCandidates(string id, [FromQuery] int page, [FromQuery] int size)
        {
            var command = new CircleGetCandidatesInputData(id, page, size);
            var result = bus.Handle(command);

            var users = result.Users.Select(x => new UserResponseModel(x)).ToList();

            return new CircleGetCandidatesResponseModel(users);
        }

        [HttpPost]
        public CirclePostResponseModel Post([FromBody] CirclePostRequestModel request)
        {
            var command = new CircleCreateInputData(request.CircleName, request.OwnerId);
            var result = bus.Handle(command);

            return new CirclePostResponseModel(result.CreatedCircleId);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] CirclePutRequestModel request)
        {
            var command = new CircleUpdateInputData(id, request.Name);
            bus.Handle(command);
        }

        [HttpPut("{id}/[action]")]
        public void JoinMember(string id, [FromBody] CircleJoinMemberRequestModel request)
        {
            var command = new CircleJoinInputData(id, request.AddUserId);
            bus.Handle(command);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var command = new CircleDeleteInputData(id);
            bus.Handle(command);
        }
    }
}
