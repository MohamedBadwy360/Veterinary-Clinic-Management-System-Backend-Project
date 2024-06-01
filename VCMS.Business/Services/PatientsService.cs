namespace VCMS.Business.Services
{
    public class PatientsService : IPatientsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Response<GetPatientDto>> GetPatientByIdAsync(int id)
        {
            var patient = await _unitOfWork.Patients.FindAsync(p => p.Id == id, new[] { "Client", "Species" });
            if (patient is null)
            {
                return ResponseFactory.NotFound<GetPatientDto>(id);
            }

            var patientDto = _mapper.Map<GetPatientDto>(patient);
            return ResponseFactory.Ok(patientDto);
        }

        public async Task<Response<IEnumerable<GetPatientDto>>> GetAllPatientsAsync()
        {
            // var patients = await _unitOfWork.Patients.FindAllAsync(p => p.Id >= 1, new[] { "Client", "Species" });

            var patientDtos = await _unitOfWork.Patients.GetAllPatientsWithClientNameAndSpeciesName();
            return (patientDtos is null) ?  ResponseFactory.NotFound<IEnumerable<GetPatientDto>>() : 
                 ResponseFactory.Ok(patientDtos);
        }


        public async Task<Response<CreatePatientDto>> CreatePatientAsync(CreatePatientDto createPatientDto)
        {
            var patient = _mapper.Map<Patient>(createPatientDto);

            await _unitOfWork.Patients.AddAsync(patient);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Created(createPatientDto);
        }

        public async Task<Response<UpdatePatientDto>> UpdatePatientAsync(int id, UpdatePatientDto updatePatientDto)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient is null)
            {
                return ResponseFactory.NotFound<UpdatePatientDto>(id);
            }

            _mapper.Map(updatePatientDto, patient);

            _unitOfWork.Patients.Update(patient);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Ok(updatePatientDto);
        }

        public async Task<Response<DeletePatientDto>> DeletePatientAsync(int id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient is null)
            {
                return ResponseFactory.NotFound<DeletePatientDto>(id);
            }

            _unitOfWork.Patients.Delete(patient);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.NoContent<DeletePatientDto>();
        }
    }
}
