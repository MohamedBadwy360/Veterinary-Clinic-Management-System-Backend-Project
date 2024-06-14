namespace VCMS.Core.Models
{
    /// <summary>
    /// Represents a Patient in the system.
    /// </summary>
    public class Patient
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Patient.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or set the Unique Identifier for the Client.
        /// </summary>
        public int ClientId { get; set; }

        /// <summary>
        /// Gets or sets the Client for the Patient.
        /// </summary>
        public virtual Client Client { get; set; }

        /// <summary>
        /// Gets or sets the Unique Identifier for the Species.
        /// </summary>
        public int SpeciesId { get; set; }

        /// <summary>
        /// Gets or sets the Species for the Patient.
        /// </summary>
        public virtual Species Species { get; set; }

        /// <summary>
        /// Get or sets the count of the Patient.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Represents Patient's Sex. 0 for Female and 1 for Male. 
        /// </summary>
        public ESex Sex { get; set; }

        /// <summary>
        /// Gets or sets the Patient's Age.
        /// </summary>
        public string Age { get; set; }

        /// <summary>
        /// Gets or sets list of Cases for the Patient.
        /// </summary>
        public virtual List<Case> Cases { get; set; } = new List<Case>(); 
    }
}
