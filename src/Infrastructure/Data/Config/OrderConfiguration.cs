using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Config
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(x => x.BuyerId).IsRequired();

            builder.OwnsOne<Address>(x => x.ShipToAddress, o =>
            {
                o.WithOwner();
                o.Property(y => y.Street).IsRequired().HasMaxLength(180);
                o.Property(y => y.City).IsRequired().HasMaxLength(100);
                o.Property(y => y.State).HasMaxLength(60);
                o.Property(y => y.Country).IsRequired().HasMaxLength(90);
                o.Property(y => y.ZipCode).IsRequired().HasMaxLength(18);
            });

            builder.Navigation(x => x.ShipToAddress).IsRequired();
        }
    }
}
