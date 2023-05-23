using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_store_backend.Domain.Entities

{
    [Table("categories")]
    public class Category
    {
        public long Id { get; set; }
        [Column(TypeName = "vachar(100)")]
        [MinLength(3)]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "varchar(2000)")]
        public string? Description { get; set; }
        [Required]
        public byte[] Image { get; set; }
    }
}
