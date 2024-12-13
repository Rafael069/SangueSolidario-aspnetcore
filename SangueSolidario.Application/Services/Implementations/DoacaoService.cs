using SangueSolidario.Application.InputModels;
using SangueSolidario.Application.Services.Interfaces;
using SangueSolidario.Application.ViewModels;
using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Services.Implementations
{
    public class DoacaoService : IDoacaoService
    {
        // Utilizando _dbcontext (Banco Fake)
        private readonly SangueSolidarioDbContext _dbcontext;

        public DoacaoService(SangueSolidarioDbContext dbcontext)
        {
            // Injeção de Dependência
            _dbcontext = dbcontext;
        }

        public DoacaoDetailsViewModel GetById(int id)
        {
            var doacao = _dbcontext.Doacoes.SingleOrDefault(d => d.Id == id);

            if (doacao.Status == DoacaoStatusEnum.Removido)
                return null;

            var doacoesDetailsViewModel = new DoacaoDetailsViewModel(
                doacao.Id,
                doacao.DoadorId,
                doacao.DataDoacao,
                doacao.QuantidadeML,
                doacao.Doador
                );

            return doacoesDetailsViewModel;
        }

        List<DoacaoViewModel> IDoacaoService.GetAll()
        {
            var doacoes = _dbcontext.Doacoes;

            // Filtrando livros ativos
            var doacoesAtivas = _dbcontext.Doacoes
                .Where(d => d.Status == DoacaoStatusEnum.Ativo)
                .ToList();

            var doacoesViewModel = doacoesAtivas
            .Select(d => new DoacaoViewModel(d.Id, d.DoadorId, d.DataDoacao))
            .ToList();

            return doacoesViewModel;
        }


        public int Create(NewDoacaoInputModel inputModel)
        {

            var doacao = new Doacao(inputModel.Id, inputModel.DoadorId, inputModel.DataDoacao, inputModel.QuantidadeML/*, inputModel.Doador*/);

            _dbcontext.Doacoes.Add(doacao);

            return doacao.Id;
        }

        public void Delete(int id)
        {
            var doacoes = _dbcontext.Doacoes.SingleOrDefault(d => d.Id == id);

            doacoes.DeleteDoacao();

        }

        public void Update(UpdateDoacaoInputModel inputModel)
        {
            var doacao = _dbcontext.Doacoes.SingleOrDefault(d => d.Id == inputModel.Id);

            doacao.Update(inputModel.QuantidadeML);
        }



    }
}
