namespace asp_valid2.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employee")]
    public partial class Employee
    { 
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]
        public string FamilyName { get; set; }

        public int? Age { get; set; }

        public int? DepartmentId { get; set; }

        public int? LanguageId { get; set; }

        public virtual Department Department { get; set; }

        public virtual Language Language { get; set; }
    }
}
