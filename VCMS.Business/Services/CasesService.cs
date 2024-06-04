namespace VCMS.Business.Services
{
    public class CasesService : ICasesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CasesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<GetCaseDto>> GetCaseByIdAsync(int id)
        {
            var patientCase = await _unitOfWork.Cases
                .FindAsync(c => c.Id == id, 
                    c => c.Patient.Client,
                    c => c.Patient.Species,
                    c => c.Diagnosis,
                    c => c.Doctor);
 
            if (patientCase is null)
            {
                return ResponseFactory.NotFound<GetCaseDto>(id);
            }

            var caseDto = _mapper.Map<GetCaseDto>(patientCase);
            return ResponseFactory.Ok(caseDto);
        }

        public async Task<Response<IEnumerable<GetCaseDto>>> GetAllCasesAsync()
        {
            var casesDto = await _unitOfWork.Cases.GetAllCasesWithClientNameSpeciesNameDiagnosisNameDoctorName();
            if (casesDto is null)
            {
                return ResponseFactory.NotFound<IEnumerable<GetCaseDto>>();
            }
            
            return ResponseFactory.Ok(casesDto);          
        }

        public async Task<Response<CreateCaseDto>> CreateCaseAsync(CreateCaseDto createCaseDto)
        {
            var patientCase = _mapper.Map<Case>(createCaseDto);

            await _unitOfWork.Cases.AddAsync(patientCase);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Created(createCaseDto);
        }

        public async Task<Response<UpdateCaseDto>> UpdateCaseAsync(int id, UpdateCaseDto updateCaseDto)
        {
            var patientCase = await _unitOfWork.Cases.GetByIdAsync(id);
            if (patientCase is null)
            {
                return ResponseFactory.NotFound<UpdateCaseDto>(id);
            }

            _mapper.Map(updateCaseDto, patientCase);

            _unitOfWork.Cases.Update(patientCase);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Ok(updateCaseDto);
        }

        public async Task<Response<DeleteCaseDto>> DeleteCaseAsync(int id)
        {
            var patientCase = await _unitOfWork.Cases.GetByIdAsync(id);
            if (patientCase is null)
            {
                return ResponseFactory.NotFound<DeleteCaseDto>(id);
            }

            _unitOfWork.Cases.Delete(patientCase);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.NoContent<DeleteCaseDto>();
        }
    }
}
