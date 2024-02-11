using FreeCourse.Services.Order.Domain.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeCourse.Services.Order.Domain.OrderAggregate
{
    public class Order:Entity, IAggregateRoot
    {
        public DateTime CreatedDate { get; private set; }

        public Address Address { get; private set; } 
        public string BuyerId { get; private set; }

        private readonly List<OrderItem> _orderItem;

         public IReadOnlyCollection<OrderItem> OrderItems  => _orderItem;
        public Order()
        {

        }
        public Order(string buyerId, Address address)
        {
            Address = address;
            BuyerId = buyerId;
            CreatedDate = DateTime.Now;
            _orderItem = new List<OrderItem>();
        }

        public void AddOrderItem(string productId, string productName, decimal price, string pictureUrl)
        {
            var existProduct = _orderItem.Any(x => x.ProductId == productId);
            if(!existProduct)
            {
                var newOrderItem = new OrderItem(productId, productName, pictureUrl, price);
                _orderItem.Add(newOrderItem);
            }
        }

        public decimal TotalPrice => _orderItem.Sum(x => x.Price);

    }
}
