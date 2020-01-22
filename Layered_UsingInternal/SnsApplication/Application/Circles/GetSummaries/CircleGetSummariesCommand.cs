namespace SnsApplication.Application.Circles.GetSummaries
{
    public class CircleGetSummariesCommand
    {
        public CircleGetSummariesCommand(int page, int size)
        {
            Page = page;
            Size = size;
        }

        public int Page { get; }
        public int Size { get; }
    }
}
