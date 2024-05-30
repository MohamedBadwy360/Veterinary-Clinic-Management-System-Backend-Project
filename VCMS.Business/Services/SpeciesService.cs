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

        public async Task<Response<SpeciesDto>> GetSpeciesByIdAsync(int id)
        {
            var species = await _unitOfWork.Species.GetByIdAsync(id);
            if (species is null)
            {
                return ResponseFactory.NotFound<SpeciesDto>(id);
            }

            var speciesDto = _mapper.Map<SpeciesDto>(species);
            return ResponseFactory.Ok(speciesDto);
        }
        public async Task<Response<IEnumerable<SpeciesDto>>> GetAllSpeciesAsync()
        {
            var species = await _unitOfWork.Species.GetAllAsync();
            if (species is null)
            {
                return ResponseFactory.NotFound<IEnumerable<SpeciesDto>>();
            }
            
            var speciesDtos = _mapper.Map<IEnumerable<SpeciesDto>>(species);
            return ResponseFactory.Ok(speciesDtos);
        }
        public async Task<Response<SpeciesDto>> CreateSpeciesAsync(SpeciesDto speciesDto)
        {
            if (!IsValidSpeciesName(speciesDto.Name))
            {
                return ResponseFactory.BadRequest<SpeciesDto>("You inserted incorrect letter in species name.");
            }

            var species = _mapper.Map<Species>(speciesDto);

            await _unitOfWork.Species.AddAsync(species);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Created(speciesDto);
        }
        public async Task<Response<SpeciesDto>> UpdateSpeciesByIdAsync(int id, SpeciesDto speciesDto)
        {
            if (!IsValidSpeciesName(speciesDto.Name))
            {
                return ResponseFactory.BadRequest<SpeciesDto>("You inserted incorrect letter in species name.");
            }

            var species = await _unitOfWork.Species.GetByIdAsync(id);
            if (species is null)
            {
                return ResponseFactory.NotFound<SpeciesDto>(id);
            }

            species.Name = speciesDto.Name;

            _unitOfWork.Species.Update(species);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Ok(speciesDto);
        }
        public async Task<Response<SpeciesDto>> DeleteSpeciesByIdAsync(int id)
        {
            var species = await _unitOfWork.Species.GetByIdAsync(id);

            if (species is null)
            {
                return ResponseFactory.NotFound<SpeciesDto>(id);
            }

            _unitOfWork.Species.Delete(species);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.NoContent<SpeciesDto>();
        }

        // ----------- Private -----------
        
        private bool IsValidSpeciesName(string name)
        {
            return StringValidations.IsAllLetters(name);
        }
    }
}
