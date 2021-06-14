using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Specification.Base.Util
{

    /// <summary>
    /// Classe de Auxilio para  mapear sem usar um Invoke method nas expressões,
    /// </summary>
    public sealed class ParameterRebinder:ExpressionVisitor
    {
        private readonly Dictionary<ParameterExpression, ParameterExpression> _map;

        /// <summary>
        /// Construtor Padrão
        /// </summary>
        /// <param name="map">Map Specification</param>
        public ParameterRebinder(Dictionary<ParameterExpression,ParameterExpression>map)
        {
            this._map = map ?? new Dictionary<ParameterExpression, ParameterExpression>();
        }

        /// <summary>
        /// Substituir parametros na expressão com a informação do mapa
        /// </summary>
        /// <param name="externMap">Informações do mapa</param>
        /// <param name="expToReplace">Expressão para substituir parametros</param>
        /// <returns>Expressão com parametros substituidos</returns>
        public static Expression ReplaceParameters(Dictionary<ParameterExpression, ParameterExpression> externMap, Expression expToReplace)
                    => new ParameterRebinder(externMap).Visit(expToReplace);


        /// <summary>
        /// Visti Pattern Method
        /// </summary>
        /// <param name="parameterToReplace">Parametro da expressão</param>
        /// <returns>Expressão com parametros substituidos</returns>
        protected override Expression VisitParameter(ParameterExpression parameterToReplace)
        {
            if (_map.TryGetValue(parameterToReplace, out ParameterExpression replacement))
                parameterToReplace = replacement;

            return base.VisitParameter(parameterToReplace);
        }

    }
}
