namespace Spa_salon.DAL.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Specialities
    {
        public Specialities()
        {
            OrderDetails = new HashSet<OrderDetails>();
        }

        [Key]
        public int speciality_id { get; set; }

        public int worker_id { get; set; }

        public int service_id { get; set; }

        public int commisions { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual Services Services { get; set; }

        public virtual Workers Workers { get; set; }
    }
}
