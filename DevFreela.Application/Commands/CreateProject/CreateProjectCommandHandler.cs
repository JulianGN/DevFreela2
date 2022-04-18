using DevFreela.Core.Entities;
using DevFreela.Infraestructure.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Commands.CreateProject
{
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, int> // precisa da ação que será chamada e o tipo de retorno definido nela
    {
        private readonly DevFreelaDbContext _dbContext;
        public CreateProjectCommandHandler(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = new Project(request.Title, request.Description, request.IdClient, request.IdFreelancer, request.TotalCost);

            await _dbContext.Projects.AddAsync(project);
            // sempre que os dados forem alterados, adicione o SaveChanges para persistir:
            await _dbContext.SaveChangesAsync();

            // o handle retorna uma task. Podemos então retornar:
            // return Task.Fromresult(project.Id);
            // ou usar o async/await com AddAsync
            return project.Id;
        }
    }
}
