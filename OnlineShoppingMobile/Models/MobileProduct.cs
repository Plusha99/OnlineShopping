using System.ComponentModel.DataAnnotations;

namespace OnlineShoppingMobile.Models
{
    public class MobileProduct
    {
        [Key]
        public int Id { get; set; }
        public string ProductName { get; set; }
    }
}
