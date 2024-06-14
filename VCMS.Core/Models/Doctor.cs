namespace VCMS.Core.Models
{
    /// <summary>
    /// Represents a doctor.
    /// </summary>
    public class Doctor
    {
        /// <summary>
        /// Get or sets the unique identifier of the doctor.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the doctor.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the doctor.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the doctor.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the email of the doctor.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the year of graduation of the doctor.
        /// </summary>
        public int YearGraduated { get; set; }

        /// <summary>
        /// Gets or sets list of cases that the doctor is assigned to.
        /// </summary>
        public virtual List<Case> Cases { get; set; } = new List<Case>();
    }
}
