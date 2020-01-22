using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SnsApplication.Circles;
using SnsApplication.Circles.Create;
using SnsApplication.Circles.Delete;
using SnsApplication.Circles.Get;
using SnsApplication.Circles.GetCandidates;
using SnsApplication.Circles.Join;
using SnsApplication.Circles.Update;
using SnsApplication.Users;
using SnsApplication.Users.Get;
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
        private readonly CircleApplicationService circleApplicationService;
        private readonly UserApplicationService userApplicationService;
        private readonly ICircleQueryService circleQueryService;

        public CircleController(CircleApplicationService circleApplicationService, UserApplicationService userApplicationService, ICircleQueryService circleQueryService)
        {
            this.circleApplicationService = circleApplicationService;
            this.userApplicationService = userApplicationService;
            this.circleQueryService = circleQueryService;
        }

        [HttpGet]
        public CircleIndexResponseModel Index()
        {
            var result = circleApplicationService.GetAll();

            var circles = result.Circles.Select(x => new CircleResponseModel(x)).ToList();

            return new CircleIndexResponseModel(circles);
        }

        [HttpGet("{id}")]
        public CircleGetResponseModel Get(string id)
        {
            var getCircleCommand = new CircleGetCommand(id);
            var getCircleResult = circleApplicationService.Get(getCircleCommand);

            var circle = new CircleResponseModel(getCircleResult.Circle);

            if (circle.OwnerId == null)
            {
                return new CircleGetResponseModel(circle, new UserResponseModel("", ""));
            }

            var getOwnerCommand = new UserGetCommand(circle.OwnerId);
            var getOwnerResult = userApplicationService.Get(getOwnerCommand);

            var owner = new UserResponseModel(getOwnerResult.User);

            return new CircleGetResponseModel(circle, owner);
        }

        [HttpGet("{id}/[action]")]
        public CircleGetCandidatesResponseModel GetCandidates(string id, [FromQuery] int page, [FromQuery] int size)
        {
            var command = new CircleGetCandidatesCommand(id, page, size);
            var result = circleQueryService.GetCandidates(command);

            var users = result.Users.Select(x => new UserResponseModel(x)).ToList();

            return new CircleGetCandidatesResponseModel(users);
        }

        [HttpPost]
        public CirclePostResponseModel Post([FromBody] CirclePostRequestModel request)
        {
            var command = new CircleCreateCommand(request.CircleName, request.OwnerId);
            var result = circleApplicationService.Create(command);

            return new CirclePostResponseModel(result.CreatedCircleId);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] CirclePutRequestModel request)
        {
            var command = new CircleUpdateCommand(id, request.Name);
            circleApplicationService.Update(command);
        }

        [HttpPut("{id}/[action]")]
        public void JoinMember(string id, [FromBody] CircleJoinMemberRequestModel request)
        {
            var command = new CircleJoinCommand(id, request.AddUserId);
            circleApplicationService.Join(command);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var command = new CircleDeleteCommand(id);
            circleApplicationService.Delete(command);
        }
    }
}
