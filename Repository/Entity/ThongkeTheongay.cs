using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class ThongkeTheongay
    {
        public decimal? Thamgia { get; set; }
        public string Ttvt { get; set; }
        public long? Ngay { get; set; }
        public long TongNhansu { get; set; }
        public decimal? TyleThamgia { get; set; }
    }
}
