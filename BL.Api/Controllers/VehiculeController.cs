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
    public class VehiculeController : ControllerBase
    {



        public IGenericRepository<Vehicule> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public VehiculeController(IGenericRepository<Vehicule> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetVehicules")]
        public IEnumerable<Vehicule> getAllVehicules()
        {
            return (new GetListGenericHandler<Vehicule>(Repository).Handle(new GetListGenericQuery<Vehicule>(null, null), cancellation).Result);
        }




        [HttpGet("GetVehicule")]
        public Vehicule getVehiculeById(Guid Id)
        {
            return (new GetGenericHandler<Vehicule>(Repository).Handle(new GetGenericQuery<Vehicule>(condition: x => x.VehiculeId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutVehicule")]
        public async Task<Vehicule> PostVehicule([FromBody] Vehicule Vehicule)
        {
            var x = new AddGenericCommand<Vehicule>(Vehicule);
            var GenericHandler = new AddGenericHandler<Vehicule>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateVehicule")]
        public async Task<Vehicule> PutVehicule([FromBody] Vehicule Vehicule)
        {
            var x = new PutGenericCommand<Vehicule>(Vehicule);
            var GenericHandler = new PutGenericHandler<Vehicule>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }




        [HttpDelete("DeleteVehicule")]
        public async Task<Vehicule> DeleteVehicule(Guid Id)
        {
            var x = new RemoveGenericCommand<Vehicule>(Id);
            var GenericHandler = new RemoveGenericHandler<Vehicule>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
