namespace VCMS.Business.Services
{
    public class DiagnosisService : IDiagnosisService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DiagnosisService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<DiagnosisDto>> GetDiagnosisByIdAsync(int id)
        {
            var diagnosis = await _unitOfWork.Diagnostics.GetByIdAsync(id);
            if (diagnosis is null)
            {
                return ResponseFactory.NotFound<DiagnosisDto>(id);
            }

            var diagnosisDto = _mapper.Map<DiagnosisDto>(diagnosis);
            return ResponseFactory.Ok(diagnosisDto);
        }
        public async Task<Response<IEnumerable<DiagnosisDto>>> GetAllDiagnosisAsync()
        {
            var diagnostics = await _unitOfWork.Diagnostics.GetAllAsync();
            if (diagnostics is null)
            {
                return ResponseFactory.NotFound<IEnumerable<DiagnosisDto>>();
            }

            var diagnosticsDtos = _mapper.Map<IEnumerable<DiagnosisDto>>(diagnostics);
            return ResponseFactory.Ok(diagnosticsDtos);
        }
        public async Task<Response<DiagnosisDto>> CreateDiagnosisAsync(DiagnosisDto diagnosisDto)
        {
            if (!!IsValidDiagnosisName(diagnosisDto.Name))
            {
                return ResponseFactory.BadRequest<DiagnosisDto>("You inserted incorrect letter in diagnosis name.");
            }

            Diagnosis diagnosis = _mapper.Map<Diagnosis>(diagnosisDto);

            await _unitOfWork.Diagnostics.AddAsync(diagnosis);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Created(diagnosisDto);
        }
        public async Task<Response<DiagnosisDto>> UpdateDiagnosisByIdAsync(int id, DiagnosisDto diagnosisDto)
        {
            if (!IsValidDiagnosisName(diagnosisDto.Name))
            {
                return ResponseFactory.BadRequest<DiagnosisDto>("You inserted incorrect letter in diagnosis name.");
            }

            var diagnosis = await _unitOfWork.Diagnostics.GetByIdAsync(id);
            if (diagnosis is null)
            {
                return ResponseFactory.NotFound<DiagnosisDto>(id);
            }

            diagnosis.Name = diagnosisDto.Name;

            _unitOfWork.Diagnostics.Update(diagnosis);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Ok(diagnosisDto);
        }
        public async Task<Response<DiagnosisDto>> DeleteDiagnosisByIdAsync(int id)
        {
            var diagnosis = await _unitOfWork.Diagnostics.GetByIdAsync(id);
            if (diagnosis is null)
            {
                return ResponseFactory.NotFound<DiagnosisDto>(id);
            }

            _unitOfWork.Diagnostics.Delete(diagnosis);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.NoContent<DiagnosisDto>();
        }

        // ------------ Private ------------
        private bool IsValidDiagnosisName(string name)
        {
            return StringValidations.IsAllLetters(name);
        }
    }
}
