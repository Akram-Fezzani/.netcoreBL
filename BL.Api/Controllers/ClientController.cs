using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BL.Domain.Models;
using BL.Domain.Interfaces;
using AutoMapper;
using System.Threading;
using BL.Domain.Handlers;
using BL.Domain.Queries;
using BL.Domain.Commands;

namespace BL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        public IGenericRepository<Client> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public ClientController(IGenericRepository<Client> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetClients")]
        public IEnumerable<Client> getAllClients()
        {
            return (new GetListGenericHandler<Client>(Repository).Handle(new GetListGenericQuery<Client>(null, null), cancellation).Result);
        }




        [HttpGet("GetClient")]
        public Client getClientById(Guid Id)
        {
            return (new GetGenericHandler<Client>(Repository).Handle(new GetGenericQuery<Client>(condition: x => x.ClientId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutClient")]
        public async Task<Client> PostClient([FromBody] Client Client)
        {
            var x = new AddGenericCommand<Client>(Client);
            var GenericHandler = new AddGenericHandler<Client>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateClient")]
        public async Task<Client> PutClient([FromBody] Client Client)
        {
            var x = new PutGenericCommand<Client>(Client);
            var GenericHandler = new PutGenericHandler<Client>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteClient")]
        public async Task<Client> DeleteClient(Guid Id)
        {
            var x = new RemoveGenericCommand<Client>(Id);
            var GenericHandler = new RemoveGenericHandler<Client>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
