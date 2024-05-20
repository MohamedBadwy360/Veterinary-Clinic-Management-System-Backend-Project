using System.ComponentModel.DataAnnotations;

namespace VCMS.Core.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Phone]
        public string PhoneNumber { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Range(1990, 2023)]
        public int YearGraduated { get; set; }


        [JsonIgnore]
        public virtual List<Case> Cases { get; set; } = new List<Case>();
    }
}
