using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class ThongBao
    {
        public uint Id { get; set; }
        public string TieuDe { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayTao { get; set; }
        public int? DaGui { get; set; }
        public int? NguoiTao { get; set; }
        public DateTime? NgayGui { get; set; }
        public int? NguoiGui { get; set; }
        public int? DonviId { get; set; }
    }
}
