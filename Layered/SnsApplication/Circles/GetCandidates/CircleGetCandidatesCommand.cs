namespace SnsApplication.Circles.GetCandidates
{
    public class CircleGetCandidatesCommand
    {
        public CircleGetCandidatesCommand(string circleId, int page, int size)
        {
            CircleId = circleId;
            Page = page;
            Size = size;
        }

        public string CircleId { get; }
        /// <summary>
        /// One-Origin
        /// </summary>
        public int Page { get; }
        public int Size { get; }
    }
}
