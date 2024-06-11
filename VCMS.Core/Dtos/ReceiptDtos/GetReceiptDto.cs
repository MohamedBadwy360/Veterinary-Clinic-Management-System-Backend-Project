namespace VCMS.Core.Dtos.ReceiptDtos
{
    /// <summary>
    /// Represents data tranfer object for retrieving receipt.
    /// </summary>
    public class GetReceiptDto : ReceiptDto
    {
        /// <summary>
        /// Gets or sets the total price of the receipt.
        /// </summary>
        [Required(ErrorMessage = "TotalPrice is required.")]
        public decimal TotalPrice { get; set; }
    }
}
