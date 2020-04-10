using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koa.Platform.Expressions.Builders
{
    public interface ITokenTransletor
    {
        Func<Expression, Expression, Expression> this[string key] { get; }

        Func<Expression, Expression, Expression> GetOrDefault(string key, Func<Expression, Expression, Expression> defaultValue);
    }
}
