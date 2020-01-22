namespace SnsApplication.Circles.Create
{
    public class CircleCreateResult
    {
        public CircleCreateResult(string createdCircleId)
        {
            CreatedCircleId = createdCircleId;
        }

        public string CreatedCircleId { get; }
    }
}
