using SangueSolidario.Application.InputModels;
using SangueSolidario.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Services.Interfaces
{
    public interface IEstoqueDeSangueService
    {
        List<EstoqueDeSangueViewModel> GetAll();

        EstoqueDeSangueDetailsViewModel GetById(int id);

        int Create(NewEstoqueDeSangueInputModel inputModel);

        void UpdateEstoque(Doador doador, int quantidadeML);

        void Delete(int id);

        List<RelatorioEstoqueSangueViewModel> GerarRelatorioQuantidadePorTipo();
        List<EstoqueDeSangueDetailsViewModel> VerificarEstoquesCriticos();
    }
}
