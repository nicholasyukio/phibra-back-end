using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entry.Models
{
    public class EntryInfo
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string? Type { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Value { get; set; }
        public string? User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}