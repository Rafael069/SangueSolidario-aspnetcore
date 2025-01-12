using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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

        private readonly SangueSolidarioDbContext _dbcontext;
        private readonly string _connectionString;
        //
        private readonly IEnderecoService _enderecoService;
        //

        public DoadorService(SangueSolidarioDbContext dbcontext, IEnderecoService enderecoService, IConfiguration configuration)
        {
            // Injeção de Dependência
            _dbcontext = dbcontext;
            _enderecoService = enderecoService;
            _connectionString = configuration.GetConnectionString("SangueSolidarioCs");
        }




        public DoadorDetailsViewModel GetById(int id)
        {
            var doador = _dbcontext.Doadores
                // Trazer dados de endereços e doações
                .Include(d => d.Endereco)
                .Include(d => d.Doacoes)
                .SingleOrDefault(d => d.Id == id);

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

        public async Task<int> Create(NewDoadorInputModel inputModel)
        {

 

            // Criando Doador
            var doador = new Doador(
            inputModel.NomeCompleto,
            inputModel.Email,
            inputModel.DataNascimento,
            inputModel.Genero,
            inputModel.Peso,
            inputModel.TipoSanguineo,
            inputModel.FatorRh
            );

            // Associar o endereço ao doador
            

            // Adiciona o doador ao banco de dados
            await _dbcontext.Doadores.AddAsync(doador);
            await _dbcontext.SaveChangesAsync(); // Salvar o doador no banco

            //Criar Endereco
            var enderecoId = await _enderecoService.CreateEndereco(inputModel.CEP,doador.Id);



            //Associar o endereço ao doador
            doador.IdEndereco = enderecoId;

            // Aualiza 

            _dbcontext.Doadores.Update(doador);
            await _dbcontext.SaveChangesAsync(); // Salvar o doador no banco

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
            _dbcontext.SaveChanges();
        }

    }
}
