using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SangueSolidario.Core.Entities
{
    // Classe base que vai ser utilizada por diferentes classes mas não ser instanciada
    public abstract class BaseEntity
    {
        protected BaseEntity() { }
        public int Id { get; private set; }
    }
    
}
