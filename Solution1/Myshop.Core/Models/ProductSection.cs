using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myshop.Core.Models
{

    //I built a section model for our product
    public class ProductSection : BaseEntity
    {
        //BASEENTITY 早已包含ID 所以删除id 和下面的function
      //  public string Id { get; set; }
        public string Section { get; set; }


    //    public ProductSection()
     //   { this.Id = Guid.NewGuid().ToString(); }
    }
}
