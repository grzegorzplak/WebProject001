using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebProject001.Models
{
    [Table("WebProject001_Expenditures")]
    public class Expenditure
    {
        public int Id { get; set; }
        [DisplayName("Expenditure Date")]
        public DateOnly ExpenditureDate { get; set; }
        [DisplayName("Expenditure Name")]
        public string ExpenditureName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(18,3)")]
        public decimal Quantity { get; set; }
        public string? Description { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; }
        [DisplayName("Shop")]
        public int ShopId { get; set; }
        [DisplayName("Payment Method")]
        public int PaymentMethodId { get; set; }
        public virtual Category? Category { get; set; }
        public virtual Shop? Shop { get; set; }
        public virtual PaymentMethod? PaymentMethod { get; set; }
    }
}
