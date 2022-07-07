using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class DataVersion
    {
        public int Id { get; set; }
        public int? Version { get; set; }
        public int DonviId { get; set; }
        public string JsonData { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
