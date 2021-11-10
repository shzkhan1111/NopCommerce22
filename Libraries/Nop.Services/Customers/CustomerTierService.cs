using Nop.Core;
using Nop.Core.Domain.CustomersTier;
using Nop.Data;
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

        #endregion

        #region ctor
        public CustomerTierService(
            IRepository<CustomerTier> customerTierRepository
            )
        {
            _customerTierRepository = customerTierRepository;
        }
        #endregion

        #region Methods
        public virtual async Task<IPagedList<CustomerTier>> GetAllCustomerTierList(int languageId = 0, bool showHidden = false,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _customerTierRepository.Table;
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

        public virtual async Task<CustomerTier> GetPollAnswerByIdAsync(int customerTierId)
        {
            return await _customerTierRepository.GetByIdAsync(customerTierId, cache => default);
        }

        #endregion
    }
}
