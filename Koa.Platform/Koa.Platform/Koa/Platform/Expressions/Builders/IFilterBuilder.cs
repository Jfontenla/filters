using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Koa.Platform.Expressions.Builders
{
    public interface IFilterBuilder<T> where T : class
    {
        Expression<Func<T, bool>> Build();
    }
}
