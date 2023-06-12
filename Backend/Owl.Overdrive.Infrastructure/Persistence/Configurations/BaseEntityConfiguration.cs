using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Owl.Overdrive.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Owl.Overdrive.Infrastructure.Persistence.Configurations
{
    public abstract class BaseEntityConfiguration
    {
        public BaseEntityConfiguration()
        {
            
        }

        public void ConfigurationBase<TEntity>(EntityTypeBuilder<TEntity> entity) where TEntity: BaseEntity
        {
            // Identifier
            entity.HasKey(b => b.Id);
            
            // Created
            entity.Property(e => e.Created)
                .HasColumnType("datetime2(7)")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Last Updated
            entity.Property(e => e.LastUpdated)
                .HasColumnType("datetime2(7)")
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

            // Created by 
            entity.HasOne(e => e.CreatedBy)
                .WithMany()
                .HasForeignKey(e => e.CreatedById)
                .OnDelete(DeleteBehavior.Restrict);

            // Last updated by 
            entity.HasOne(e => e.LastUpdatedBy)
                .WithMany()
                .HasForeignKey(e => e.LastUpdatedById)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
