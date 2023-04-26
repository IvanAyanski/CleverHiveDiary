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
    internal class HiveConfiguration : IEntityTypeConfiguration<Hive>
    {
        public void Configure(EntityTypeBuilder<Hive> builder)
        {
            builder.HasData(CreateHive());
        }

        private Hive CreateHive()
        {
            var hive = new Hive()
            {
                Id = 1,
                Name = "HiveOne",
                StatusId = 1,
                Production = 5.1,
                FarmId = 1,
                Floors = 1,
                Discription=""

            };

            return hive;
        }
    }
}
