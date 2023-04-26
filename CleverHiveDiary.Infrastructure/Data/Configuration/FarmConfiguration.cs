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
    internal class FarmConfiguration : IEntityTypeConfiguration<Farm>
    {
        public void Configure(EntityTypeBuilder<Farm> builder)
        {
            builder.HasData(CreateFarm());
        }

        private Farm CreateFarm()
        {
            var farm = new Farm()
            {
                Id = 1,
                Name = "Ферма1",
                Location = "Раковски",
                Capacity = 5,
                UserId = "u1"
            };

            return farm;
        }
    }
}
