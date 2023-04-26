using CleverHiveDiary.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Infrastructure.Data.Configuration
{
    internal class StatusConfiguration : IEntityTypeConfiguration<StatusHive>
    {
        public void Configure(EntityTypeBuilder<StatusHive> builder)
        {
            builder.HasData(CreateStatusOptions());
        }

        private List<StatusHive> CreateStatusOptions()
        {
            List<StatusHive> statuses = new List<StatusHive>()
            {
                new StatusHive()
                {
                    Id = 1,
                    Name = "Активно"
                },

                new StatusHive()
                {
                    Id = 2,
                    Name = "Неактивно"
                },
             };

            return statuses;
        }

    }
}
