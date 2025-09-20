using MediatR;

namespace SangueSolidario.Application.Commands.Doadores.CreateDoador
{
    // Vai trazer as informações para o cadastro
    public class CreateDoadorCommand :  IRequest<int>
    {
        //public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Genero { get; set; }
        public double Peso { get; set; }
        public string TipoSanguineo { get; set; }
        public string FatorRh { get; set; }
        public string CEP { get; set; }
        //public int IdEndereco { get; set; }
        //public int IdDoacao { get; set; }
    }
}
