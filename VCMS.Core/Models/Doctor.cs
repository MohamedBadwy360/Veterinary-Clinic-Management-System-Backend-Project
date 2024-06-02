using System.ComponentModel.DataAnnotations;

namespace VCMS.Core.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int YearGraduated { get; set; }

        public virtual List<Case> Cases { get; set; } = new List<Case>();
    }
}
