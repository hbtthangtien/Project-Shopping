using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.DatabaseContext.ConfigModel
{
    public class SearchHistoryConfiguration : IEntityTypeConfiguration<SearchHistory>
    {
        public void Configure(EntityTypeBuilder<SearchHistory> builder)
        {
            throw new NotImplementedException();
        }
    }
}
