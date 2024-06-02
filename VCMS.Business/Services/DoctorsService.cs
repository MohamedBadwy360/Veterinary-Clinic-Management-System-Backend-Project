namespace VCMS.Business.Services
{
    public class DoctorsService : IDoctorsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DoctorsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<DoctorDto>> GetDoctorByIdAsync(int id)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
            if (doctor is null)
            {
                return ResponseFactory.NotFound<DoctorDto>(id);
            }

            var doctorDto = _mapper.Map<DoctorDto>(doctor);
            return ResponseFactory.Ok(doctorDto);
        }

        public async Task<Response<IEnumerable<DoctorDto>>> GetAllDoctorsAsync()
        {
            var doctors = await _unitOfWork.Doctors.GetAllAsync();
            if (doctors is null)
            {
                return ResponseFactory.NotFound<IEnumerable<DoctorDto>>();
            }

            var doctorDtos = _mapper.Map<IEnumerable<DoctorDto>>(doctors);
            return ResponseFactory.Ok(doctorDtos);
        }

        public async Task<Response<DoctorDto>> CreateDoctorAsync(DoctorDto doctorDto)
        {
            if (!IsValidName(doctorDto))
            {
                return ResponseFactory.BadRequest<DoctorDto>("Invalid first name or last name.");
            }

            var doctor = _mapper.Map<Doctor>(doctorDto);

            await _unitOfWork.Doctors.AddAsync(doctor);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Created(doctorDto);
        }

        public async Task<Response<DoctorDto>> UpdateDoctorAsync(int id, DoctorDto doctorDto)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
            if (doctor is null)
            {
                return ResponseFactory.NotFound<DoctorDto>(id);
            }

            _mapper.Map(doctorDto, doctor);

            _unitOfWork.Doctors.Update(doctor);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Ok(doctorDto);
        }

        public async Task<Response<DoctorDto>> DeleteDoctorByIdAsync(int id)
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);
            if (doctor is null)
            {
                return ResponseFactory.NotFound<DoctorDto>(id);
            }

            _unitOfWork.Doctors.Delete(doctor);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.NoContent<DoctorDto>();
        }

        // ------- Private -------

        /// <summary>
        /// Check if doctor's first name and last name is valid.
        /// </summary>
        /// <param name="doctorDto">Doctor data transfer object object to check</param>
        /// <returns>true if valid name</returns>
        private bool IsValidName(DoctorDto doctorDto)
        {
            return StringValidations.IsAllLetters(doctorDto.FirstName) &&
               StringValidations.IsAllLetters(doctorDto.LastName);
        }
    }
}
