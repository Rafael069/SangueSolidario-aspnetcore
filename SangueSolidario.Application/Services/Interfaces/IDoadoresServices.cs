using SangueSolidario.Application.InputModels;
using SangueSolidario.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Services.Interfaces
{
    public interface IDoadoresServices
    {
        List<DoadorViewModel> GetAll();

        DoadoresDetailsViewModel GetById(int id);

        int Create (NewDoadorInputModel inputModel);

        void Update(UpdateDoadorInputModel inputModel);

        void Delete(int id);
    }
}
