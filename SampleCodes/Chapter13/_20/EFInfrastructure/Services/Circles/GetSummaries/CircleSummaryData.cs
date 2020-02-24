namespace _20.EFInfrastructure.Services.Circles.GetSummaries
{
    public class CircleSummaryData
    {
        public CircleSummaryData(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }
        public string Name { get; }
    }
}
