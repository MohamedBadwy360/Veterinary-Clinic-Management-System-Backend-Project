namespace VCMS.Core.Dtos.PrescribedMedsDtos
{
    /// <summary>
    /// Data taranfer object for prescibed medication
    /// </summary>
    public class PrescribedMedsDto
    {
        public int PrescriptionId { get; set; }
        public int MedicationId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string Frequency { get; set; }
    }
}
