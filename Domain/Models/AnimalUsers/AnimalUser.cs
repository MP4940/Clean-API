using System.ComponentModel.DataAnnotations;

namespace Domain.Models.AnimalUsers
{
    public class AnimalUser
    {
        [Key]
        public required Guid UserID { get; set; }
        public required Guid AnimalID { get; set; }
    }
}