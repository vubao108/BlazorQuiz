using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class GroupTag
    {
        public int Id { get; set; }
        public int? GroupId { get; set; }
        public int? TagId { get; set; }
    }
}
