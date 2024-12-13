using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel(int id, string logradouro, string cidade, string estado, string cep)
        {
            Id = id;
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
        }

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
    }
}
