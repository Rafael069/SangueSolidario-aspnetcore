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

        public EstoqueDeSangueDetailsViewModel GetById(int id)
        {
            var estoqueDeSangue = _dbcontext.EstoquesSangue.SingleOrDefault(d => d.Id == id);

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
                .Where(e => e.Status == EstoquesSangueEnum.Ativo)
                .ToList();


            var estoquesDeSangueViewModel = estoquesDeSangueAtivas
            .Select(e => new EstoqueDeSangueViewModel(e.Id, e.TipoSanguineo))
            .ToList();

            return estoquesDeSangueViewModel;
        }



        public int Create(NewEstoqueDeSangueInputModel inputModel)
        {
            var estoqueDeSangue = new EstoqueSangue(inputModel.Id, inputModel.TipoSanguineo, inputModel.FatorRh, inputModel.QuantidadeML/*,inputModel.Status*/);

            _dbcontext.EstoquesSangue.Add(estoqueDeSangue);


            return estoqueDeSangue.Id;
        }

        public void Delete(int id)
        {
            var estoqueDeSangue = _dbcontext.EstoquesSangue.SingleOrDefault(e => e.Id == id);

            estoqueDeSangue.DeleteEstoque();
        }
     

        public void Update(UpdateEstoqueDeSangueInputModel inputModel)
        {
            var estoqueDeSangue = _dbcontext.EstoquesSangue.SingleOrDefault(e => e.Id == inputModel.Id);

            estoqueDeSangue.Update(inputModel.TipoSanguineo, inputModel.QuantidadeML);
        }
    }
}
