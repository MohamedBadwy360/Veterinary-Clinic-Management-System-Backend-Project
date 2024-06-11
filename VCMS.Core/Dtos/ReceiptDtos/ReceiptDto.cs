namespace VCMS.Core.Dtos.ReceiptDtos
{
    /// <summary>
    /// Abstarct data transfer object for receipt entity.
    /// </summary>
    public abstract class ReceiptDto
    {
        /// <summary>
        /// Gets or sets the foreign key of the prescription.
        /// </summary>
        [Required(ErrorMessage = "PrescriptionId is required.")]
        public int PrescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the date of the receipt.
        /// </summary>
        [Required(ErrorMessage = "Date is required.")]
        public DateOnly Date { get; set; }
    }
}
