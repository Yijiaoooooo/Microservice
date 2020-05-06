using GeekTime.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeekTime.Domain.OrderAggregate
{
    public class Order : Entity<long>, IAggregateRoot
    {
        public string UserId { get; private set; }

        public string UserName { get; private set; }

        public Address Address { get; private set; }

        public int ItemCount { get; private set; }

        protected Order()
        { }

        public Order(string userId, string userName, Address address, int itemCount)
        {
            this.UserId = userId;
            this.UserName = userName;
            this.Address = address;
            this.ItemCount = itemCount;
        }

        public void ChangeAddress(Address address)
        {
            this.Address = address;
        }
    }
}
