using System.ComponentModel.DataAnnotations;

namespace WebProject001.ViewModels
{
    public class ExpenditureByPaymentMethod
    {
        public string PaymentMethodName { get; set; }
        public decimal Total { get; set; }
    }
}
