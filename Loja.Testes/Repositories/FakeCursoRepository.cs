using Loja.Domain.Entities;
using System;
using System.Collections.Generic;
using Loja.Domain.Repositories.Interfaces;

namespace Loja.Testes.Repositories
{
    public class FakeCursoRepository : ICursoRepository
    {
        public IEnumerable<Curso> Get(IEnumerable<Guid> ids){
            IList<Curso> cursos = new List<Curso>();
            cursos.Add(new Curso("Produto 01", 10, true));
            cursos.Add(new Curso("Produto 02", 10, true));
            cursos.Add(new Curso("Produto 03", 10, true));
            cursos.Add(new Curso("Produto 04", 10, false));
            cursos.Add(new Curso("Produto 05", 10, false));

            return cursos;

        }
    }
}