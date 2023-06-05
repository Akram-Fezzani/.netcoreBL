using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Domain.Commands
{
    public class AddGenericCommand<TEntity> : IRequest<TEntity> where TEntity : class
    {
        public TEntity Entity { get; }
        public AddGenericCommand(TEntity entity)
        {
            Entity = entity;
        }
    }
}
