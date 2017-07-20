namespace RevisoChalangeApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reviso.activeprojects")]
    public partial class Activeproject
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activeproject()
        {
            Workinghours = new HashSet<Workinghour>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string PName { get; set; }

        [Required]
        [StringLength(15)]
        public string AuthorName { get; set; }

        [Required]
        [StringLength(15)]
        public string CustomerName { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Workinghour> Workinghours { get; set; }
    }
}
