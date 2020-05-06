using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeekTime.Domain.Abstractions
{
    public abstract class ValueObject
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right)
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            ValueObject other = (ValueObject)obj;
            IEnumerator<object> thisValus = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValus = other.GetAtomicValues().GetEnumerator();

            while (thisValus.MoveNext() && otherValus.MoveNext())
            {
                if (ReferenceEquals(thisValus.Current, null) ^ ReferenceEquals(otherValus, null))
                {
                    return false;
                }
                if (thisValus.Current != null && !thisValus.Current.Equals(otherValus.Current))
                {
                    return false;
                }
            }
            return !thisValus.MoveNext() && !otherValus.MoveNext();
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
                .Select(c => c != null ? c.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }
    }
}
