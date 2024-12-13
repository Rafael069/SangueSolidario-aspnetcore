using SangueSolidario.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.InputModels
{
    public class UpdateEnderecoInputModel
    {
        public int Id { get; set; }
        public string Logradouro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }
        public int DoadorId { get; set; }
        
        public EnderecoStatusEnum Status { get; set; }
    }
}
