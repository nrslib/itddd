namespace SnsApplication.Circles.GetSummaries
{
    public class CircleSummaryData
    {
        public CircleSummaryData(string circleId, string ownerName)
        {
            CircleId = circleId;
            OwnerName = ownerName;
        }

        public string CircleId { get; }
        public string OwnerName { get; }
    }
}
