namespace WebApplication.Models.Circles.Post
{
    public class CirclePostResponseModel
    {
        public CirclePostResponseModel(string createdCircleId)
        {
            CreatedCircleId = createdCircleId;
        }

        public string CreatedCircleId { get; }
    }
}
