using Koa.Platform;
using System.Linq.Expressions;

namespace Koa.Platform.Expressions.Builders
{
    public class KendoTokenOperators : TokenOperators
    {
        public KendoTokenOperators()
        {
            Add("eq", ExpressionType.Equal);
            Add("neq", ExpressionType.NotEqual);
            Add("and", ExpressionType.And);
            Add("or", ExpressionType.Or);
            Add("lt", ExpressionType.LessThan);
            Add("lte", ExpressionType.LessThanOrEqual);
            Add("gt", ExpressionType.GreaterThan);
            Add("gte", ExpressionType.GreaterThanOrEqual);
        }
    }
}
