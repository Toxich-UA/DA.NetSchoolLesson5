using System.Data.Entity.ModelConfiguration;
using Lesson4.Model;

namespace BankModel.Mappinds
{
    internal class CardConfiguration : EntityTypeConfiguration<Cards>
    {

        public CardConfiguration()
        {
            ToTable("Cards", "dbo");
            HasKey(x => x.CardId);

            Property(x => x.CardId)
                .HasColumnName(@"CardID")
                .HasColumnType("char")
                .IsRequired()
                .IsFixedLength()
                .IsUnicode(false)
                .HasMaxLength(16)
                .HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.ClientId)
                .HasColumnName(@"ClientID")
                .HasColumnType("int")
                .IsRequired();
            Property(x => x.PinCode)
                .HasColumnName(@"PinCode")
                .HasColumnType("char")
                .IsRequired()
                .IsFixedLength()
                .IsUnicode(false)
                .HasMaxLength(4);
            Property(x => x.Ballance)
                .HasColumnName(@"Ballance")
                .HasColumnType("money")
                .IsRequired()
                .HasPrecision(19, 4);

            // Foreign keys
            HasRequired(a => a.Client).WithMany(b => b.Cards).HasForeignKey(c => c.ClientId).WillCascadeOnDelete(false); // FK_Cards_Clients
            
        }
    }
}