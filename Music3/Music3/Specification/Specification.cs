using Music3.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq.Expressions;

namespace Music3.Specification
{
    public abstract class Specification<TEntity> where TEntity : Entity
    {
        public abstract Expression<Func<TEntity, bool>> ToExpression();

        public bool IsSatisfiedBy(TEntity entity)
        {
            Func<TEntity, bool> predicate = ToExpression().Compile();
            return predicate(entity);
        }
    }
}
