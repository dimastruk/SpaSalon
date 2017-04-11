namespace Spa_salon.DAL.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Services
    {
        public Services()
        {
            Specialities = new HashSet<Specialities>();
        }

        [Key]
        public int service_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string service_name { get; set; }

        public int service_price { get; set; }

        public virtual ICollection<Specialities> Specialities { get; set; }
    }
}
