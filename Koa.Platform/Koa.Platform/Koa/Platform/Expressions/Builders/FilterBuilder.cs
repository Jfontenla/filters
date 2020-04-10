using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Koa.Platform.Ddd.Application.Constracts.Dtos;
using Volo.Abp;

namespace Koa.Platform.Expressions.Builders
{
    public sealed class FilterBuilder<T> : IFilterBuilder<T> where T : class
    {

        private readonly List<FilterDescriptor> _filterDescriptors;
        private readonly string _tokenLogicOperator;
        private readonly ITokenTransletor _tokenTransletor;
        private readonly Func<Expression, Expression, Expression> _union;
           

        public FilterBuilder(string logicOperator = null)
        {
            _tokenLogicOperator = logicOperator;
            _tokenTransletor = new TokenTransletor(new KendoTokenOperators()); //TODO: Invertir en dependencias, refactorizar
            _union = _tokenTransletor.GetOrDefault(logicOperator, (m, c) => Expression.Or(m, c));

            _filterDescriptors = new List<FilterDescriptor>();
        }

        public void Add(FilterDescriptor filterDescriptor)
        {
            Check.NotNull(filterDescriptor, nameof(filterDescriptor));

            _filterDescriptors.Add(filterDescriptor);
        }

        public void AddRange(List<FilterDescriptor> filterDescriptors)
        {
            Check.NotNull(filterDescriptors, nameof(filterDescriptors));

            _filterDescriptors.AddRange(filterDescriptors);
        }

        public Expression<Func<T, bool>> Build()
        {

            var body = MakeDefault();

            var parameter = Expression.Parameter(typeof(T), typeof(T).Name.ToLower());
            foreach (var filterDescriptor in _filterDescriptors)
            {
                var member = Expression.Property(parameter, filterDescriptor.Field);
                var constant = Expression.Constant(filterDescriptor.Value);
                var @delegate = _tokenTransletor.GetOrDefault(filterDescriptor.Operator, (m, c) => Expression.Equal(m, c));
                var result = @delegate(member, constant);

                body = _union(body, result);
            }

            var predicate = Expression.Lambda(body, parameter);
            return predicate as Expression<Func<T, bool>>;
        }

        private Expression MakeDefault()
        {
            var @default = Expression.Constant(true);
            var opposite = Expression.Constant(!(bool)@default.Value);

            var expression = _union(@default, @default);

            switch (expression)
            {
                case BinaryExpression binary when binary.NodeType == ExpressionType.Or:
                    return _union(@default,opposite);
                default:
                    return expression;
            }
        }
    }
}
