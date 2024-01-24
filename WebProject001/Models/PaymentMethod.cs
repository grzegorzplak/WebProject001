using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject001.Models
{
    [Table("WebProject001_PaymentMethods")]
    public class PaymentMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Expenditure>? Expenditures { get; set; }
    }
}
