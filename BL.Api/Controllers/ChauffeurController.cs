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
    public class ChauffeurController : ControllerBase
    {



        public IGenericRepository<Chauffeur> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public ChauffeurController(IGenericRepository<Chauffeur> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetChauffeurs")]
        public IEnumerable<Chauffeur> getAllChauffeurs()
        {
            return (new GetListGenericHandler<Chauffeur>(Repository).Handle(new GetListGenericQuery<Chauffeur>(null, null), cancellation).Result);
        }




        [HttpGet("GetChauffeur")]
        public Chauffeur getChauffeurById(Guid Id)
        {
            return (new GetGenericHandler<Chauffeur>(Repository).Handle(new GetGenericQuery<Chauffeur>(condition: x => x.ChauffeurId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutChauffeur")]
        public async Task<Chauffeur> PostChauffeur([FromBody] Chauffeur Chauffeur)
        {
            var x = new AddGenericCommand<Chauffeur>(Chauffeur);
            var GenericHandler = new AddGenericHandler<Chauffeur>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateChauffeur")]
        public async Task<Chauffeur> PutChauffeur([FromBody] Chauffeur Chauffeur)
        {
            var x = new PutGenericCommand<Chauffeur>(Chauffeur);
            var GenericHandler = new PutGenericHandler<Chauffeur>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteChauffeur")]
        public async Task<Chauffeur> DeleteChauffeur(Guid Id)
        {
            var x = new RemoveGenericCommand<Chauffeur>(Id);
            var GenericHandler = new RemoveGenericHandler<Chauffeur>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
