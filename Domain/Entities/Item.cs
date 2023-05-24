﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace net_store_backend.Domain.Entities
{
    [Table("items")]
    public class Item
    {
        [Key]
        public long Id { get; set; }
        [Column(TypeName = "vachar(100)")]
        [MinLength(3)]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "varchar(2000)")]
        public string? Description { get; set; }
        [Range(0, double.MaxValue)]
        [Required]
        public double Price { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public long CategoryId { get; set; }
        [Required]
        public Category Category { get; set; }
    }
}

