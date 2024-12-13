using SangueSolidario.Core.Entities;
using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.ViewModels
{
    public class DoadorDetailsViewModel
    {
        public DoadorDetailsViewModel(int id,string nomeCompleto, string email, DateTime dataNascimento, string genero, double peso, string tipoSanguineo, string fatorRh, Endereco endereco, List<Doacao> doacoes/*, DoacaoStatusEnum status*/)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
            Peso = peso;
            TipoSanguineo = tipoSanguineo;
            FatorRh = fatorRh;
            Endereco = endereco;
            Doacoes = doacoes;
            //Status = DoadorStatusEnum.Ativo;
        }

        public int Id { get;  set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public double Peso { get; set; }
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public Endereco Endereco { get; set; }
        public List<Doacao> Doacoes { get; set; }
        public DoadorStatusEnum Status { get; set; }



    }
}
