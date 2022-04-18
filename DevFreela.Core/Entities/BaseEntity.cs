using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Entities
{
    public abstract class BaseEntity // uma classe abstrata contém informações que serão utilizadas por diferentes classes
    {
        protected BaseEntity() { } // construtor criado para dar suporte ao Entity Framework Core
        
        public int Id { get; private set; } // Como várias entidades terão um Id, já podemos criar nessa classe de abstração
    }
}
