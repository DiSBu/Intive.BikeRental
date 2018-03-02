using System;
using System.Collections.Generic;
using System.Data;

namespace Intive.BikeRental.Repository.Transformers
{
    public enum NoCreateParameter
    {
    }

    public abstract class BaseTransformer<T>
    {
        public static Func<IDataReader, T, T> NoExtraFields
        {
            get { return (dr, obj) => obj; }
        }

        public IList<T> Transform(IDataReader dr)
        {
            return Transform(dr, NoExtraFields);
        }

        public IList<T> Transform(IDataReader dr, Func<IDataReader, T, T> extraParam)
        {
            var results = new List<T>();
            while (dr.Read())
            {
                results.Add(TransformSubElement(dr, extraParam));
            }

            return results;
        }
        
        public T TransformSubElement(IDataReader dr, Func<IDataReader, T, T> bindExtraFields = null)
        {
            return bindExtraFields != null ? bindExtraFields(dr, TransformElement(dr, bindExtraFields)) : TransformElement(dr);
        }

        internal abstract T TransformElement(IDataReader dr, Func<IDataReader, T, T> bindExtraFields = null);
    }
}