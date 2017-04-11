namespace Spa_salon.DAL.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Positions
    {
        public Positions()
        {
            Workers = new HashSet<Workers>();
        }

        [Key]
        public int position_id { get; set; }

        [Required]
        [StringLength(20)]
        public string position_name { get; set; }

        public virtual ICollection<Workers> Workers { get; set; }
    }
}
