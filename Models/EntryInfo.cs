using System;
using System.ComponentModel.DataAnnotations;

namespace Entry.Models
{
    public class EntryInfo
    {
        [Key]
        public int Id { get; set; }
        public DateOnly Date { get; set; }
        public string? Type { get; set; }
        public int Value { get; set; }
        public string? User { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}