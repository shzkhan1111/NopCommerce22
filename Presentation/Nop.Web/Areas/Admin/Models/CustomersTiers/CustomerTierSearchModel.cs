using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.CustomersTiers
{
    public partial record CustomerTierSearchModel : BaseSearchModel
    {
        public CustomerTierSearchModel()
        {
           
        }

        [NopResourceDisplayName("Admin.ContentManagement.Polls.Fields.Language")]
        public string LanguageName { get; set; }
        public int SearchStoreId { get; set; }

    }
}
