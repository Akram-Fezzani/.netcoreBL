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
using Article = BL.Domain.Models.Article;

namespace BL.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {



        public IGenericRepository<Article> Repository;
        CancellationToken cancellation;
        private readonly IMapper _mapper;



        public ArticleController(IGenericRepository<Article> _Repository, IMapper mapper)
        {
            Repository = _Repository;
            cancellation = new CancellationToken();
            _mapper = mapper;
        }

        [HttpGet("GetArticles")]
        public IEnumerable<Article> getAllArticles()
        {
            return (new GetListGenericHandler<Article>(Repository).Handle(new GetListGenericQuery<Article>(null, null), cancellation).Result);
        }




        [HttpGet("GetArticle")]
        public Article getArticleById(Guid Id)
        {
            return (new GetGenericHandler<Article>(Repository).Handle(new GetGenericQuery<Article>(condition: x => x.ArticleId == Id, null), cancellation).Result);
        }




        [HttpPost("AjoutArticle")]
        public async Task<Article> PostArticle([FromBody] Article Article)
        {
            var x = new AddGenericCommand<Article>(Article);
            var GenericHandler = new AddGenericHandler<Article>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpPut("UpdateArticle")]
        public async Task<Article> PutArticle([FromBody] Article Article)
        {
            var x = new PutGenericCommand<Article>(Article);
            var GenericHandler = new PutGenericHandler<Article>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }





        [HttpDelete("DeleteArticle")]
        public async Task<Article> DeleteArticle(Guid Id)
        {
            var x = new RemoveGenericCommand<Domain.Models.Article>(Id);
            var GenericHandler = new RemoveGenericHandler<Domain.Models.Article>(Repository);
            return await GenericHandler.Handle(x, cancellation);
        }
    }
}
