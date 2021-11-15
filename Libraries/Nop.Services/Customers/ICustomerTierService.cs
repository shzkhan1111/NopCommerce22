using Nop.Core;
using Nop.Core.Domain.CustomersTier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Customers
{
    public interface ICustomerTierService
    {
        //Task<IPagedList<CustomerTier>> GetAllCustomerTierList(int languageId = 0, bool showHidden = false,
        //    int pageIndex = 0, int pageSize = int.MaxValue);
        Task<IPagedList<CustomerTier>> GetAllCustomerTierList(int storeId, int languageId = 0, bool showHidden = false,
            bool loadShownOnHomepageOnly = false, string systemKeyword = null,
            int pageIndex = 0, int pageSize = int.MaxValue);

        Task DeleteCustomerTierAsync(CustomerTier customerTier);
        Task InsertCustomerTierAsync(CustomerTier customerTier);
        Task UpdateCustomerTierAsync(CustomerTier customerTier);

        Task<CustomerTier> GetCustomerTierByIdAsync(int customerTierId);

        Task<IPagedList<CustomerTier>> GetAllCustomerTierAsync(
           int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
