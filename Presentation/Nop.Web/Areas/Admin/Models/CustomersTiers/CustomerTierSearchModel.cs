using Nop.Web.Framework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Nop.Web.Areas.Admin.Models.CustomersTiers
{
    public partial record CustomerTierSearchModel : BaseSearchModel
    {
        public CustomerTierSearchModel()
        {
           
        }

        public int SearchStoreId { get; set; }

    }
}
