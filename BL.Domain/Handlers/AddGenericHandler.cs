﻿using BL.Domain.Commands;
using BL.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL.Domain.Handlers
{
    public class AddGenericHandler<TEntity> : IRequestHandler<AddGenericCommand<TEntity>, TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> Repository;

        public AddGenericHandler(IGenericRepository<TEntity> Repository)
        {
            this.Repository = Repository;
        }

        public Task<TEntity> Handle(AddGenericCommand<TEntity> request, CancellationToken cancellationToken)
        {
            var result = Repository.Add(request.Entity);
            return Task.FromResult(result);
        }
    }
}
