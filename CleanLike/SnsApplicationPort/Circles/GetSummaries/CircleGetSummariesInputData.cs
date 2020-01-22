using ClArc.Sync.Core;

namespace SnsApplicationPort.Circles.GetSummaries
{
    public class CircleGetSummariesInputData : IInputData<CircleGetSummariesOutputData>
    {
        public CircleGetSummariesInputData(int page, int size)
        {
            Page = page;
            Size = size;
        }

        public int Page { get; }
        public int Size { get; }
    }
}
