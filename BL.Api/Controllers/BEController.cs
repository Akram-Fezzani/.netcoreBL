using AutoMapper;
using BL.Domain.Models;
using BL.Domain.Commands;
using BL.Domain.Handlers;
using BL.Domain.Interfaces;
using BL.Domain.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BEController : ControllerBase
    {
        public IGenericRepository<Domain.Models.BE> Repository;
       


        CancellationToken cancellation;
        private readonly IMapper _mapper;


        public BEController(IGenericRepository<Domain.Models.BE> _Repository, IGenericRepository<Domain.Models.Article> _insrepository,   IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

      



        [HttpGet("GetBEs")]
        public IEnumerable<Domain.Models.BE> getAllBEs()
        {
            return (new GetListGenericHandler<Domain.Models.BE>(Repository).Handle(new GetListGenericQuery<Domain.Models.BE>(null, null), cancellation).Result);
        }

        [HttpGet("GetBE")]
        public Domain.Models.BE getBEById(Guid Id)
        {
            return (new GetGenericHandler<Domain.Models.BE>(Repository).Handle(new GetGenericQuery<Domain.Models.BE>(condition: x => x.BEId == Id, null), cancellation).Result);
        }

      

        [HttpPost("AjoutBE")]
        public async Task<Domain.Models.BE> PostBE([FromBody] Domain.Models.BE BE)
        {
            var x = new AddGenericCommand<Domain.Models.BE>(BE);
            var GenericHandler = new AddGenericHandler<Domain.Models.BE>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
        [HttpPut("UpdateBE")]
        public async Task<Domain.Models.BE> PutBE( [FromBody] Domain.Models.BE BE)
        {
            var x = new PutGenericCommand<Domain.Models.BE>(BE);
            var GenericHandler = new PutGenericHandler<Domain.Models.BE>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }

        [HttpDelete("DeleteBE")]
        public async Task<Domain.Models.BE> DeleteBE(Guid Id)
        {
            var x = new RemoveGenericCommand<Domain.Models.BE>(Id);
            var GenericHandler = new RemoveGenericHandler<Domain.Models.BE>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }



        
    }
}
