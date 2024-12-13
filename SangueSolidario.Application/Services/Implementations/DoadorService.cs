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
    public class DoadorService : IDoadorService
    {
        // Utilizando _dbcontext (Banco Fake)
        private readonly SangueSolidarioDbContext _dbcontext;

        public DoadorService(SangueSolidarioDbContext dbcontext)
        {
            // Injeção de Dependência
            _dbcontext = dbcontext;
        }


        public DoadorDetailsViewModel GetById(int id)
        {
            var doador = _dbcontext.Doadores.SingleOrDefault(d => d.Id == id);

            if (doador.Status == DoadorStatusEnum.Removido)
                return null;

            var doadoresDetailsViewModel = new DoadorDetailsViewModel(
                doador.Id,
                doador.NomeCompleto,
                doador.Email,
                doador.DataNascimento,
                doador.Genero,
                doador.Peso,
                doador.TipoSanguineo,
                doador.FatorRh,
                doador.Endereco,
                doador.Doacoes
                );

            return doadoresDetailsViewModel;
        }

        public List<DoadorViewModel> GetAll()
        {
            var doadores = _dbcontext.Doadores;

            // Filtrando doadores ativos
            var doadoresAtivos = _dbcontext.Doadores
                .Where(d => d.Status == DoadorStatusEnum.Ativo)
                .ToList();

            var doadoresViewModel = doadoresAtivos
            .Select(d => new DoadorViewModel(d.Id, d.NomeCompleto, d.Email, d.DataNascimento, d.Genero))
            .ToList();

            return doadoresViewModel;
        }

        public int Create(NewDoadorInputModel inputModel)
        {

            var doador = new Doador(
                inputModel.Id,
                inputModel.NomeCompleto,
                inputModel.Email,
                inputModel.DataNascimento,
                inputModel.Genero,
                inputModel.Peso,
                inputModel.TipoSanguineo,
                inputModel.FatorRh
               );

            _dbcontext.Doadores.Add(doador);

            return doador.Id;
        }

        public void Delete(int id)
        {
            var doadores = _dbcontext.Doadores.SingleOrDefault(d => d.Id == id);

            doadores.DeleteDoador();

        }


        public void Update(UpdateDoadorInputModel inputModel)
        {
            var doador = _dbcontext.Doadores.SingleOrDefault(d => d.Id == inputModel.Id);

            doador.Update(inputModel.NomeCompleto, inputModel.Email, inputModel.DataNascimento, inputModel.Genero, inputModel.Peso, inputModel.TipoSanguineo, inputModel.FatorRh);
        }

    }
}
