using System;
using System.Collections.Generic;
namespace SystemApp.Models
{
    public partial class ClassesTbl
    {
        public int Id { get; set; }

        public string? ClassName { get; set; }

        public string? Description { get; set; }

        public string? Address { get; set; }

        public DateTime CreateDate { get; set; }
       
    }
}