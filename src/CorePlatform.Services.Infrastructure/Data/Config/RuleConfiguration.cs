using CorePlatform.Services.Core.Rule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorePlatform.Services.Infrastructure.Data.Config
{
    public class RuleEntityConfiguration : IEntityTypeConfiguration<RulesLibrary>
    {
        public void Configure(EntityTypeBuilder<RulesLibrary> builder)
        {
            builder.Property(p => p.RuleName)
            .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
            .IsRequired();

            builder.Property(x => x.Status)
              .HasConversion(
                  x => x.Value,
                  x => RuleStatus.FromValue(x));
        }
    }
}
