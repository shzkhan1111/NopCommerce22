using System;
using System.Linq;
using System.Threading.Tasks;
using Nop.Core.Domain.Catalog;
using Nop.Core.Domain.CustomersTier;
using Nop.Services.Customers;
using Nop.Services.Helpers;
using Nop.Services.Localization;
using Nop.Services.Polls;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Web.Areas.Admin.Models.CustomersTiers;
using Nop.Web.Framework.Extensions;
using Nop.Web.Framework.Factories;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Web.Areas.Admin.Factories
{
    public partial class CustomerTierModelFactory : ICustomerTierModelFactory
    {
        private readonly ICustomerTierService _customerTierService;
        private readonly IBaseAdminModelFactory _baseAdminModelFactory;

        public CustomerTierModelFactory(
            ICustomerTierService customerTierService,
            IBaseAdminModelFactory baseAdminModelFactory
            )
        {
            _customerTierService = customerTierService;
            _baseAdminModelFactory = baseAdminModelFactory;
        }

        //public virtual  Task<CustomerTierListModel> PrepareCustomerTierSearchModelAsync(CustomerTierSearchModel searchModel)
        //{
        //    if (searchModel == null)
        //        throw new ArgumentNullException(nameof(searchModel));

        //    //await _baseAdminModelFactory.PrepareStoresAsync(searchModel.AvailableStores);

        //    //searchModel.HideStoresList = _catalogSetti
        //    //ngs.IgnoreStoreLimitations || searchModel.AvailableStores.SelectionIsNotPossible();

        //    //prepare page parameters
        //    searchModel.SetGridPageSize();

        //    return searchModel;
        //    //get customer Tier 
        //    //var custTier = await _customerTierService.GetAllCustomerTierList();


        //    ////prepare List
        //    //var model =  new CustomerTierListModel().PrepareToGrid(searchModel, custTier, () =>
        //    //{
        //    //    return custTier.Select(custTier =>
        //    //    {
        //    //        //fill in model values from the entity
        //    //        var customerTierModel = custTier.ToModel<CustomersTierModel>();

        //    //        //convert dates to the user time
        //    //        //if (custTier.StartDateUtc.HasValue)
        //    //        //    custTier.StartDateUtc = await _dateTimeHelper.ConvertToUserTimeAsync(custTier.StartDateUtc.Value, DateTimeKind.Utc);
        //    //        //if (custTier.EndDateUtc.HasValue)
        //    //        //    custTier.EndDateUtc = await _dateTimeHelper.ConvertToUserTimeAsync(custTier.EndDateUtc.Value, DateTimeKind.Utc);

        //    //        //fill in additional values (not existing in the entity)
        //    //        //CustomersTierModel.LanguageName = (await _languageService.GetLanguageByIdAsync(poll.LanguageId))?.Name;

        //    //        return customerTierModel;
        //    //    });
        //    //});

        //    ////var custTier = await _customerTierService.GetAllCustomerTierList(int languageId = 0, bool showHidden = false,
        //    ////int pageIndex = 0, int pageSize = int.MaxValue);
        //    ////= await new CustomersTierModel().PrepareToGridAsync(searchModel , )

        //    //return model;

        //}
    }
}
