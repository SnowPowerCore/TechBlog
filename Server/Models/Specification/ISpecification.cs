using System;
using System.Linq.Expressions;

namespace PersonalTechBlog.Server.Models.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> IsSatisfiedBy();
    }
}