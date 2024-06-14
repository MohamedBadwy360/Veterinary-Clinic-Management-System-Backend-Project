namespace VCMS.Core.Models
{
    /// <summary>
    /// Represents a species of animals.
    /// </summary>
    public class Species
    {
        /// <summary>
        /// Gets or sets the unique identifier for the species.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the species.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets a list of patients that belong to this species.
        /// </summary>
        /// <remarks>
        /// This is a navigational property used by Entity Framework to establish relationship between 
        /// the <see cref="Species"/> and <see cref="Patient"/> entities.
        /// </remarks>
        public virtual List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
