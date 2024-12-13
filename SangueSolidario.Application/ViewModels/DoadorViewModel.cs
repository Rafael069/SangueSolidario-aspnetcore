using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.ViewModels
{
    public class DoadorViewModel
    {

        public DoadorViewModel(int id,string nomeCompleto, string email, DateTime dataNascimento, string genero)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Email = email;
            DataNascimento = dataNascimento;
            Genero = genero;
        }

        public int Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Genero { get; private set; }
    }
}
