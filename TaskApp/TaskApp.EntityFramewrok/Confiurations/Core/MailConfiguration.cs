using TaskApp.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskApp.EntityFramework
{
    public class MailConfiguration : IEntityTypeConfiguration<Mail>
    {
        public void Configure(EntityTypeBuilder<Mail> builder)
        {
            builder.HasOne(x => x.Trip)
                   .WithMany(x => x.Mails)
                   .HasForeignKey(x => x.TripId)
                   .IsRequired();
        }
    }
}
