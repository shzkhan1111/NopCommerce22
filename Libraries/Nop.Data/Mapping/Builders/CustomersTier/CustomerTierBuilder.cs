using System.Data;
using FluentMigrator.Builders.Create.Table;
using Nop.Core.Domain.Common;
using Nop.Core.Domain.Customers;
using Nop.Core.Domain.CustomersTier;
using Nop.Data.Extensions;
using Nop.Core.Domain.Localization;


namespace Nop.Data.Mapping.Builders.CustomersTier
{
    public class CustomerTierBuilder : NopEntityBuilder<CustomerTier>
    {
        public override void MapEntity(CreateTableExpressionBuilder table)
        {
            table
                .WithColumn(nameof(CustomerTier.Name)).AsString(int.MaxValue).NotNullable()
                .WithColumn(nameof(CustomerTier.DisplayOrder)).AsString(1000).Nullable()
                    .WithColumn(nameof(CustomerTier.Description)).AsString(1000).Nullable()
                    .WithColumn(nameof(CustomerTier.LimitedToStores)).AsString(1000).Nullable()
                    .WithColumn(nameof(CustomerTier.StartDateUtc)).AsString(400).Nullable()
                    .WithColumn(nameof(CustomerTier.EndDateUtc)).AsString(400).Nullable()
                    .WithColumn(nameof(CustomerTier.SystemKeyword)).AsString(400).Nullable()
                     .WithColumn(nameof(CustomerTier.LanguageId)).AsInt32().ForeignKey<Language>();

            //.WithColumn(nameof(CustomerTier.Description)).AsInt32().ForeignKey<Poll>();
        }
    }
}
