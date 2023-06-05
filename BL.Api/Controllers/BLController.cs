using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BL.Data.Context;
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
    public class BLController : ControllerBase
    {
        public IGenericRepository<Domain.Models.BLs> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public BLController(IGenericRepository<Domain.Models.BLs> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetBLs")]
        public IEnumerable<Domain.Models.BLs> getAllBLs()
        {
            return (new GetListGenericHandler<Domain.Models.BLs>(Repository).Handle(new GetListGenericQuery<Domain.Models.BLs>(null, null), cancellation).Result);
        }




        [HttpGet("GetBL")]
        public Domain.Models.BLs getBLById(Guid Id)
        {
            return (new GetGenericHandler<Domain.Models.BLs>(Repository).Handle(new GetGenericQuery<Domain.Models.BLs>(condition: x => x.BLId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutBL")]
        public async Task<Domain.Models.BLs> PostBL([FromBody] Domain.Models.BLs BL)
        {
            var x = new AddGenericCommand<Domain.Models.BLs>(BL);
            var GenericHandler = new AddGenericHandler<Domain.Models.BLs>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateBL")]
        public async Task<Domain.Models.BLs> PutBL([FromBody] Domain.Models.BLs BL)
        {
            var x = new PutGenericCommand<Domain.Models.BLs>(BL);
            var GenericHandler = new PutGenericHandler<Domain.Models.BLs>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteBL")]
        public async Task<Domain.Models.BLs> DeleteBL(Guid Id)
        {
            var x = new RemoveGenericCommand<Domain.Models.BLs>(Id);
            var GenericHandler = new RemoveGenericHandler<Domain.Models.BLs>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
