using ClArc.Sync.Core;

namespace SnsApplicationPort.Circles.GetCandidates
{
    public class CircleGetCandidatesInputData : IInputData<CircleGetCandidatesOutputData>
    {
        public CircleGetCandidatesInputData(string circleId, int page, int size)
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
