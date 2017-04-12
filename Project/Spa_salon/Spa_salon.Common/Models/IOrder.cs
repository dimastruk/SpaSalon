using Spa_salon.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Models
{
    public interface IOrder
    {
        int OrderId { get; }
        IClient Client { get; }
        DateTime OrderDate { get; }
        TimeSpan OrderTime { get; }
        bool IsActual { get; }
        int TotalPrice { get; }
        ICollection<IOrderDetail> OrderDetails { get; }
    }

    public class Order : IOrder
    {
        public Order(int orderId, IClient client, DateTime orderDate, TimeSpan orderTime,
            bool isActual, int totalPrice)
        {
            OrderId = orderId;
            Client = client;
            OrderDate = orderDate;
            OrderTime = orderTime;
            IsActual = isActual;
            TotalPrice = totalPrice;

            var orderDetailsService = new OrderDetailService();
            OrderDetails = orderDetailsService.GetOrderDetails(OrderId);
        }

        public IClient Client
        {
            get;
        }

        public bool IsActual
        {
            get;
        }

        public DateTime OrderDate
        {
            get;
        }

        public ICollection<IOrderDetail> OrderDetails
        {
            get;
        }

        public int OrderId
        {
            get;
        }

        public TimeSpan OrderTime
        {
            get;
        }

        public int TotalPrice
        {
            get;
        }
    }
}
