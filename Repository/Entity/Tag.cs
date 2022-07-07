using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class Tag
    {
        public ulong TagId { get; set; }
        public string TagName { get; set; }
        public sbyte Enable { get; set; }
        public int DonviId { get; set; }
    }
}
