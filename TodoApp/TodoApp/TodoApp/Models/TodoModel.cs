using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TodoApp.Models
{
    public class TodoModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Task { get; set; }
        [Required]
        public string Priority { get; set; }
        [Required]
        public string Category { get; set; }
    }
}