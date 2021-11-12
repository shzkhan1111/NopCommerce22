using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Web.Areas.Admin.Models.CustomersTiers
{
    public partial record CustomersTierModel : BaseNopEntityModel , IStoreMappingSupportedModel
    {
        #region Ctor
        public CustomersTierModel()
        {
            AvailableLanguages = new List<SelectListItem>();
            AvailableStores = new List<SelectListItem>();
            SelectedStoreIds = new List<int>();
        }

        #endregion
       

        //public OrderByEnum OrderBy { get; set; }
        #region Properties
        public int DisplayOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<SelectListItem> AvailableLanguages { get; set; }
        public IList<SelectListItem> AvailableStores { get; set; }
        public IList<int> SelectedStoreIds { get; set; }
        [NopResourceDisplayName("Admin.ContentManagement.Polls.Fields.StartDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? StartDateUtc { get; set; }

        [NopResourceDisplayName("Admin.ContentManagement.Polls.Fields.EndDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? EndDateUtc { get; set; }
        public string LanguageName { get; set; }

        #endregion

    }
}
