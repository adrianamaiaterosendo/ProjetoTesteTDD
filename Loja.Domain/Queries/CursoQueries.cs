using System;
using System.Linq.Expressions;
using Loja.Domain.Entities;

namespace Loja.Domain.Queries
{
    public class CursoQueries
    {

        public static Expression<Func<Curso, bool>> GetActiveProducts(){
            return x => x.Ativo;
        }

         public static Expression<Func<Curso, bool>> GetInactiveProducts(){
            return x => x.Ativo == false;
        }


        
    }
}