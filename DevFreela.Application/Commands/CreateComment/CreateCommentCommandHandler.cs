﻿using DevFreela.Core.Entities;
using DevFreela.Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateComment
{
    class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Unit>
    {
        private readonly DevFreelaDbContext _dbContext;
        public CreateCommentCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var comment = new ProjectComment(request.Content, request.IdProject, request.IdUser);

            await _dbContext.ProjectComments.AddAsync(comment);

            await _dbContext.SaveChangesAsync();

            return Unit.Value; // mesmo sendo void, precisa retornar algo com o mediator (Unit.Value é uma estrutura vazia)
        }
    }
}