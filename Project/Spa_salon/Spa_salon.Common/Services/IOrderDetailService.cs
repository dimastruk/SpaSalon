using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spa_salon.Common.Services
{
    using DAL.DbModel;
    using Models;
    using OrderDetails = DAL.DbModel.OrderDetails;
    public interface IOrderDetailService
    {
        IOrderDetail GetOrderDetail(OrderDetails orderDetail);
        ICollection<IOrderDetail> GetOrderDetails(int orderId);
        ICollection<IOrderDetail> GetOrderDetails(ICollection<ISpeciality> specialities);
    }

    public class OrderDetailService : DbDependentService, IOrderDetailService
    {
        public IOrderDetail GetOrderDetail(OrderDetails orderDetail)
        {
            if(orderDetail == null)
            {
                throw new ArgumentNullException("orderDetail");
            }

            var specialitiesService = new SpecialitiesService();
            var speciality = specialitiesService.GetSpeciality(DbService.Context.Specialities.FirstOrDefault(s => s.speciality_id == orderDetail.speciality_id));

            return new OrderDetail(orderDetail.orderDetails_id, speciality, orderDetail.order_id);
        }

        public ICollection<IOrderDetail> GetOrderDetails(ICollection<ISpeciality> specialities)
        {
            if(specialities == null)
            {
                throw new ArgumentNullException("specialities");
            }

            var list = new List<IOrderDetail>();

            foreach(var speciality in specialities)
            {
                var orderDetails = DbService.Context.OrderDetails.Where(o => o.speciality_id == speciality.SpecialityId);
                foreach(var orderDetail in orderDetails)
                {
                    list.Add(GetOrderDetail(orderDetail));
                }
            }

            return list;
        }

        public ICollection<IOrderDetail> GetOrderDetails(int orderId)
        {
            var orderDetails = DbService.Context.OrderDetails.Where(o => o.order_id == orderId);

            var list = new List<IOrderDetail>();

            foreach(var orderDetail in orderDetails)
            {
                list.Add(GetOrderDetail(orderDetail));
            }

            return list;
        }
    }
}