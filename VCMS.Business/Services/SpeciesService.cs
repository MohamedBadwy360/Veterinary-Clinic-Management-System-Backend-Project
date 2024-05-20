namespace VCMS.Business.Services
{
    public class SpeciesService : ISpeciesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public SpeciesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<SpeciesDto>> GetByIdAsync(int id)
        {
            try
            {
                var species = await _unitOfWork.Species.GetByIdAsync(id);
                var speciesDto = _mapper.Map<SpeciesDto>(species);

                if (species is null)
                {
                    return Response<SpeciesDto>.Failure(EResponseStatusCode.NotFound,
                        $"No species was found with Id {id}");
                }
                else
                {
                    return Response<SpeciesDto>.Success(EResponseStatusCode.OK, speciesDto);
                }
            }
            catch (Exception exception)
            {
                // logging exception

                return Response<SpeciesDto>.Failure(EResponseStatusCode.InternalServerError,
                    $"An unexpected error occurred while retrieving the species.");
            }            
        }

        public async Task<Response<IEnumerable<SpeciesDto>>> GetAllAsync()
        {
            try
            {
                var species = await _unitOfWork.Species.GetAllAsync();
                var speciesDtos = _mapper.Map<IEnumerable<SpeciesDto>>(species);
                if (species is null)
                {
                    return Response<IEnumerable<SpeciesDto>>.Failure(EResponseStatusCode.NotFound,
                        "No species were found in database yet.");
                }
                else
                {
                    return Response<IEnumerable<SpeciesDto>>.Success(EResponseStatusCode.OK, speciesDtos);
                }
            }
            catch (Exception exception)
            {
                // logging exception

                return Response<IEnumerable<SpeciesDto>>.Failure(EResponseStatusCode.InternalServerError,
                    $"An unexpected error occurred while retrieving the species.");
            }
        }

        public async Task<Response<SpeciesDto>> CreateAsync(SpeciesDto speciesDto)
        {
            var species = _mapper.Map<Species>(speciesDto);
            await _unitOfWork.Species.AddAsync(species);

            try
            {
                await _unitOfWork.CommitAsync();
                return Response<SpeciesDto>.Success(EResponseStatusCode.Created, speciesDto);
            }
            catch (DbUpdateException exception)
            {
                if (exception.InnerException is SqlException sqlException && 
                    sqlException.Number == SqlServerErrorNumbers.ViolateUniqueConstaint)
                {
                    return Response<SpeciesDto>.Failure(EResponseStatusCode.Conflict,
                        "A species with the same name already exists.");
                }
                else
                {
                    // logging exception

                    return Response<SpeciesDto>.Failure(EResponseStatusCode.InternalServerError,
                        $"A database error occurred while adding the species.");
                }
            }
            catch (Exception exception)
            {
                // logging exception

                return Response<SpeciesDto>.Failure(EResponseStatusCode.InternalServerError,
                    "An unexpected error occurred while adding the species.");
            }
        }

        public async Task<Response<SpeciesDto>> UpdateAsync(int id, SpeciesDto speciesDto)
        {
            try
            {
                var species = await _unitOfWork.Species.GetByIdAsync(id);

                if (species is null)
                {
                    return Response<SpeciesDto>.Failure(EResponseStatusCode.NotFound,
                        $"No species was found with Id {id}");
                }

                species = _mapper.Map<Species>(speciesDto);

                _unitOfWork.Species.Update(species);
                await _unitOfWork.CommitAsync();

                return Response<SpeciesDto>.Success(EResponseStatusCode.OK, speciesDto);
            }
            catch (DbUpdateException exception)
            {
                return CheckingDbConstraints<SpeciesDto>.CheckViolateUniqueConstraint(exception);
            }
            catch (Exception exception)
            {
                // logging

                return Response<SpeciesDto>.Failure(EResponseStatusCode.InternalServerError,
                    "An unexpected error occurred while updating the species.");
            }
        }
    }
}
