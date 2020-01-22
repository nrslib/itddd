using System;
using System.Collections.Generic;
using System.Text;

namespace EFInfrastructure.Persistence.DataModels
{
    public class OwnerCircle
    {
        public string OwnerId { get; set; }
        public UserDataModel Owner { get; set; }

        public string CircleId { get; set; }
        public CircleDataModel Circle { get; set; }
    }
}
