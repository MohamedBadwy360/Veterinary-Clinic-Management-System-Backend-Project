namespace VCMS.Core.Dtos.PrescribedMedsDtos
{
    public class GetPrescribedMedDto
    {
        public string MedicationName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string Frequency { get; set; }
    }
}
