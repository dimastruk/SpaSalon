namespace Spa_salon.DAL.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderDetails
    {
        [Key]
        public int orderDetails_id { get; set; }

        public int order_id { get; set; }

        public int speciality_id { get; set; }

        public virtual Specialities Specialities { get; set; }

        public virtual Orders Orders { get; set; }
    }
}
