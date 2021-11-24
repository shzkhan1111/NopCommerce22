using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Core;
using Nop.Core.Domain.Stores;
using Nop.Services.Stores;
using Nop.Web.Framework.Models;

namespace Nop.Web.Framework.Factories
{
    /// <summary>
    /// Represents the base store mapping supported model factory implementation
    /// </summary>
    public partial class StoreMappingSupportedModelFactory : IStoreMappingSupportedModelFactory
    {
        #region Fields
        
        private readonly IStoreMappingService _storeMappingService;
        private readonly IStoreService _storeService;
        private readonly IStoreContext _storeContext;

        #endregion

        #region Ctor

        public StoreMappingSupportedModelFactory(IStoreMappingService storeMappingService,
            IStoreService storeService , IStoreContext storeContext )
        {
            _storeMappingService = storeMappingService;
            _storeService = storeService;
            _storeContext = storeContext;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Prepare selected and all available stores for the passed model
        /// </summary>
        /// <typeparam name="TModel">Store mapping supported model type</typeparam>
        /// <param name="model">Model</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task PrepareModelStoresAsync<TModel>(TModel model) where TModel : IStoreMappingSupportedModel
        {
            var storeId = (await _storeContext.GetCurrentStoreAsync()).Id;

            if (model == null)
                throw new ArgumentNullException(nameof(model));

            //prepare available stores
            var availableStores = await _storeService.GetAllStoresAsync();
            model.AvailableStores = availableStores.Select(store => new SelectListItem
            {
                Text = store.Name,
                Value = store.Id.ToString(),
                Selected = model.SelectedStoreIds.Contains(store.Id)
            }).Where(x => x.Value == storeId.ToString() || storeId == 1).ToList();
        }

        /// <summary>
        /// Prepare selected and all available stores for the passed model by store mappings
        /// </summary>
        /// <typeparam name="TModel">Store mapping supported model type</typeparam>
        /// <typeparam name="TEntity">Store mapping supported entity type</typeparam>
        /// <param name="model">Model</param>
        /// <param name="entity">Entity</param>
        /// <param name="ignoreStoreMappings">Whether to ignore existing store mappings</param>
        /// <returns>A task that represents the asynchronous operation</returns>
        public virtual async Task PrepareModelStoresAsyncAll<TModel, TEntity>(TModel model, TEntity entity, bool ignoreStoreMappings)
            where TModel : IStoreMappingSupportedModel where TEntity : BaseEntity, IStoreMappingSupported
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            //prepare stores with granted access
            if (!ignoreStoreMappings && entity != null)
                model.SelectedStoreIds = (await _storeMappingService.GetStoresIdsWithAccessAsync(entity)).ToList();

            await PrepareModelStoresAsync(model);
        }
        public virtual async Task PrepareModelStoresAsync<TModel, TEntity>(TModel model, TEntity entity, bool ignoreStoreMappings)
            where TModel : IStoreMappingSupportedModel where TEntity : BaseEntity, IStoreMappingSupported
        {
            IList<int> storeIdArray = new List<int>();
            int storeId = 0;
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            //prepare stores with granted access
            if (!ignoreStoreMappings && entity != null)
            {
                storeId = (await _storeContext.GetCurrentStoreAsync()).Id;
                if (storeId == 1)
                {
                    model.SelectedStoreIds = (await _storeMappingService.GetStoresIdsWithAccessAsync(entity)).ToList();
                }
                else
                {
                    storeIdArray.Add(storeId);
                    model.SelectedStoreIds = storeIdArray;
                }

            }


            await PrepareModelStoresAsync(model);
        }


        #endregion
    }
}