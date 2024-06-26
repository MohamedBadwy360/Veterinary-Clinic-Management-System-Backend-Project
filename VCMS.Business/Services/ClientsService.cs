﻿using System.Collections.Generic;

namespace VCMS.Business.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Response<ClientDto>> GetClientByIdAsync(int id)
        {
            var client = await _unitOfWork.Clients.GetByIdAsync(id);
            if (client is null)
            {
                return ResponseFactory.NotFound<ClientDto>(id);
            }

            var clientDto = _mapper.Map<ClientDto>(client);
            return ResponseFactory.Ok(clientDto);
        }
        public async Task<Response<IEnumerable<ClientDto>>> GetAllClientAsync()
        {
            var clients = await _unitOfWork.Clients.GetAllAsync();
            if (clients is null)
            {
                return ResponseFactory.NotFound<IEnumerable<ClientDto>>();
            }

            var clientDtos = _mapper.Map<IEnumerable<ClientDto>>(clients);
            return ResponseFactory.Ok(clientDtos);
        }
        public async Task<Response<ClientDto>> CreateClientAsync(ClientDto clientDto)
        {
            if (!IsValidClientDtoData(clientDto))
            {
                return ResponseFactory.BadRequest<ClientDto>("Incorrect FirstName or LastName or PhoneNumber");
            }

            var client = _mapper.Map<Client>(clientDto);

            await _unitOfWork.Clients.AddAsync(client);
            await _unitOfWork.CommitAsync();

            return ResponseFactory.Created(clientDto);
        }   
        public async Task<Response<ClientDto>> UpdateClientByIdAsync(int id, ClientDto clientDto)
        {
            if (!IsValidClientDtoData(clientDto))
            {
                return ResponseFactory.BadRequest<ClientDto>("Incorrect FirstName or LastName or PhoneNumber");
            }

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
        public async Task<Response<ClientDto>> DeleteClientByIdAsync(int id)
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
    }
}
