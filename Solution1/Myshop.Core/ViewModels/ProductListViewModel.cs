using Myshop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.Core.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductSection> ProductSections{ get; set; }
    }
}
