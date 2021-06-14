using Core.Domain.Specification.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Specification.Base
{
    /// <summary>
    /// Classe base para specification Compostas
    /// </summary>
    /// <typeparam name="T"> Entidade que verifica a especificação </typeparam>
    public abstract class CompositeSpecification<T>:Specification<T>where T:class
    {
        /// <summary>
        /// Lado Esquerdo da especificação para este elemento composto
        /// </summary>
        public abstract ISpecification<T> LeftSideSpecification { get; }

        /// <summary>
        /// Lado Direito da especificação para este elemento composto
        /// </summary>

        public abstract ISpecification<T> RightSideSpecification { get; }
    }
}
