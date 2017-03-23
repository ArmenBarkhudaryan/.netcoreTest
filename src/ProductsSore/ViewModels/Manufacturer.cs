using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsStore.ViewModel
{
    public class Manufacturer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public Manufacturer()
        { 

        }
        public Manufacturer(int ID, string Name = null)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
}
