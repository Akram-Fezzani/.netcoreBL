using System;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using BL.Domain.Interfaces;
using System.Text;
using BL.Domain.Models;
using BL.Domain.Queries;
using BL.Domain.Commands;
using BL.Domain.Handlers;
using BL.Data.Repositories;

namespace BL.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterService(IServiceCollection services)
        {
            //Repository
            services.AddTransient<IGenericRepository<BE>, GenericRepository<BE>>();
            services.AddTransient<IGenericRepository<BLs>, GenericRepository<BLs>>();
            services.AddTransient<IGenericRepository<Client>, GenericRepository<Client>>();
            services.AddTransient<IGenericRepository<Chauffeur>, GenericRepository<Chauffeur>>();
            services.AddTransient<IGenericRepository<Vehicule>, GenericRepository<Vehicule>>();

            services.AddTransient<IGenericRepository<Client>, GenericRepository<Client>>();

            services.AddTransient<IGenericRepository<Domain.Models.Article>, GenericRepository<Domain.Models.Article>>();





            services.AddTransient<IRequestHandler<GetListGenericQuery<BE>, IEnumerable<BE>>, GetListGenericHandler<BE>>();
            services.AddTransient<IRequestHandler<GetGenericQuery<BE>, BE>, GetGenericHandler<BE>>();
            services.AddTransient<IRequestHandler<PutGenericCommand<BE>, BE>, PutGenericHandler<BE>>();
            services.AddTransient<IRequestHandler<RemoveGenericCommand<BE>, BE>, RemoveGenericHandler<BE>>();
            services.AddTransient<IRequestHandler<AddGenericCommand<BE>, BE>, AddGenericHandler<BE>>();

        }
    }
}
