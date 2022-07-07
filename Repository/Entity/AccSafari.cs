using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class AccSafari
    {
        public uint Id { get; set; }
        public string MaNd { get; set; }
        public string HoTen { get; set; }
        public string SoDt { get; set; }
        public DateTime? NgaySn { get; set; }
        public DateTime? UpdateTime { get; set; }
        public sbyte? IsUsed { get; set; }
    }
}
