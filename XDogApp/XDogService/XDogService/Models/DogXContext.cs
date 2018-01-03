
using Microsoft.Azure.Mobile.Server.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace XDogService.Models
{
    public class DogXContext : DbContext
    {
        public DogXContext() : base("name=MS_ConnectionString") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Add(new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                                         "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }


        // tables
        public DbSet<Dog> Dogs { get; set; }
        public DbSet<DogOwner> DogOwners { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Business> Businesses { get; set; }
    }
}
