namespace VCMS.Core.Models
{
    /// <summary>
    /// Represents a prescribed medication in a prescription.
    /// </summary>
    public class PrescribedMeds
    {
        /// <summary>
        /// Get or set unique identifier for the prescription.
        /// </summary>
        public int PrescriptionId { get; set; }

        /// <summary>
        /// Get or set the prescription that this prescribed medication belongs to.
        /// </summary>
        public virtual Prescription Prescription { get; set; }

        /// <summary>
        /// Get or set unique identifier for the medication.
        /// </summary>
        public int MedicationId { get; set; }

        /// <summary>
        /// Get or set the medication that is prescribed.
        /// </summary>
        public virtual Medication Medication { get; set; }

        /// <summary>
        /// Get or set the quantity of the medication that is prescribed.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Get or set the price of the medication.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Get or set the total price of the medication.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Get or set the frequency of the medication.
        /// </summary>
        public string Frequency { get; set; }
    }
}
