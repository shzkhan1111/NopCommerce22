using Nop.Core.Domain.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.CustomersTier
{
    public class CustomerTier : BaseEntity, IStoreMappingSupported
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int DisplayOrder { get; set; }

        public bool LimitedToStores { get; set; }

        /// <summary>
        /// Gets or sets the poll start date and time
        /// </summary>
        public DateTime? StartDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the poll end date and time
        /// </summary>
        public DateTime? EndDateUtc { get; set; }

        public string SystemKeyword { get; set; }

        public int LanguageId { get; set; }
    }
}
