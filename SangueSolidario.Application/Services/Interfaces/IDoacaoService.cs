using SangueSolidario.Application.InputModels;
using SangueSolidario.Application.ViewModels;
using System;


namespace SangueSolidario.Application.Services.Interfaces
{
    public interface IDoacaoService
    {
        List<DoacaoViewModel> GetAll();

        DoacaoDetailsViewModel GetById(int id);

        int Create(NewDoacaoInputModel inputModel);

        void Update(UpdateDoacaoInputModel inputModel);

        void Delete(int id);
        List<RelatorioDoacaoViewModel> GerarRelatorioDoacoesUltimos30Dias();
    }
}
