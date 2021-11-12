using System.Collections;

namespace SalesWebMvc.Models.ViewModels
{
    public class SellerFormViewModel
    {

        public Seller Seller { get; set; }

        public ICollection Departments { get; set; }

    }
}
