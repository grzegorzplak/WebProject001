using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject001.Models
{
    [Table("WebProject001_Shops")]
    public class Shop
    {
        public int Id { get; set; }
        [DisplayName("Shop Name")]
        public string ShopName { get; set; }
        [DisplayName("Address")]
        public string AddressLine { get; set; }
        public string City { get; set; }
        public virtual ICollection<Expenditure>? Expenditures { get; set; }
    }
}
