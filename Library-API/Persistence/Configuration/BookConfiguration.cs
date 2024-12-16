using Library_API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library_API.Persistence.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasOne(o => o.Author)
                .WithMany(o => o.Books)
                .HasForeignKey(o => o.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
