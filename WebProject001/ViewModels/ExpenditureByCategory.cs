using System.ComponentModel.DataAnnotations;

namespace WebProject001.ViewModels
{
    public class ExpenditureByCategory
    {
        public string CategoryName { get; set; }
        public decimal Total { get; set; }
    }
}
