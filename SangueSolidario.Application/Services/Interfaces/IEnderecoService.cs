using SangueSolidario.Application.InputModels;
using SangueSolidario.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Services.Interfaces
{
    public interface IEnderecoService
    {
        List<EnderecoViewModel> GetAll();

        EnderecoDetailsViewModel GetById(int id);

        int Create(NewEnderecoInputModel inputModel);

        void Update(UpdateEnderecoInputModel inputModel);

        void Delete(int id);
    }
}
