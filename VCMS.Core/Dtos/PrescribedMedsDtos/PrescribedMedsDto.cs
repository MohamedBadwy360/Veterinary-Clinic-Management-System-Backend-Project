namespace VCMS.Core.Dtos.PrescribedMedsDtos
{
    /// <summary>
    /// Data taranfer object for prescibed medication.
    /// </summary>
    public class PrescribedMedsDto
    {
        /// <summary>
        /// Gets or sets the prescription identifier.
        /// </summary>
        public int PrescriptionId { get; set; }

        /// <summary>
        /// Gets or sets the medication identifier.
        public int MedicationId { get; set; }

        /// <summary>
        /// Gets or sets the medication quantity.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the medication Price.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the medication total price.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the medication frequency.
        /// </summary>
        public string Frequency { get; set; }
    }
}
