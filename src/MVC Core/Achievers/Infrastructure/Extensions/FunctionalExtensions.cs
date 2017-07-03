using Achievers.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Achievers.Infrastructure.Extensions
{
    public static class FunctionalExtensions
    {
        public static TResult PipeTo<TSource, TResult>(
            this TSource source, Func<TSource, TResult> func)
        {
            return func(source);
        }

        public static TOutput Either<TInput, TOutput>(
            this TInput source,
            Func<TInput, bool> condition,
            Func<TInput, TOutput> ifTrue,
            Func<TInput, TOutput> ifFalse)
        {
            return condition(source) ? ifTrue(source) : ifFalse(source);
        }

        public static TOutput Either<TInput, TOutput>(
            this TInput source,
            Func<TInput, TOutput> ifTrue,
            Func<TInput, TOutput> ifFalse)
            => source.Either(x => x != null, ifTrue, ifFalse);
        
        public static T Do<T>(this T source, Action<T> action)
        {
            if (source != null)
            {
                action(source);
            }

            return source;
        }

        public static TEntity ById<TKey, TEntity>(this IQueryable<TEntity> queryable, TKey id)
            where TEntity : BaseModel<TKey>
            where TKey : IComparable, IComparable<TKey>, IEquatable<TKey>
        {
            return queryable.SingleOrDefault(x => x.Id.Equals(id));
        }

        public static IQueryable<T> Paginate<T>(this IOrderedQueryable<T> queryable, IPaging paging)
        {
            return queryable
                .Skip((paging.Page - 1) * paging.Take)
                .Take(paging.Take);
        }

        public static IPagedEnumerable<T> ToPagedEnumerable<T>(
            this IOrderedQueryable<T> queryable,
            IPaging paging)
            where T : class
        {
            return From(queryable.Paginate(paging).ToArray(), queryable.Count());
        }

        public static IPagedEnumerable<T> From<T>(IEnumerable<T> inner, int totalCount)
        {
            return new PagedEnumerable<T>(inner, totalCount);
        }

        //public static IQueryable<T> MaybeWhere<T>(this IQueryable<T> source, object spec)
        //    where T : class
        //{
        //    var specification = spec as IQueryableSpecification<T>;
        //    if (specification != null)
        //    {
        //        source = specification.Apply(source);
        //    }

        //    var expr = spec as Expression<Func<T, bool>>;
        //    if (expr != null)
        //    {
        //        source = source.Where(expr);
        //    }

        //    return source;
        //}

        //public static IQueryable<T> MaybeWhere<T>(this IQueryable<T> source, object spec)
        //    where T : class
        //{
        //    var specification = spec as IQueryableSpecification<T>;
        //    if (specification != null)
        //    {
        //        source = specification.Apply(source);
        //    }

        //    var expr = spec as Expression<Func<T, bool>>;
        //    if (expr != null)
        //    {
        //        source = source.Where(expr);
        //    }

        //    return source;
        //}
    }
}
