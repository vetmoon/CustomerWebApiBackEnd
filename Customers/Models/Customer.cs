using System.ComponentModel.DataAnnotations;

namespace Customers.Models
{
    public class Customer
    {
        [Key] 
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string MobileNo { get; set; }
        public string EmailID { get; set; }

    }
}
