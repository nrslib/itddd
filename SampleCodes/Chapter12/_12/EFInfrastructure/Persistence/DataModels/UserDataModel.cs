using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _12.EFInfrastructure.Persistence.DataModels
{
    [Table("Users")]
    public class UserDataModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]

        public string Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
    }
}
