using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTime.Domain.Abstractions
{
    public interface IEntity
    {
        /// <summary>
        /// 获取ID，不排除实体存在多个ID
        /// </summary>
        /// <returns></returns>
        Object[] GetKeys();
    }

    /// <summary>
    /// 泛型实体，ID只有一个
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; }
    }
}
