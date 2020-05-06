using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTime.Domain.Abstractions
{
    public interface IDomainEventHandler<TDomainEvent> : INotificationHandler<TDomainEvent> where 
    {
    }
}
