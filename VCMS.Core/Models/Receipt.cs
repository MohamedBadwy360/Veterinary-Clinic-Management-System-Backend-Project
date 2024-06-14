namespace VCMS.Core.Models
{
    /// <summary>
    /// Represents a receipt for a prescription.
    /// </summary>
    public class Receipt
    {
        /// <summary>
        /// Gets or sets the unique identifier for the receipt.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the prescription.
        /// </summary>
        public int PrescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the prescription associated with the receipt.
        /// </summary>
        public virtual Prescription Prescription { get; set; }

        /// <summary>
        /// Gets or sets the date when the receipt was issued.
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Gets or sets the total price of the receipt.
        /// </summary>
        public decimal TotalPrice { get; set; }
    }
}
