using SangueSolidario.Application.InputModels;
using SangueSolidario.Application.Services.Interfaces;
using SangueSolidario.Application.ViewModels;
using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;
using SangueSolidario.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Services.Implementations
{
    public class EnderecoService : IEnderecoService
    {

        // Utilizando _dbcontext (Banco Fake)
        private readonly SangueSolidarioDbContext _dbcontext;

        public EnderecoService(SangueSolidarioDbContext dbcontext)
        {
            // Injeção de Dependência
            _dbcontext = dbcontext;
        }


        public EnderecoDetailsViewModel GetById(int id)
        {
            var endereco = _dbcontext.Enderecos.SingleOrDefault(d => d.Id == id);

            if (endereco.Status == EnderecoStatusEnum.Removido)
                return null;

            var enderecoDetailsViewModel = new EnderecoDetailsViewModel(
                endereco.Id,
                endereco.Logradouro,
                endereco.Cidade,
                endereco.Estado,
                endereco.CEP,
                endereco.IdDoador,
                endereco.Doador
                );

            return enderecoDetailsViewModel;

        }


        public List<EnderecoViewModel> GetAll()
        {
            var enderecos = _dbcontext.Enderecos;

            // Filtrando livros ativos
            var enderecosAtivas = _dbcontext.Enderecos
                .Where(e => e.Status == EnderecoStatusEnum.Ativo)
                .ToList();

            var enderecosViewModel = enderecosAtivas
            .Select(e => new EnderecoViewModel(e.Id, e.Logradouro, e.Cidade, e.Estado, e.CEP))
            .ToList();

            return enderecosViewModel;
        }

        public int Create(NewEnderecoInputModel inputModel)
        {
            var endereco = new Endereco(inputModel.Logradouro, inputModel.Cidade, inputModel.Estado, inputModel.CEP, inputModel.DoadorId);

            _dbcontext.Enderecos.Add(endereco);

            return endereco.Id;
        }

        public void Delete(int id)
        {

            var enderecos = _dbcontext.Enderecos.SingleOrDefault(d => d.Id == id);

            enderecos.DeleteEndereco();
        }

        

        public void Update(UpdateEnderecoInputModel inputModel)
        {
            var endereco = _dbcontext.Enderecos.SingleOrDefault(e => e.Id == inputModel.Id);

            endereco.Update(inputModel.Logradouro, inputModel.Cidade, inputModel.Estado, inputModel.CEP);
        }
    }
}
