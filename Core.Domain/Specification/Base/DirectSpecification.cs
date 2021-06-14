using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Specification.Base
{
    /// <summary>
    /// Direct Specification é uma implementação simples de uma especificação que é 
    /// obtida através de uma expressão lambda no construtor
    /// </summary>
    /// <typeparam name="T"> tipo de uma entidade que checa essa especificação</typeparam>
    public sealed class DirectSpecification<T>:Specification<T>where T:class
    {
        private readonly Expression<Func<T, bool>> _matchingCriteria;
        /// <summary>
        /// Construtor padrão da DirectSpecification
        /// </summary>
        /// <param name="matchingCriteria"> Criterio avaliador</param>
        public DirectSpecification(Expression<Func<T,bool>>matchingCriteria)
        {
            if (matchingCriteria == (Expression<Func<T, bool>>)null)
                throw new ArgumentNullException("matchingCriteria");

            _matchingCriteria = matchingCriteria;
        }

        public override Expression<Func<T, bool>> IsSatisfiedBy()
                                        => _matchingCriteria;
    }
}
