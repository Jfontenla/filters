using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;


namespace Koa.Platform.Expressions.Builders
{
    public class TokenOperators : Dictionary<string, Func<Expression, Expression, Expression>>
    {
        protected Func<Expression, Expression, Expression> Equal => (member, constant) => Expression.MakeBinary(ExpressionType.Equal, member, constant);

        protected Func<Expression, Expression, Expression> And => (member, constant) => Expression.MakeBinary(ExpressionType.And, member, constant);

        protected Func<Expression, Expression, Expression> Or => (member, constant) => Expression.MakeBinary(ExpressionType.Or, member, constant);

        protected Func<Expression, Expression, Expression> CallContains => (member, constant) =>
        {
            var contains = typeof(string).GetMethod("Contains", BindingFlags.Public & BindingFlags.Static);

            return Expression.Call(member, contains, constant);
        };
        
        public TokenOperators()
        {
            Add("==", Equal);
            //Add("!=", ExpressionType.NotEqual);
            //Add("<>", ExpressionType.NotEqual);
            Add("&&", And);
            Add("||", Or);
            //Add(">", ExpressionType.GreaterThan);
            //Add(">=", ExpressionType.GreaterThanOrEqual);
            //Add("<", ExpressionType.LessThan);
            //Add("<=", ExpressionType.LessThanOrEqual);
            Add("Contains", CallContains);

            
        }
    }
}

