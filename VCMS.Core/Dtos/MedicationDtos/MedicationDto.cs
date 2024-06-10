namespace VCMS.Core.Dtos.MedicationDtos
{
    /// <summary>
    /// Data transfer object for medication entity.
    /// </summary>
    public class MedicationDto
    {
        /// <summary>
        /// Get or set medication's trade name.
        /// </summary>
        [Required(ErrorMessage = "TradeName is required.")]
        [MaxLength(50, ErrorMessage = "TradeName shouldn't be longer than 50 characters.")]
        public string TradeName { get; set; }

        /// <summary>
        /// Get or set medication's generic name.
        /// </summary>
        [Required(ErrorMessage = "GenericName is required.")]
        [MaxLength(50, ErrorMessage = "GenericName shouldn't be longer than 50 characters.")]
        public string GenericName { get; set; }

        /// <summary>
        /// Get or set medication's category.
        /// </summary>
        [Required(ErrorMessage = "Category is required.")]
        [MaxLength(50, ErrorMessage = "Category shouldn't be longer than 50 characters.")]
        public string Category { get; set; }

        /// <summary>
        /// Get or set medication's category.
        /// </summary>
        [Required(ErrorMessage = "Unit is required.")]
        [MaxLength(30, ErrorMessage = "Unit shouldn't be longer than 30 characters.")]
        public string Unit { get; set; }

        /// <summary>
        /// Get or set medication's unit in stock.
        /// </summary>
        [Required(ErrorMessage = "UnitInStock is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "UnitInStock should be greater than 0.")]
        public int UnitInStock { get; set; }

        /// <summary>
        /// Get or set medication's cost price per item.
        /// </summary>
        [Required(ErrorMessage = "CostPricePerItem is required.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "CostPricePerItem should be greater than 0.")]
        public decimal CostPricePerItem { get; set; }

        /// <summary>
        /// Get or set medication's sale price per item.
        /// </summary>
        [Required(ErrorMessage = "SalePricePerItem is required.")]
        [Range(0, (double)decimal.MaxValue, ErrorMessage = "SalePricePerItem should be greater than 0.")]
        public decimal SalePricePerItem { get; set; }

        /// <summary>
        /// Get or set medication's expiration data.
        /// </summary>
        [Required(ErrorMessage = "ExpirationDate is required.")]
        public DateOnly ExpirationDate { get; set; }
    }
}
