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
    public class EstoqueDeSangueService : IEstoqueDeSangueService
    {

        // Utilizando _dbcontext (Banco Fake)
        private readonly SangueSolidarioDbContext _dbcontext;

        public EstoqueDeSangueService(SangueSolidarioDbContext dbcontext)
        {
            // Injeção de Dependência
            _dbcontext = dbcontext;
        }


        #region Relatório sobre a quantidade total de sangue por tipo disponível.
        public List<RelatorioEstoqueSangueViewModel> GerarRelatorioQuantidadePorTipo()
        {
            var relatorio = _dbcontext.EstoquesSangue
                .Where(es => es.Status == EstoquesSangueEnum.Ativo)
                .GroupBy(es => new { es.TipoSanguineo, es.FatorRh })
                .Select(group => new RelatorioEstoqueSangueViewModel
                {
                    TipoSanguineo = group.Key.TipoSanguineo,
                    FatorRh = group.Key.FatorRh,
                    QuantidadeTotalML = group.Sum(es => es.QuantidadeML)
                })
                .ToList();

            return relatorio;
        }
         #endregion



        public EstoqueDeSangueDetailsViewModel GetById(int id)
        {
            var estoqueDeSangue = _dbcontext.EstoquesSangue.SingleOrDefault(es => es.Id == id);

            if (estoqueDeSangue.Status == EstoquesSangueEnum.Removido)
                return null;

            var estoqueDetailsViewModel = new EstoqueDeSangueDetailsViewModel(
                estoqueDeSangue.Id,
                estoqueDeSangue.TipoSanguineo,
                estoqueDeSangue.FatorRh,
                estoqueDeSangue.QuantidadeML
                );

            return estoqueDetailsViewModel;
        }


        public List<EstoqueDeSangueViewModel> GetAll()
        {
            var estoquesDeSangue = _dbcontext.EstoquesSangue;

            // Filtrando estoques ativos
            var estoquesDeSangueAtivas = _dbcontext.EstoquesSangue
                .Where(es => es.Status == EstoquesSangueEnum.Ativo)
                .ToList();


            var estoquesDeSangueViewModel = estoquesDeSangueAtivas
            .Select(es => new EstoqueDeSangueViewModel(es.Id, es.TipoSanguineo))
            .ToList();

            return estoquesDeSangueViewModel;
        }



        public int Create(NewEstoqueDeSangueInputModel inputModel)
        {
            var estoqueDeSangue = new EstoqueSangue(inputModel.TipoSanguineo, inputModel.FatorRh, inputModel.QuantidadeML/*,inputModel.Status*/);

            _dbcontext.EstoquesSangue.Add(estoqueDeSangue);
            _dbcontext.SaveChanges();


            return estoqueDeSangue.Id;
        }

        public void Delete(int id)
        {
            var estoqueDeSangue = _dbcontext.EstoquesSangue.SingleOrDefault(es => es.Id == id);

            estoqueDeSangue.DeleteEstoque();
            _dbcontext.SaveChanges();
        }


        public void UpdateEstoque(Doador doador, int quantidadeML)
        {
            var estoque = _dbcontext.EstoquesSangue
                .FirstOrDefault(e => e.TipoSanguineo == doador.TipoSanguineo && e.FatorRh == doador.FatorRh);

            if (estoque == null)
            {
                // Se não existir, cria um novo registro no estoque
                estoque = new EstoqueSangue(doador.TipoSanguineo, doador.FatorRh, quantidadeML);
                _dbcontext.EstoquesSangue.Add(estoque);
            }
            else
            {
                // Se já existir, soma a quantidade doada
                estoque.QuantidadeML += quantidadeML;
                _dbcontext.EstoquesSangue.Update(estoque);
            }

            _dbcontext.SaveChanges();
        }

    }
}
