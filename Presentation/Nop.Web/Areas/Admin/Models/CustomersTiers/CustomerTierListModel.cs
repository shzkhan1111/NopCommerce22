using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Web.Framework.Models;


namespace Nop.Web.Areas.Admin.Models.CustomersTiers
{
    public partial record CustomerTierListModel : BasePagedListModel<CustomersTierModel>
    {
    }
}
