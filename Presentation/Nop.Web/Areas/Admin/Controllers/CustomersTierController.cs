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
using Nop.Web.Framework.Mvc.Filters;
using Nop.Web.Areas.Admin.Infrastructure.Mapper.Extensions;
using Nop.Core.Domain.CustomersTier;
using Nop.Services.Messages;

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
        private readonly INotificationService _notificationService;

        #endregion

        #region Ctor

        public CustomersTierController(ICustomerTierService customerTierService,
            ICustomerService customerService,
            ILocalizationService localizationService,
            INotificationService notificationService,
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
            _notificationService = notificationService;
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
            var model = await _customerTierModelFactory.GetAllCustomerTierList(searchModel);
            
            return Json(model);
        }

        public virtual async Task<IActionResult> Create()
        {
            //if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
            //    return AccessDeniedView();

            var model = await _customerTierModelFactory.PrepareCustomerTierModelAsync(new CustomersTierModel(), null);

            return View(model);

        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<IActionResult> Create(CustomersTierModel model, bool continueEditing)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            if (ModelState.IsValid)
            {
                var tier = model.ToEntity<CustomerTier>();
                await _customerTierService.InsertCustomerTierAsync(tier);

                ////save store mappings
                //await SaveStoreMappingsAsync(poll, model);

                //_notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.Polls.Added"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = tier.Id });
            }

            //prepare model
            model = await _customerTierModelFactory.PrepareCustomerTierModelAsync(model, null, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }


        public virtual async Task<IActionResult> Edit(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //try to get a poll with the specified id
            var tier = await _customerTierService.GetCustomerTierByIdAsync(id);
            if (tier == null)
                return RedirectToAction("List");

            //prepare model
            var model = await _customerTierModelFactory.PrepareCustomerTierModelAsync(null, tier);

            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<IActionResult> Edit(CustomersTierModel model, bool continueEditing)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //try to get a poll with the specified id
            var tier = await _customerTierService.GetCustomerTierByIdAsync(model.Id);
            if (tier == null)
                return RedirectToAction("List");

            if (ModelState.IsValid)
            {
                tier = model.ToEntity(tier);
                await _customerTierService.UpdateCustomerTierAsync(tier);

                //save store mappings
                //await SaveStoreMappingsAsync(tier, model);

                _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.Polls.Updated"));

                if (!continueEditing)
                    return RedirectToAction("List");

                return RedirectToAction("Edit", new { id = tier.Id });
            }

            //prepare model
            model = await _customerTierModelFactory.PrepareCustomerTierModelAsync(model, tier, true);

            //if we got this far, something failed, redisplay form
            return View(model);
        }

        [HttpPost]
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task<IActionResult> Delete(int id)
        {
            if (!await _permissionService.AuthorizeAsync(StandardPermissionProvider.ManagePolls))
                return AccessDeniedView();

            //try to get a poll with the specified id
            var tier = await _customerTierService.GetCustomerTierByIdAsync(id);
            if (tier == null)
                return RedirectToAction("List");

            await _customerTierService.DeleteCustomerTierAsync(tier);

            _notificationService.SuccessNotification(await _localizationService.GetResourceAsync("Admin.ContentManagement.Polls.Deleted"));

            return RedirectToAction("List");
        }
    }
}
