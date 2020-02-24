namespace _18.SnsApplication.Circles.GetSummaries
{
    public class CircleGetSummariesCommand
    {
        public CircleGetSummariesCommand(int size, int page)
        {
            Size = size;
            Page = page;
        }

        public int Size { get; }
        public int Page { get; }
    }
}
