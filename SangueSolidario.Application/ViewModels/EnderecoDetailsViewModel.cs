using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.ViewModels
{
    public class EnderecoDetailsViewModel
    {
        public EnderecoDetailsViewModel(int id, string logradouro, string cidade, string estado, string cEP, int doadorId, Doador? doador)
        {
            Id = id;
            Logradouro = logradouro;
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
            DoadorId = doadorId;
            Doador = doador;
        }

        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public int DoadorId { get; set; }
        public Doador? Doador { get; set; }
    }
}
