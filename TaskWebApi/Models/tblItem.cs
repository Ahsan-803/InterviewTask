using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskWebApi.Models
{
    public class tblItem
    {
        [Key]
        public int ItemId { get; set; }
        public string? ItemDescription { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public float? ItemCost { get; set; }
        public int? CreatedBy {  get; set; }
        public DateTime? CreatedDate {  get; set; }
        public int? EditBy {  get; set; }
        public DateTime? EditDate {  get; set; }
        public bool? IsActive {  get; set; }
        public bool? IsDeleted { get; set;}

        // Navigation property for one-to-many relationship with tblOrderDetails
        public virtual ICollection<tblOrderDetails>? OrderDetails { get; set; }
    }
}
