using Nop.Core;
using Nop.Core.Domain.CustomersTier;
using Nop.Data;
using Nop.Services.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Services.Customers
{
    public class CustomerTierService : ICustomerTierService
    {
        #region Fields
        private readonly IRepository<CustomerTier> _customerTierRepository;
        private readonly IStoreMappingService _storeMappingService;

        #endregion

        #region ctor
        public CustomerTierService(
            IRepository<CustomerTier> customerTierRepository,
            IStoreMappingService storeMappingService
            )
        {
            _customerTierRepository = customerTierRepository;
            _storeMappingService = storeMappingService;
        }
        #endregion

        #region Methods

        //public virtual async Task<IPagedList<CustomerTier>> GetAllCustomerTierList(int languageId = 0, bool showHidden = false,
        //    int pageIndex = 0, int pageSize = int.MaxValue)
        //{
        //    var query = _customerTierRepository.Table;
        //    return await query.ToPagedListAsync(pageIndex, pageSize);
        //}

        public virtual async Task<IPagedList<CustomerTier>> GetAllCustomerTierAsync(
           int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _customerTierRepository.Table;
            //query = await _storeMappingService.ApplyStoreMapping(query, storeId);

            query = query.OrderBy(tier => tier.DisplayOrder).ThenBy(tier => tier.Id);
            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        public virtual async Task<IPagedList<CustomerTier>> GetAllCustomerTierList(int storeId, int languageId = 0, bool showHidden = false,
            bool loadShownOnHomepageOnly = false, string systemKeyword = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _customerTierRepository.Table;
            query = await _storeMappingService.ApplyStoreMapping(query, storeId);

            query = query.OrderBy(tier => tier.DisplayOrder).ThenBy(tier => tier.Id);
            return await query.ToPagedListAsync(pageIndex, pageSize);
        }

        public virtual async Task DeleteCustomerTierAsync(CustomerTier customerTier)
        {
            await _customerTierRepository.DeleteAsync(customerTier);
        }

        public virtual async Task InsertCustomerTierAsync(CustomerTier customerTier)
        {
            await _customerTierRepository.InsertAsync(customerTier);
        }

        public virtual async Task UpdateCustomerTierAsync(CustomerTier customerTier)
        {
            await _customerTierRepository.UpdateAsync(customerTier);
        }

        public virtual async Task<CustomerTier> GetCustomerTierByIdAsync(int customerTierId)
        {
            return await _customerTierRepository.GetByIdAsync(customerTierId, cache => default);
        }

        #endregion
    }
}
