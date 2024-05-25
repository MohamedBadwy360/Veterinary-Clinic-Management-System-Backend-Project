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
                    return Response<DiagnosisDto>.NotFound(id);
                }

                var diagnosisDto = _mapper.Map<DiagnosisDto>(diagnosis);
                return Response<DiagnosisDto>.Ok(diagnosisDto);
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
                    return Response<IEnumerable<DiagnosisDto>>.NotFound();
                }

                var diagnosticsDtos = _mapper.Map<IEnumerable<DiagnosisDto>>(diagnostics);
                return Response<IEnumerable<DiagnosisDto>>.Ok(diagnosticsDtos);
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
                return Response<DiagnosisDto>.BadRequest(inValidNameErrorMessage);
            }

            return await CreateAsync(diagnosisDto);
        }
        public async Task<Response<DiagnosisDto>> UpdateDiagnosisByIdAsync(int id, DiagnosisDto diagnosisDto)
        {
            if (!IsValidDiagnosisName(diagnosisDto.Name))
            {
                return Response<DiagnosisDto>.BadRequest(inValidNameErrorMessage);
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
                    return Response<DiagnosisDto>.NotFound(id);
                }

                _unitOfWork.Diagnostics.Delete(diagnosis);
                await _unitOfWork.CommitAsync();

                return Response<DiagnosisDto>.NoContent();
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
                return Response<DiagnosisDto>.Created(diagnosisDto);
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
                    return Response<DiagnosisDto>.NotFound(id);
                }

                diagnosis.Name = diagnosisDto.Name;

                _unitOfWork.Diagnostics.Update(diagnosis);
                await _unitOfWork.CommitAsync();

                return Response<DiagnosisDto>.Ok(diagnosisDto);
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
