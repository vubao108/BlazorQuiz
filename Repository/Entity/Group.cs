using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class Group
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? DonviId { get; set; }
    }
}
