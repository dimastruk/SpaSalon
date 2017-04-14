namespace Spa_salon.DAL.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Workers_schedule
    {
        [Key]
        public int workers_schedule_id { get; set; }

        public int worker_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateValue { get; set; }

        public TimeSpan start_time { get; set; }

        public TimeSpan end_time { get; set; }

        public bool isActual { get; set; }

        public virtual Calendar Calendar { get; set; }

        public virtual Workers Workers { get; set; }
    }
}