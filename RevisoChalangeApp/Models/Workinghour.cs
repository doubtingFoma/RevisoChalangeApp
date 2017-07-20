namespace RevisoChalangeApp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("reviso.workinghours")]
    public partial class Workinghour
    {
        public int Id { get; set; }

        public int PId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime? StartDT { get; set; }

        public DateTime? EndDT { get; set; }

        public virtual Activeproject Activeproject { get; set; }
    }
}
