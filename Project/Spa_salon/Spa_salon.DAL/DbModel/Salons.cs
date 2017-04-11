namespace Spa_salon.DAL.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Salons
    {
        public Salons()
        {
            Workers = new HashSet<Workers>();
        }

        [Key]
        public int salon_id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string address { get; set; }

        public virtual ICollection<Workers> Workers { get; set; }
    }
}
