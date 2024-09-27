using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebApi.Models
{
    public class tblOrderDetails
    {
        [Key]
        public int OrderedDetailsId { get; set; }

        // Foreign key for tblOrderMaster
        public int? OrderId { get; set; }
        // Foreign key for tblItem
        public int? ItemId { get; set; }

        public int? Quantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public float? Cost { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? EditBy { get; set; }
        public DateTime? EditDate { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        // Navigation property for tblItem
        [ForeignKey("ItemId")]
        public virtual tblItem? Item { get; set; }
        // Navigation property for tblOrderMaster
        [ForeignKey("OrderId")]
        public virtual tblOrderMaster? OrderMaster { get; set; }
    }
}
