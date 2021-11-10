using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.CustomersTier;
using Nop.Data.Extensions;


namespace Nop.Data.Mapping.Builders.CustomersTier
{
    public class CustomerTierBuilder : NopEntityBuilder<CustomerTier>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(CustomerTier.Name)).AsString(int.MaxValue).NotNullable();

            //.WithColumn(nameof(CustomerTier.Description)).AsInt32().ForeignKey<Poll>();
        }
    }
}
