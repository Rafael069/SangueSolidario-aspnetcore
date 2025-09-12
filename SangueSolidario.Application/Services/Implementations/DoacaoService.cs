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

        private readonly SangueSolidarioDbContext _dbcontext;
        //private readonly EstoqueDeSangueService _estoqueService;
        private readonly IEstoqueDeSangueService _estoqueService;

        public DoacaoService(SangueSolidarioDbContext dbcontext, IEstoqueDeSangueService estoqueService)
        {
            // Injeção de Dependência
            _dbcontext = dbcontext;
            _estoqueService = estoqueService;
        }



        public DoacaoDetailsViewModel GetById(int id)
        {
            var doacao = _dbcontext.Doacoes.SingleOrDefault(dc => dc.Id == id);

            if (doacao.Status == DoacaoStatusEnum.Removido)
                return null;

            var doacoesDetailsViewModel = new DoacaoDetailsViewModel(
                doacao.Id,
                doacao.IdDoador,
                doacao.DataDoacao,
                doacao.QuantidadeML,
                doacao.Doador
                );

            return doacoesDetailsViewModel;
        }

        public List<DoacaoViewModel> GetAll()
        {
            var doacoes = _dbcontext.Doacoes;

            // Filtrando  ativos
            var doacoesAtivas = _dbcontext.Doacoes
                .Where(dc => dc.Status == DoacaoStatusEnum.Ativo)
                .ToList();

            var doacoesViewModel = doacoesAtivas
            .Select(dc => new DoacaoViewModel(dc.Id, dc.IdDoador, dc.DataDoacao,dc.QuantidadeML))
            .ToList();

            return doacoesViewModel;
        }


        public int Create(NewDoacaoInputModel inputModel)
        {
            // Validação da quantidade de sangue doada
            //if (inputModel.QuantidadeML < 420 || inputModel.QuantidadeML > 470)
            //{
            //    throw new ArgumentException("A quantidade de sangue doada deve estar entre 420ml e 470ml.");
            //}

            // Buscar o doador
            var doador = _dbcontext.Doadores.FirstOrDefault(d => d.Id == inputModel.DoadorId);
            if (doador == null)
            {
                throw new InvalidOperationException("Doador não encontrado.");
            }


            // Criação da doação
            var doacao = new Doacao(inputModel.DoadorId, inputModel.DataDoacao, inputModel.QuantidadeML);
            _dbcontext.Doacoes.Add(doacao);

          

            // Atualizar estoque via EstoqueService
            _estoqueService.UpdateEstoque(doador, inputModel.QuantidadeML);

            // Salvar todas as mudanças de uma vez
            _dbcontext.SaveChanges();


            return doacao.Id;
        }

        




        #region Lógica de Doações nos Últimos 30 Dias com Informações dos Doadores
        public List<RelatorioDoacaoViewModel> GerarRelatorioDoacoesUltimos30Dias()
        {
            //var dataLimite = DateTime.Now.AddDays(-30);
            var dataLimite = DateTime.UtcNow.AddDays(-30);


            var doacoesRecentes = _dbcontext.Doacoes
                .Where(d => d.DataDoacao >= dataLimite && d.Status == DoacaoStatusEnum.Ativo)
                .Select(d => new RelatorioDoacaoViewModel
                {
                    IdDoador = d.IdDoador,
                    NomeDoador = d.Doador.NomeCompleto,  
                    TipoSanguineo = d.Doador.TipoSanguineo,
                    FatorRh = d.Doador.FatorRh,
                    DataDoacao = d.DataDoacao,
                    QuantidadeML = d.QuantidadeML
                })
                .ToList();

            return doacoesRecentes;
        }

        #endregion

        public void Delete(int id)
        {
            var doacoes = _dbcontext.Doacoes.SingleOrDefault(dc => dc.Id == id);

            doacoes.DeleteDoacao();
            _dbcontext.SaveChanges();

        }

        public void Update(UpdateDoacaoInputModel inputModel)
        {
            var doacao = _dbcontext.Doacoes.SingleOrDefault(dc => dc.Id == inputModel.Id);

            doacao.Update(inputModel.QuantidadeML);
            _dbcontext.SaveChanges();
        }



    }
}
