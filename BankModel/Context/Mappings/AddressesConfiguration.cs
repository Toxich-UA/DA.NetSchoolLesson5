using System.Data.Entity.ModelConfiguration;
using Lesson4.Model;

namespace BankModel.Mappinds
{
    internal class AddressesConfiguration : EntityTypeConfiguration<Addresses>
    {
        public AddressesConfiguration()
        {
            ToTable("Address", "dbo");
            HasKey(x => x.ClientId);

            Property(x => x.ClientId)
                .HasColumnName(@"ClientID")
                .HasColumnType("int")
                .IsRequired();
            Property(x => x.Country)
                .HasColumnName(@"Country")
                .HasColumnType("nvarchar")
                .IsOptional()
                .HasMaxLength(50);
            Property(x => x.State)
                .HasColumnName(@"State")
                .HasColumnType("nvarchar")
                .IsOptional()
                .HasMaxLength(50);
            Property(x => x.City)
                .HasColumnName(@"City")
                .HasColumnType("nvarchar")
                .IsOptional()
                .HasMaxLength(50);
            Property(x => x.Address)
                .HasColumnName(@"Address")
                .HasColumnType("nvarchar")
                .IsOptional()
                .HasMaxLength(120);

            
        }
    }
}