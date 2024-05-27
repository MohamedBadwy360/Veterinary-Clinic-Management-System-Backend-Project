using System.Collections.Generic;

namespace VCMS.Business.Services
{
    public class ClientService : IClientService
    {
        private const string invalidNameOrPhoneNumberErrorMessage = "Incorrect FirstName or LastName or PhoneNumber";

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Response<ClientDto>> GetClientByIdAsync(int id)
        {
            try
            {
                var client = await _unitOfWork.Clients.GetByIdAsync(id);
                if (client is null)
                {
                    return ResponseFactory.NotFound<ClientDto>(id);
                }

                var clientDto = _mapper.Map<ClientDto>(client);
                return ResponseFactory.Ok(clientDto);
            }
            catch (Exception exception)
            {
                return ExceptionHandler.HandleGenericException<ClientDto>(exception, DbOperations.Retrieve);
            }
        }
        public async Task<Response<IEnumerable<ClientDto>>> GetAllClientAsync()
        {
            try
            {
                var clients = await _unitOfWork.Clients.GetAllAsync();
                if (clients is null)
                {
                    return ResponseFactory.NotFound<IEnumerable<ClientDto>>();
                }

                var clientDtos = _mapper.Map<IEnumerable<ClientDto>>(clients);
                return ResponseFactory.Ok(clientDtos);
            }
            catch (Exception exception)
            {
                return ExceptionHandler
                    .HandleGenericException<IEnumerable<ClientDto>>(exception, DbOperations.Retrieve);
            }
        }
        public async Task<Response<ClientDto>> CreateClientAsync(ClientDto clientDto)
        {
            if (!IsValidClientDtoData(clientDto))
            {
                return ResponseFactory.BadRequest<ClientDto>(invalidNameOrPhoneNumberErrorMessage);
            }

            return await CreateAsync(clientDto);
        }   
        public async Task<Response<ClientDto>> UpdateClientByIdAsync(int id, ClientDto clientDto)
        {
            if (!IsValidClientDtoData(clientDto))
            {
                return ResponseFactory.BadRequest<ClientDto>(invalidNameOrPhoneNumberErrorMessage);
            }

            return await UpdateAsync(id, clientDto);
        }
        public async Task<Response<ClientDto>> DeleteClientByIdAsync(int id)
        {
            try
            {
                var client = await _unitOfWork.Clients.GetByIdAsync(id);
                if (client is null)
                {
                    return ResponseFactory.NotFound<ClientDto>(id);
                }

                _unitOfWork.Clients.Delete(client);
                await _unitOfWork.CommitAsync();

                return ResponseFactory.NoContent<ClientDto>();
            }
            catch (DbUpdateException exception)
            {
                return ExceptionHandler.
                    HandleDbUpdateException<ClientDto>(exception, DbOperations.Delete);
            }
            catch (Exception exception)
            {
                return ExceptionHandler.HandleGenericException<ClientDto>(exception, DbOperations.Delete);
            }
        }

        
        // ------------ Private -------------

        private bool IsValidName(string firstName, string lastName)
        {
            return StringValidations.IsAllLetters(firstName) && StringValidations.IsAllLetters(lastName);
        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            return StringValidations.IsPhoneNumber(phoneNumber);
        }
        private bool IsValidClientDtoData(ClientDto clientDto)
        {
            return (IsValidName(clientDto.FirstName, clientDto.LastName) &&
                IsValidPhoneNumber(clientDto.PhoneNumber));
        }
        private async Task<Response<ClientDto>> CreateAsync(ClientDto clientDto)
        {
            var client = _mapper.Map<Client>(clientDto);
            await _unitOfWork.Clients.AddAsync(client);

            try
            {
                await _unitOfWork.CommitAsync();
                return ResponseFactory.Created(clientDto);
            }
            catch (DbUpdateException exception)
            {
                return ExceptionHandler
                    .HandleDbUpdateException<ClientDto>(exception, DbOperations.Create);
            }
            catch (Exception exception)
            {
                return ExceptionHandler
                    .HandleGenericException<ClientDto>(exception, DbOperations.Create);
            }
        }
        private async Task<Response<ClientDto>> UpdateAsync(int id, ClientDto clientDto)
        {
            try
            {
                var client = await _unitOfWork.Clients.GetByIdAsync(id);
                if (client is null)
                {
                    return ResponseFactory.NotFound<ClientDto>(id);
                }

                _mapper.Map(clientDto, client);

                _unitOfWork.Clients.Update(client);
                await _unitOfWork.CommitAsync();

                return ResponseFactory.Ok(clientDto);
            }
            catch (DbUpdateException exception)
            {
                return ExceptionHandler
                    .HandleDbUpdateException<ClientDto>(exception, DbOperations.Update);
            }
            catch (Exception exception)
            {
                return ExceptionHandler
                    .HandleGenericException<ClientDto>(exception, DbOperations.Update);
            }
        }
    }
}
