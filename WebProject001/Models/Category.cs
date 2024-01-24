using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject001.Models
{
    [Table("WebProject001_Categories")]
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Category name")]
        public string CategoryName { get; set; }
        public virtual ICollection<Expenditure>? Expenditures { get; set; }
    }
}
