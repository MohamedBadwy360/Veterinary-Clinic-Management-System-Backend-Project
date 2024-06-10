
namespace VCMS.Business.Services
{
    public class MedicationsService : IMedicationsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicationsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<MedicationDto>> GetMedicationByIdAsync(int id)
        {
            var medication = await _unitOfWork.Medications.GetByIdAsync(id);
            if (medication is null)
            {
                return ResponseFactory.NotFound<MedicationDto>(id);
            }

            var medicationDto = _mapper.Map<MedicationDto>(medication);
            return ResponseFactory.Ok(medicationDto);
        }

        public async Task<Response<IEnumerable<MedicationDto>>> GetAllMedicationsAsync()
        {
            var medications = await _unitOfWork.Medications.GetAllAsync();
            if (medications is null)
            {
                return ResponseFactory.NotFound<IEnumerable<MedicationDto>>();
            }

            var medicationDtos = _mapper.Map<IEnumerable<MedicationDto>>(medications);
            return ResponseFactory.Ok(medicationDtos);
        }

        public async Task<Response<MedicationDto>> CreateMedicationAsync(MedicationDto medicationDto)
        {
            var medication = _mapper.Map<Medication>(medicationDto);

            await _unitOfWork.Medications.AddAsync(medication);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Created(medicationDto);
        }

        public async Task<Response<MedicationDto>> UpdateMedicationAsync(int id, MedicationDto medicationDto)
        {
            var medication = await _unitOfWork.Medications.GetByIdAsync(id);
            if (medication is null)
            {
                return ResponseFactory.NotFound<MedicationDto>(id);
            }

            _mapper.Map(medicationDto, medication);

            _unitOfWork.Medications.Update(medication);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Ok(medicationDto);
        }

        public async Task<Response<MedicationDto>> DeleteMedicationAsync(int id)
        {
            var medication = await _unitOfWork.Medications.GetByIdAsync(id);
            if (medication is null)
            {
                return ResponseFactory.NotFound<MedicationDto>(id);
            }

            _unitOfWork.Medications.Delete(medication);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.NoContent<MedicationDto>();
        }
    }
}
