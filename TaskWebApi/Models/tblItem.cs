using System.ComponentModel.DataAnnotations;

namespace TaskWebApi.Models
{
    public class tblItem
    {
        [Key]
        public int ItemId { get; set; }
        public string? ItemDescription { get; set; }
        public float? ItemCost { get; set; }
        public int? CreatedBy {  get; set; }
        public DateTime? CreatedDate {  get; set; }
        public int? EditBy {  get; set; }
        public DateTime? EditDate {  get; set; }
        public bool? IsActive {  get; set; }
        public bool? IsDeleted { get; set;}
    }
}
