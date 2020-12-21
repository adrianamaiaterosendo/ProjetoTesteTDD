using System;
using System.Collections.Generic;
using System.Linq;
using Loja.Domain.Entities;
using Loja.Domain.Enums;
using Loja.Domain.Queries;
using Microsoft.VisualStudio.TestTools.UnitTesting;




namespace Loja.Testes.Queries
{
    [TestClass]
    public class CursoQuerysTests
    {  
        
        private IList<Curso> _cursos;
         public CursoQuerysTests(){
            _cursos = new List<Curso>();
            _cursos.Add(new Curso("Produto 01", 10, true));
            _cursos.Add(new Curso("Produto 02", 10, true));
            _cursos.Add(new Curso("Produto 03", 10, true));
            _cursos.Add(new Curso("Produto 04", 10, false));
            _cursos.Add(new Curso("Produto 05", 10, false));

        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_ativos_deve_retornar_3(){
                var result = _cursos.AsQueryable().Where(CursoQueries.GetActiveProducts());
                Assert.AreEqual(result.Count(), 3);
        }

        [TestMethod]
        [TestCategory("Queries")]
        public void Dado_a_consulta_de_produtos_inativos_deve_retornar_2(){
            var result = _cursos.AsQueryable().Where(CursoQueries.GetInactiveProducts());
            Assert.AreEqual(result.Count(), 2);
        }
        
    }
}