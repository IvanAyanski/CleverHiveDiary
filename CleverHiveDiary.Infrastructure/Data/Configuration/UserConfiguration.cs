using CleverHiveDiary.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleverHiveDiary.Infrastructure.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasData(CreateUsers());
        }
        private List<ApplicationUser> CreateUsers()
        {
            var farmers = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();

            var user = new ApplicationUser()
            {
                Id = "u1",
                UserName = "UserOne",
                NormalizedUserName = "userone",
                Email = "user@mail.com",
                NormalizedEmail = "user@mail.com",
                FarmId =1
            };

            user.PasswordHash =
                 hasher.HashPassword(user, "Uu12345");

            farmers.Add(user);
            return farmers;
        }
    }
}
