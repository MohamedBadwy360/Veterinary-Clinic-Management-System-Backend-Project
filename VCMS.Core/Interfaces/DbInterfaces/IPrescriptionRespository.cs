namespace VCMS.Core.Interfaces.DbInterfaces
{
    public interface IPrescriptionRespository : IBaseRepository<Prescription>
    {
        Task<IEnumerable<GetPrescriptionDto>> GetAllPrescriptionsAsync();
    }
}
