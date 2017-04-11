namespace Spa_salon.DAL.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clients
    {
        public Clients()
        {
            Orders = new HashSet<Orders>();
        }

        [Key]
        public int client_id { get; set; }

        [Required]
        [StringLength(20)]
        public string last_name { get; set; }

        [Required]
        [StringLength(20)]
        public string first_name { get; set; }

        public long phone_number { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
