using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart_Service_BLL
{
    public class Cart
    {
        public Cart()
        {
            Items = new List<Item>();
        }
        public Guid Id { get; set; }

        public List<Item> Items { get; set; }
    }
}
