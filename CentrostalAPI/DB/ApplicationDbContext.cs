using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CentrostalAPI.DB.Models;
using CentrostalAPI.DB.Repositories;
using CentrostalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CentrostalAPI.DB {
    public class ApplicationDbContext : DbContext {
        public DbSet<Item> items { get; set; }
        public DbSet<ItemTemplate> itemTemplates { get; set; }
        public DbSet<ItemTemplateCurrent> itemTemplateCurrents { get; set; }
        public DbSet<ItemTemplateSteelType> itemTemplateSteelTypes { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<OrderItem> orderItems { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<SteelType> steelTypes { get; set; }
        public DbSet<User> users { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            var x = modelBuilder.Entity<Order>();

            modelBuilder.Entity<Order>()
                    .Property(a => a.executedDate)
                    .HasConversion(v => v,
                        v => v == null ? null : new DateTime(v.Value.Ticks, DateTimeKind.Utc));
            modelBuilder.Entity<Order>()
                    .Property(a => a.lastEditedDate)
                    .HasConversion(v => v,
                        v => v == null ? null : new DateTime(v.Value.Ticks, DateTimeKind.Utc));
            modelBuilder.Entity<Order>()
                    .Property(a => a.createdDate)
                    .HasConversion(v => v,
                        v => new DateTime(v.Ticks, DateTimeKind.Utc));

            /////
            ///// relations
            /////
            ///
            modelBuilder.Entity<Item>()
                .HasMany(item => item.orderItems)
                .WithOne(orderItem => orderItem.item)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemTemplate>()
                .HasMany(itemTemplate => itemTemplate.steelTypes)
                .WithOne(steelType => steelType.itemTemplate)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ItemTemplate>()
                .HasMany(itemTemplate => itemTemplate.items)
                .WithOne(item => item.itemTemplate)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ItemTemplate>()
                .HasMany(itemTemplate => itemTemplate.currents)
                .WithOne(current => current.itemTemplate)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .HasMany(order => order.orderItems)
                .WithOne(orderItem => orderItem.order)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Status>()
                .HasMany(status => status.orders)
                .WithOne(order => order.status)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SteelType>()
                .HasMany(steelType => steelType.itemTemplateSteelTypes)
                .WithOne(itemTemplateSteelType => itemTemplateSteelType.steelType)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<SteelType>()
                .HasMany(steelType => steelType.items)
                .WithOne(item => item.steelType)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(user => user.orders)
                .WithOne(order => order.orderingUser)
                .OnDelete(DeleteBehavior.Restrict);

            StatusRepository.seed(modelBuilder.Entity<Status>());
            SteelTypeRepository.seed(modelBuilder.Entity<SteelType>());
        }
    }
}
