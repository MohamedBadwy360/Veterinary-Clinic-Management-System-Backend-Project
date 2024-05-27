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
            try
            {
                var diagnosis = await _unitOfWork.Diagnostics.GetByIdAsync(id);
                if (diagnosis is null)
                {
                    return ResponseFactory.NotFound<DiagnosisDto>(id);
                }

                var diagnosisDto = _mapper.Map<DiagnosisDto>(diagnosis);
                return ResponseFactory.Ok(diagnosisDto);
            }
            catch (Exception exception)
            {
                return ExceptionHandler.
                    HandleGenericException<DiagnosisDto>(exception, DbOperations.Retrieve);
            }
        }
        public async Task<Response<IEnumerable<DiagnosisDto>>> GetAllDiagnosisAsync()
        {
            try
            {
                var diagnostics = await _unitOfWork.Diagnostics.GetAllAsync();
                if (diagnostics is null)
                {
                    return ResponseFactory.NotFound<IEnumerable<DiagnosisDto>>();
                }

                var diagnosticsDtos = _mapper.Map<IEnumerable<DiagnosisDto>>(diagnostics);
                return ResponseFactory.Ok(diagnosticsDtos);
            }
            catch (Exception exception)
            {
                return ExceptionHandler.
                    HandleGenericException<IEnumerable<DiagnosisDto>>(exception, DbOperations.Retrieve);
            }
        }
        public async Task<Response<DiagnosisDto>> CreateDiagnosisAsync(DiagnosisDto diagnosisDto)
        {
            if (!!IsValidDiagnosisName(diagnosisDto.Name))
            {
                return ResponseFactory.BadRequest<DiagnosisDto>(inValidNameErrorMessage);
            }

            return await CreateAsync(diagnosisDto);
        }
        public async Task<Response<DiagnosisDto>> UpdateDiagnosisByIdAsync(int id, DiagnosisDto diagnosisDto)
        {
            if (!IsValidDiagnosisName(diagnosisDto.Name))
            {
                return ResponseFactory.BadRequest<DiagnosisDto>(inValidNameErrorMessage);
            }

            return await UpdateAsync(id, diagnosisDto);
        }
        public async Task<Response<DiagnosisDto>> DeleteDiagnosisByIdAsync(int id)
        {
            try
            {
                var diagnosis = await _unitOfWork.Diagnostics.GetByIdAsync(id);
                if(diagnosis is null)
                {
                    return ResponseFactory.NotFound<DiagnosisDto>(id);
                }

                _unitOfWork.Diagnostics.Delete(diagnosis);
                await _unitOfWork.CommitAsync();

                return ResponseFactory.NoContent<DiagnosisDto>();
            }
            catch (DbUpdateException exception)
            {
                return ExceptionHandler.
                    HandleDbUpdateException<DiagnosisDto>(exception, DbOperations.Delete);
            }
            catch (Exception exception)
            {
                return ExceptionHandler.
                    HandleGenericException<DiagnosisDto>(exception, DbOperations.Delete);
            }
        }

        // ------------ Private ------------

        private const string uniqueProperty = "name";
        private const string inValidNameErrorMessage = "You inserted incorrect letter in diagnosis name.";
        private bool IsValidDiagnosisName(string name)
        {
            return StringValidations.IsAllLetters(name);
        }
        private async Task<Response<DiagnosisDto>> CreateAsync(DiagnosisDto diagnosisDto)
        {
            Diagnosis diagnosis = _mapper.Map<Diagnosis>(diagnosisDto);
            await _unitOfWork.Diagnostics.AddAsync(diagnosis);

            try
            {
                await _unitOfWork.CommitAsync();
                return ResponseFactory.Created<DiagnosisDto>(diagnosisDto);
            }
            catch (DbUpdateException exception)
            {
                return ExceptionHandler.
                    HandleDbUpdateException<DiagnosisDto>(exception, DbOperations.Create, uniqueProperty);
            }
            catch (Exception exception)
            {
                return ExceptionHandler.
                    HandleGenericException<DiagnosisDto>(exception, DbOperations.Create);
            }
        }
        private async Task<Response<DiagnosisDto>> UpdateAsync(int id, DiagnosisDto diagnosisDto)
        {
            try
            {
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
            catch (DbUpdateException exception)
            {
                return ExceptionHandler.
                    HandleDbUpdateException<DiagnosisDto>(exception, DbOperations.Update, uniqueProperty);
            }
            catch (Exception exception)
            {
                return ExceptionHandler.
                    HandleGenericException<DiagnosisDto>(exception, DbOperations.Update);
            }
        }
    }
}
