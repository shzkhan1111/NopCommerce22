using Nop.Web.Framework.Models;

namespace Nop.Web.Areas.Admin.Models.CustomersTiers
{
    public partial record CustomersTierModel : BaseNopEntityModel
    {
        #region Ctor
        public CustomersTierModel()
        {

        }

        #endregion
        #region Properties

        //public OrderByEnum OrderBy { get; set; }
        #region Properties
        public int DisplayOrder { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        #endregion
        #endregion
    }
}
