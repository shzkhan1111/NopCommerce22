using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Customers;
using Nop.Services.Localization;
using Nop.Web.Areas.Admin.Models.CustomersTiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nop.Services.Security;
using Nop.Web.Areas.Admin.Factories;

namespace Nop.Web.Areas.Admin.Controllers
{
    public class CustomersTierController : BaseAdminController
    {

        #region Fields

        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        //private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;
        private readonly ICustomerTierService _customerTierService;
        private readonly IPermissionService _permissionService;
        private readonly ICustomerTierModelFactory _customerTierModelFactory;

        #endregion

        #region Ctor

        public CustomersTierController(ICustomerTierService customerTierService,
            ICustomerService customerService,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            ICustomerTierModelFactory customerTierModelFactory,
            IWorkContext workContext)
        {
            _customerTierService = customerTierService;
            _customerService = customerService;
            _localizationService = localizationService;
            _workContext = workContext;
            _permissionService = permissionService;
            _customerTierModelFactory = customerTierModelFactory;
        }

        #endregion
        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        //public virtual async Task<IActionResult> List()
        public virtual IActionResult List()
        {
            var model = new CustomerTierSearchModel();
            return View(model);
        }

        [HttpPost]
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<IActionResult> List(CustomerTierSearchModel searchModel)
        {
            var model = await _customerTierService.GetAllCustomerTierList();
            //var model = await _customerTierModelFactory.PrepareCustomerTierSearchModelAsync(searchModel);

            return Json(model);
        }
    }
}
