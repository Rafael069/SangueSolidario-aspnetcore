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
using System.Net.Http;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Services.Implementations
{
    public class EnderecoService : IEnderecoService
    {

        // Utilizando _dbcontext (Banco Fake)
        private readonly SangueSolidarioDbContext _dbcontext;

        private readonly string _connectionString;

        private readonly HttpClient _httpClient; //

        public EnderecoService(SangueSolidarioDbContext dbcontext, HttpClient httpClient, IConfiguration configuration)
        {

            _dbcontext = dbcontext;
            _httpClient = httpClient;

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

        // Método para criar um novo endereço, agora integrando com ViaCepService
        public async Task<int> CreateEndereco(string cep)
        {
            // Fazendo a requisição à API do ViaCEP
            var response = await _httpClient.GetAsync($"{cep}/json/");
            response.EnsureSuccessStatusCode();

            // Deserializando a resposta da API do ViaCEP
            var enderecoData = await response.Content.ReadAsStringAsync();
            var viaCepEndereco = JsonSerializer.Deserialize<NewEnderecoInputModel>(enderecoData);

            var endereco = new Endereco(
                viaCepEndereco.Logradouro,
                viaCepEndereco.Cidade,
                viaCepEndereco.Estado,
                viaCepEndereco.CEP
            );

            try
            {
                // Salvando Endereco no banco de dados
                await _dbcontext.Enderecos.AddAsync(endereco);
                await _dbcontext.SaveChangesAsync(); // O endereço será salvo, e o ID será gerado
                return endereco.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar o endereço: {ex.Message}");
                throw;
            }


        }

        public void Delete(int id)
        {

            var enderecos = _dbcontext.Enderecos.SingleOrDefault(d => d.Id == id);

            enderecos.DeleteEndereco();
            _dbcontext.SaveChanges();
        }



        public void Update(UpdateEnderecoInputModel inputModel)
        {
            var endereco = _dbcontext.Enderecos.SingleOrDefault(e => e.Id == inputModel.Id);

            endereco.Update(inputModel.Logradouro, inputModel.Cidade, inputModel.Estado, inputModel.CEP);
            _dbcontext.SaveChanges();
        }

    }
}
