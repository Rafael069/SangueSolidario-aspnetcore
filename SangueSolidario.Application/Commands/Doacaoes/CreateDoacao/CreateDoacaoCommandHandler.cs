using MediatR;
using Microsoft.EntityFrameworkCore;
using SangueSolidario.Application.Services.Interfaces;
using SangueSolidario.Core.Entities;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Commands.Doacaoes.CreateDoacao
{
    public class CreateDoacaoCommandHandler : IRequestHandler<CreateDoacaoCommand, int>
    {
        private readonly SangueSolidarioDbContext _dbcontext;

        private readonly IEstoqueDeSangueService _estoqueService;

        public CreateDoacaoCommandHandler(SangueSolidarioDbContext dbcontext, IEstoqueDeSangueService estoqueService)
        {
            _dbcontext = dbcontext;
            _estoqueService = estoqueService;
        }

        public async Task<int> Handle(CreateDoacaoCommand request, CancellationToken cancellationToken)
        {
            // Buscar o doador
            var doador = await _dbcontext.Doadores.FirstOrDefaultAsync(d => d.Id == request.DoadorId);
            if (doador == null)
            {
                throw new InvalidOperationException("Doador não encontrado.");
            }


            // Criação da doação
           var doacao = new Doacao(request.DoadorId, request.DataDoacao, request.QuantidadeML);
           await _dbcontext.Doacoes.AddAsync(doacao);



            // Atualizar estoque via EstoqueService
             _estoqueService.UpdateEstoque(doador, request.QuantidadeML);

            // Salvar todas as mudanças de uma vez
            await _dbcontext.SaveChangesAsync();


            return doacao.Id;
        }
    }
}
