namespace VCMS.Core.Models
{
    /// <summary>
    /// Represents a client of the veterinary clinic.
    /// </summary>
    public class Client
    {
        /// <summary>
        /// Gets or sets the unique identifier for the client.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the first name of the client.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the last name of the client.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the address of the client.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the client.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets list of patients of the client.
        /// </summary>
        public virtual List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
