using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.Data.APIContext.Models
{
    public partial class Bill
    {
        public Bill() 
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
