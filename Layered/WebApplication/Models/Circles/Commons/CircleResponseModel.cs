using System.Collections.Generic;
using SnsApplication.Circles.Commons;

namespace WebApplication.Models.Circles.Commons
{
    public class CircleResponseModel
    {
        public CircleResponseModel(CircleData source) : this(source.Id, source.Name, source.OwnerId, source.MemberIds)
        {
        }

        public CircleResponseModel(string id, string name, string ownerId, List<string> memberIds)
        {
            Id = id;
            Name = name;
            OwnerId = ownerId;
            MemberIds = memberIds;
        }

        public string Id { get; }
        public string Name { get; }
        public string OwnerId { get; }
        public List<string> MemberIds { get; } 
    }
}
