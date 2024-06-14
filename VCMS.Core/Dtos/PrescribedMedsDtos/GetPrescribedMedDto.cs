namespace VCMS.Core.Dtos.PrescribedMedsDtos
{
    /// <summary>
    /// Data Transfer Object for getting prescribed medication
    /// </summary>
    public class GetPrescribedMedDto
    {
        /// <summary>
        /// Gets or sets the medication name
        /// </summary>
        public string MedicationName { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the medication
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the price of the medication
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the total price of the medication
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Gets or sets the frequency of the medication
        /// </summary>
        public string Frequency { get; set; }
    }
}
