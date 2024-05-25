﻿namespace VCMS.Business.Services
{
    public class SpeciesService : ISpeciesService
    {
        private const string uniqueProperty = "name";
        private const string invalidNameErrorMessage = "You inserted incorrect letter in species name.";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SpeciesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<SpeciesDto>> GetSpeciesByIdAsync(int id)
        {
            try
            {
                var species = await _unitOfWork.Species.GetByIdAsync(id);

                if (species is null)
                {
                    return Response<SpeciesDto>.NotFound(id);
                }
                else
                {
                    var speciesDto = _mapper.Map<SpeciesDto>(species);
                    return Response<SpeciesDto>.Ok(speciesDto);
                }
            }
            catch (Exception exception)
            {
                return ExceptionHandler.
                    HandleGenericException<SpeciesDto>(exception, DbOperations.Retrieve);
            }            
        }
        public async Task<Response<IEnumerable<SpeciesDto>>> GetAllSpeciesAsync()
        {
            try
            {
                var species = await _unitOfWork.Species.GetAllAsync();
                if (species is null)
                {
                    return Response<IEnumerable<SpeciesDto>>.NotFound();
                }
                else
                {
                    var speciesDtos = _mapper.Map<IEnumerable<SpeciesDto>>(species);
                    return Response<IEnumerable<SpeciesDto>>.Ok(speciesDtos);
                }
            }
            catch (Exception exception)
            {
                return ExceptionHandler.
                    HandleGenericException<IEnumerable<SpeciesDto>>(exception, DbOperations.Retrieve);
            }
        }
        public async Task<Response<SpeciesDto>> CreateSpeciesAsync(SpeciesDto speciesDto)
        {
            if (!IsValidSpeciesName(speciesDto.Name))
            {
                return Response<SpeciesDto>.BadRequest(invalidNameErrorMessage);
            }

            return await CreateAsync(speciesDto);
        }
        public async Task<Response<SpeciesDto>> UpdateSpeciesByIdAsync(int id, SpeciesDto speciesDto)
        {
            if (!IsValidSpeciesName(speciesDto.Name))
            {
                return Response<SpeciesDto>.BadRequest(invalidNameErrorMessage);
            }

            return await UpdateAsync(id, speciesDto);
        }
        public async Task<Response<SpeciesDto>> DeleteSpeciesByIdAsync(int id)
        {
            try
            {
                var species = await _unitOfWork.Species.GetByIdAsync(id);

                if (species is null)
                {
                    return Response<SpeciesDto>.NotFound(id);
                }

                _unitOfWork.Species.Delete(species);
                await _unitOfWork.CommitAsync();

                return Response<SpeciesDto>.NoContent();
            }
            catch (DbUpdateException exception)
            {
                return ExceptionHandler.
                    HandleDbUpdateException<SpeciesDto>(exception, DbOperations.Delete);
            }
            catch (Exception exception)
            {
                return ExceptionHandler.HandleGenericException<SpeciesDto>(exception,DbOperations.Delete);
            }
        }

        // ----------- Private -----------
        
        private bool IsValidSpeciesName(string name)
        {
            return StringValidations.IsAllLetters(name);
        }
        private async Task<Response<SpeciesDto>> CreateAsync(SpeciesDto speciesDto)
        {
            var species = _mapper.Map<Species>(speciesDto);
            await _unitOfWork.Species.AddAsync(species);

            try
            {
                await _unitOfWork.CommitAsync();
                return Response<SpeciesDto>.Created(speciesDto);
            }
            catch (DbUpdateException exception)
            {
                return ExceptionHandler.
                    HandleDbUpdateException<SpeciesDto>(exception, DbOperations.Create, uniqueProperty);
            }
            catch (Exception exception)
            {
                return ExceptionHandler.HandleGenericException<SpeciesDto>(exception, DbOperations.Create);
            }
        }
        private async Task<Response<SpeciesDto>> UpdateAsync(int id, SpeciesDto speciesDto)
        {
            try
            {
                var species = await _unitOfWork.Species.GetByIdAsync(id);
                if (species is null)
                {
                    return Response<SpeciesDto>.NotFound(id);
                }

                species.Name = speciesDto.Name;

                _unitOfWork.Species.Update(species);
                await _unitOfWork.CommitAsync();

                return Response<SpeciesDto>.Ok(speciesDto);
            }
            catch (DbUpdateException exception)
            {
                return ExceptionHandler.
                    HandleDbUpdateException<SpeciesDto>(exception, DbOperations.Update, uniqueProperty);
            }
            catch (Exception exception)
            {
                return ExceptionHandler.HandleGenericException<SpeciesDto>(exception, DbOperations.Update);
            }
        }
    }
}
