using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class DmKy
    {
        public int? IdKy { get; set; }
        public string MaKy { get; set; }
        public string LoaiKy { get; set; }
        public string TenKy { get; set; }
        public string HieuLucTu { get; set; }
        public string HieuLucDen { get; set; }
        public DateTime? GiaTriNgay { get; set; }
        public string GiaTriThang { get; set; }
        public int? GiaTriQuy { get; set; }
        public int? GiaTriNam { get; set; }
        public string GiaTriNuaNam { get; set; }
        public string GiaTriChinThang { get; set; }
        public string GiaTriNamThang { get; set; }
    }
}
