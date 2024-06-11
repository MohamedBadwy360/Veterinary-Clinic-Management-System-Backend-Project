namespace VCMS.Core.Interfaces.ServicesInterfaces
{
    public interface IPrescriptionsService
    {
        Task<Response<GetPrescriptionDto>> GetPrescriptionByIdAsync(int id);
        Task<Response<IEnumerable<GetPrescriptionDto>>> GetAllPrescriptionsAsync();
        Task<Response<CreatePrescriptionDto>> CreatePrescriptionAsync(CreatePrescriptionDto createPrescriptionDto);
        Task<Response<UpdatePrescriptionDto>> UpdatePrescriptionAsync(int id, UpdatePrescriptionDto updatePrescriptionDto);
        Task<Response<DeletePrescriptionDto>> DeletePrescriptionAsync(int id);
        Task<Response<PrescribedMedsDto>> AddMedicationToPrescription(int prescriptionId,
            int medicationId, int quantity, string frequency);
        Task<Response<PrescribedMedsDto>> DeleteMedicationFromPrescription(int prescriptionId,
            int medicationId);
    }
}
