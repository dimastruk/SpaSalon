namespace Spa_salon.DAL.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Calendar")]
    public partial class Calendar
    {
        public Calendar()
        {
            Workers_schedule = new HashSet<Workers_schedule>();
        }

        [Key]
        [Column(TypeName = "date")]
        public DateTime DateValue { get; set; }

        [Required]
        [StringLength(10)]
        public string DayName { get; set; }

        [Required]
        [StringLength(10)]
        public string MonthName { get; set; }

        [Required]
        [StringLength(60)]
        public string Date_Year { get; set; }

        public byte Date_Day { get; set; }

        public short DayOfTheYear { get; set; }

        public short Date_Month { get; set; }

        public byte Quarter { get; set; }

        public virtual ICollection<Workers_schedule> Workers_schedule { get; set; }
    }
}
