namespace Spa_salon.DAL.DbModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Workers
    {
        public Workers()
        {
            Specialities = new HashSet<Specialities>();
            Workers_schedule = new HashSet<Workers_schedule>();
        }

        [Key]
        public int worker_id { get; set; }

        [Required]
        [StringLength(20)]
        public string last_name { get; set; }

        [Required]
        [StringLength(20)]
        public string first_name { get; set; }

        [Required]
        [StringLength(20)]
        public string middle_name { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_of_birth { get; set; }

        [Required]
        [StringLength(9)]
        public string passport_number { get; set; }

        public int workbook_number { get; set; }

        public int medicalbook_number { get; set; }

        public long ID_number { get; set; }

        public long phone_number { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string address { get; set; }

        public int position_id { get; set; }

        public int salon_id { get; set; }

        [StringLength(100)]
        public string login_name { get; set; }

        [MaxLength(100)]
        public byte[] password_string { get; set; }

        public virtual Positions Positions { get; set; }

        public virtual Salons Salons { get; set; }

        public virtual ICollection<Specialities> Specialities { get; set; }

        public virtual ICollection<Workers_schedule> Workers_schedule { get; set; }
    }
}