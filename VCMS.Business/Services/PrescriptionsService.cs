namespace VCMS.Business.Services
{
    public class PrescriptionsService(IUnitOfWork _unitOfWork, IMapper _mapper) : IPrescriptionsService
    {
        public async Task<Response<GetPrescriptionDto>> GetPrescriptionByIdAsync(int id)
        {
            var prescription = await _unitOfWork.Prescriptions.FindAsync(p => p.Id == id,
                ["PrescribedMeds", "PrescribedMeds.Medication"]);
            if (prescription is null)
            {
                return ResponseFactory.NotFound<GetPrescriptionDto>(id);
            }

            var getPrescriptionDto = _mapper.Map<GetPrescriptionDto>(prescription);
            return ResponseFactory.Ok(getPrescriptionDto);
        }

        public async Task<Response<IEnumerable<GetPrescriptionDto>>> GetAllPrescriptionsAsync()
        {
            //var prescriptions = await _unitOfWork.Prescriptions.GetAllAsync(["PrescribedMeds", "PrescribedMeds.Medication"]);
            var prescriptions = await _unitOfWork.Prescriptions.GetAllPrescriptionsAsync();
            if (prescriptions is null)
            {
                return ResponseFactory.NotFound<IEnumerable<GetPrescriptionDto>>();
            }

            var getPrescriptionDtos = _mapper.Map<IEnumerable<GetPrescriptionDto>>(prescriptions);
            return ResponseFactory.Ok(getPrescriptionDtos);
        }

        public  async Task<Response<CreatePrescriptionDto>> CreatePrescriptionAsync(CreatePrescriptionDto createPrescriptionDto)
        {
            var prescription = _mapper.Map<Prescription>(createPrescriptionDto);

            await _unitOfWork.Prescriptions.AddAsync(prescription);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Created(createPrescriptionDto);
        }

        public async Task<Response<UpdatePrescriptionDto>> UpdatePrescriptionAsync(int id, UpdatePrescriptionDto updatePrescriptionDto)
        {
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(id);
            if (prescription is null)
            {
                return ResponseFactory.NotFound<UpdatePrescriptionDto>(id);
            }

            _mapper.Map(updatePrescriptionDto, prescription);

            _unitOfWork.Prescriptions.Update(prescription);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Ok(updatePrescriptionDto);
        }

        public async Task<Response<DeletePrescriptionDto>> DeletePrescriptionAsync(int id)
        {
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(id);
            if (prescription is null)
            {
                return ResponseFactory.NotFound<DeletePrescriptionDto>(id);
            }

            _unitOfWork.Prescriptions.Delete(prescription);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.NoContent<DeletePrescriptionDto>();
        }

        public async Task<Response<PrescribedMedsDto>> AddMedicationToPrescription(int prescriptionId, 
            int medicationId, int quantity, string frequency)
        {
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(prescriptionId);
            if (prescription is null)
            {
                return ResponseFactory.NotFound<PrescribedMedsDto>($"No prescription with Id {prescriptionId} was found.");
            }

            var medication = await _unitOfWork.Medications.GetByIdAsync(medicationId);
            if (medication is null)
            {
                return ResponseFactory.NotFound<PrescribedMedsDto>($"No medication with Id {medicationId} was found.");
            }

            var prescribedMed = new PrescribedMeds
            {
                PrescriptionId = prescriptionId,
                MedicationId = medicationId,
                Quantity = quantity,
                Price = medication.SalePricePerItem,
                TotalPrice = quantity * medication.SalePricePerItem,
                Frequency = frequency
            };
     
            prescription.PrescribedMeds.Add(prescribedMed);
            await _unitOfWork.CommitAsync();

            var prescribedMedsDto = _mapper.Map<PrescribedMedsDto>(prescribedMed);
            return ResponseFactory.Ok(prescribedMedsDto);
        }

        public async Task<Response<PrescribedMedsDto>> DeleteMedicationFromPrescription(int prescriptionId, 
            int medicationId)
        {
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(prescriptionId);
            if (prescription is null)
            {
                return ResponseFactory.NotFound<PrescribedMedsDto>($"No prescription with Id {prescriptionId} was found.");
            }

            var medication = await _unitOfWork.Medications.GetByIdAsync(medicationId);
            if (medication is null)
            {
                return ResponseFactory.NotFound<PrescribedMedsDto>($"No medication with Id {medicationId} was found.");
            }

            var prescribedMeds = new PrescribedMeds
            {
                PrescriptionId = prescriptionId,
                MedicationId = medicationId
            };

            _unitOfWork.PrescribedMeds.Delete(prescribedMeds);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.NoContent<PrescribedMedsDto>();
        }
    }
}
