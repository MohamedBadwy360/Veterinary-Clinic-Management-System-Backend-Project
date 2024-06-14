namespace VCMS.Core.Models
{
    /// <summary>
    /// Represents a medication.
    /// </summary>
    public class Medication
    {
        /// <summary>
        /// Gets or sets the unique identifier for the medication.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the trade name of the medication.
        /// </summary>
        public string TradeName { get; set; }

        /// <summary>
        /// Gets or sets the generic name of the medication.
        /// </summary>
        public string GenericName { get; set; }

        /// <summary>
        /// Gets or sets the category of the medication.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the unit of the medication.
        /// </summary>
        public string Unit { get; set; }

        /// <summary>
        /// Gets or sets the unit in stock of the medication.
        /// </summary>
        public int UnitInStock { get; set; }

        /// <summary>
        /// Gets or sets the cost price per item of the medication.
        /// </summary>
        public decimal CostPricePerItem { get; set; }

        /// <summary>
        /// Gets or sets the sale price per item of the medication.
        /// </summary>
        public decimal SalePricePerItem { get; set; }

        /// <summary>
        /// Gets or sets the expiration date of the medication.
        /// </summary>
        public DateOnly ExpirationDate { get; set; }

        /// <summary>
        /// Gets or sets list of prescribed medications.
        /// </summary>
        public virtual List<PrescribedMeds> PrescribedMeds { get; set; } = new List<PrescribedMeds>();

        /// <summary>
        /// Gets or sets list of prescriptions in which this medication used.
        /// </summary>
        public virtual List<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
