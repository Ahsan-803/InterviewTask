using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebApi.Models
{
    public class tblOrderMaster
    {
        [Key]
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderedDate { get; set; } = DateTime.Now;
        [Column(TypeName = "decimal(18, 2)")]
        public float? OrderedAmount { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        // Navigation property for one-to-many relationship with tblOrderDetails
        public virtual ICollection<tblOrderDetails>? OrderDetails { get; set; }
    }
}
