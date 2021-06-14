using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Specification.Base.Interfaces
{
    /// <summary>
    /// Contrato Base para usar o Specification
    /// </summary>
    /// <typeparam name="T">Tipagem da entidade</typeparam>

    public interface ISpecification<T> where T:class
    {

        /// <summary>
        /// Método que verifica se a specification é satisfeita por uma expressão lambda
        /// </summary>
        /// <returns> A expressão para satisfazer</returns>
        Expression<Func<T, bool>> IsSatisfiedBy();

    }
}
