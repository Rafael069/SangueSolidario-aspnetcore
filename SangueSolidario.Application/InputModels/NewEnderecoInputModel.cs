using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SangueSolidario.Application.InputModels
{
    public class NewEnderecoInputModel
    {
        public int Id { get; set; }

        [JsonPropertyName("logradouro")]
        public string Logradouro { get; set; }
        [JsonPropertyName("localidade")]
        public string Cidade { get; set; }
        [JsonPropertyName("uf")]
        public string Estado { get; set; }
        [JsonPropertyName("cep")]
        public string CEP { get; set; }
        public int IdDoador { get; set; }
        //public Doador? Doador { get; set; }
        //public EnderecoStatusEnum Status { get; set; }
    }
}
