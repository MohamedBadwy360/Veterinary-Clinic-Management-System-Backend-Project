namespace VCMS.Core.Models
{
    /// <summary>
    /// Represents a prescription for a case.
    /// </summary>
    public class Prescription
    {
        /// <summary>
        /// Gets or sets the unique identifier for the prescription.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the case.
        /// </summary>
        public int CaseId { get; set; }

        /// <summary>
        /// Gets or sets the case the prescription is for.
        /// </summary>
        public virtual Case Case { get; set; }

        /// <summary>
        /// Gets or sets the date the prescription was created.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets the receipt for the prescription.
        /// </summary>
        public virtual Receipt Receipt { get; set; }

        /// <summary>
        /// Gets or sets the list of prescribed medications.
        /// </summary>
        public virtual List<PrescribedMeds> PrescribedMeds { get; set; } = new List<PrescribedMeds>();

        /// <summary>
        /// Gets or sets the list of medications.
        /// </summary>
        public virtual List<Medication> Medications { get; set; } = new List<Medication>();
    }
}
