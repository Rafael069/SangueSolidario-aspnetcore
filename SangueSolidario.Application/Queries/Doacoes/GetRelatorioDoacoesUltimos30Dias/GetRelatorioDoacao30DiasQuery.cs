using MediatR;
using SangueSolidario.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Application.Queries.Doacoes.GetRelatorioDoacoesUltimos30Dias
{
    public class GetRelatorioDoacao30DiasQuery : IRequest<List<RelatorioDoacaoViewModel>>
    {

    }
}
