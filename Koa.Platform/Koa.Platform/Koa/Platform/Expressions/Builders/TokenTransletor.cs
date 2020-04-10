using System;
using System.Linq.Expressions;

namespace Koa.Platform.Expressions.Builders
{

    //public class TokenOperators : Dictionary<string, ExpressionType>
    //{
    //    public TokenOperators()
    //    {

    //        Add( "==", ExpressionType.Equal );
    //        Add("!=", ExpressionType.NotEqual);
    //        Add( "<>", ExpressionType.NotEqual);
    //        Add( "&&", ExpressionType.And);
    //        Add( "||", ExpressionType.Or);
    //        Add( ">", ExpressionType.GreaterThan);
    //        Add(">=", ExpressionType.GreaterThanOrEqual);
    //        Add( "<", ExpressionType.LessThan);
    //        Add("<=", ExpressionType.LessThanOrEqual);

    //    }
    //}

    //public class KendoTokenOperators : TokenOperators
    //{
    //    public KendoTokenOperators() 
    //    {
    //        Add("eq", ExpressionType.Equal);
    //        Add( "neq", ExpressionType.NotEqual);
    //        Add( "and", ExpressionType.And);
    //        Add( "or", ExpressionType.Or);
    //        Add( "lt", ExpressionType.LessThan);
    //        Add( "lte", ExpressionType.LessThanOrEqual );
    //        Add( "gt", ExpressionType.GreaterThan);
    //        Add( "gte", ExpressionType.GreaterThanOrEqual);
    //    }


    //}

    //public interface ITokenTransletor 
    //{
    //    ExpressionType? this[string key] { get; }

    //    ExpressionType GetOrDefault(string key, ExpressionType defaultValue);
    //}

    public class TokenTransletor: ITokenTransletor {

        private readonly TokenOperators _items;

        public TokenTransletor(TokenOperators operators)
        {
            _items = operators ?? new TokenOperators();
        }

        public Func<Expression, Expression, Expression> this[string key]
        {
            get
            {
                Func<Expression, Expression, Expression> type = (member,constant) => Expression.Empty();

                if (_items.ContainsKey(key))
                {
                    type = _items[key];
                }

                return type;
            }
        }

        public Func<Expression, Expression, Expression> GetOrDefault(string key, Func<Expression, Expression, Expression> defaultValue)
        {
            return this[key] ?? defaultValue;
        }
    }
}