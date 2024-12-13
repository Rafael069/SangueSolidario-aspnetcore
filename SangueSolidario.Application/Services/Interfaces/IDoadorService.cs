using SangueSolidario.Application.InputModels;
using SangueSolidario.Application.ViewModels;
using System;


namespace SangueSolidario.Application.Services.Interfaces
{
    public interface IDoadorService
    {
        List<DoadorViewModel> GetAll();

        DoadorDetailsViewModel GetById(int id);

        int Create (NewDoadorInputModel inputModel);

        void Update(UpdateDoadorInputModel inputModel);

        void Delete(int id);
    }
}
