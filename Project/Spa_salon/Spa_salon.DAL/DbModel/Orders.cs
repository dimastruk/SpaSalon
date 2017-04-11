namespace Spa_salon.DAL.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Orders
    {
        public Orders()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        public int order_id { get; set; }

        public int client_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime order_date { get; set; }

        public TimeSpan order_time { get; set; }

        public bool isActual { get; set; }

        public int? total_price { get; set; }

        public virtual Clients Clients { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
