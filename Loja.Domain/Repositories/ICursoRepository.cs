using System;
using System.Collections.Generic;
using Loja.Domain.Entities;

namespace Loja.Domain.Repositories.Interfaces
{
    public interface ICursoRepository
    {
        IEnumerable<Curso> Get (IEnumerable<Guid> ids);
        
    }
}