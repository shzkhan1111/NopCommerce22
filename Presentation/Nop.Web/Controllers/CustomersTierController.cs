using Microsoft.AspNetCore.Mvc;
using Nop.Core;
using Nop.Services.Customers;
using Nop.Services.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//this is not in admin file 
namespace Nop.Web.Controllers
{
    public class CustomersTierController : BasePublicController
    {
        #region Fields

        private readonly ICustomerService _customerService;
        private readonly ILocalizationService _localizationService;
        //private readonly IStoreMappingService _storeMappingService;
        private readonly IWorkContext _workContext;
        private readonly ICustomerTierService _customerTierService;

        #endregion

        #region Ctor

        public CustomersTierController(ICustomerTierService customerTierService,
            ICustomerService customerService,
            ILocalizationService localizationService,
            IWorkContext workContext)
        {
            _customerTierService = customerTierService;
            _customerService = customerService;
            _localizationService = localizationService;
            _workContext = workContext;
        }

        #endregion

        public IActionResult Index()
        {
            return View();
        }
    }
}
