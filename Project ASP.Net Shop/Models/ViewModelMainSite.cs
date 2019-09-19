using System.Collections.Generic;

namespace Project_ASP.Net_Shop.Models
{
    public class ViewModelMainSite
    {
        public IEnumerable<Products> Prod { get; set; }
        public Contact Cont { get; set; }

        public IEnumerable<LaptopXML> Laptop { get; set; }
        public KeyAndMouseXML KaM { get; set; }
    }
}