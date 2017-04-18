using Spa_salon.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    using DAL.DbModel;
    using Orders = DAL.DbModel.Orders;
    public interface IOrderService
    {
        IOrder GetOrder(Orders order);
        IOrder GetOrder(int orderId);
        ICollection<IOrder> GetOrders(ICollection<ISpeciality> specialities);
        ICollection<IOrder> GetOrders(int salonId);
    }

    public class OrderService : DbDependentService, IOrderService
    {
        public IOrder GetOrder(int orderId)
        {
            var order = DbService.Context.Orders.FirstOrDefault(o => o.order_id == orderId);
            return GetOrder(order);
        }

        public IOrder GetOrder(Orders order)
        {
            if(order == null)
            {
                throw new ArgumentNullException("order");
            }

            var clientService = new ClientService();
            var client = clientService.GetClient(DbService.Context.Clients.FirstOrDefault(c => c.client_id == order.client_id));

            return new Order(order.order_id, client, order.order_date, order.order_time, order.isActual, order.total_price);
        }

        public ICollection<IOrder> GetOrders(int salonId)
        {
            var list = new List<IOrder>();

            var orders = (from DbOrders in DbService.Context.Orders
                          join DbOrderDetails in DbService.Context.OrderDetails on DbOrders.order_id equals DbOrderDetails.order_id
                          join DbSpecialities in DbService.Context.Specialities on DbOrderDetails.speciality_id equals DbSpecialities.speciality_id
                          join DbWorkers in DbService.Context.Workers on DbSpecialities.worker_id equals DbWorkers.worker_id
                          where DbWorkers.salon_id == salonId
                          select DbOrders).Distinct();

            foreach(var order in orders)
            {
                list.Add(GetOrder(order));
            }

            list = list.OrderBy(o => o.OrderDate).ThenBy(o => o.OrderTime).ToList();

            return list;
        }

        public ICollection<IOrder> GetOrders(ICollection<ISpeciality> specialities)
        {
            if(specialities == null)
            {
                throw new ArgumentNullException("specialities");
            }

            var list = new List<IOrder>();

            var orderDetailService = new OrderDetailService();
            var orderDetails = orderDetailService.GetOrderDetails(specialities);

            var ordersId = orderDetails.Select(o => o.OrderId).Distinct();

            foreach(var orderId in ordersId)
            {
                list.Add(GetOrder(orderId));
            }

            list = list.OrderBy(o => o.OrderDate).ThenBy(o => o.OrderTime).ToList();

            return list;
        }
    }
}