using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Models
{
    public interface IOrderDetail
    {
        int OrderDetailId { get; }
        int OrderId { get; }
        ISpeciality Speciality { get; }
        IOrder Order { get; }
    }

    public class OrderDetail : IOrderDetail
    {
        public OrderDetail(int orderDetailId, ISpeciality speciality, IOrder order)
        {
            OrderDetailId = orderDetailId;
            Speciality = speciality;
            Order = order;
        }

        public OrderDetail(int orderDetailId, ISpeciality speciality, int orderId)
        {
            OrderDetailId = orderDetailId;
            Speciality = speciality;
            OrderId = orderId;
        }

        public IOrder Order
        {
            get;
        }

        public int OrderDetailId
        {
            get;
        }

        public int OrderId
        {
            get;
        }

        public ISpeciality Speciality
        {
            get;
        }
    }
}
