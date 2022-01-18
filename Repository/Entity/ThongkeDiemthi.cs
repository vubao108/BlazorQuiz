using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class ThongkeDiemthi
    {
        public long? ExamId { get; set; }
        public long UserId { get; set; }
        public string HoTen { get; set; }
        public long GroupId { get; set; }
        public long? Caudung { get; set; }
        public string Ttvt { get; set; }
        public decimal? MaxScore { get; set; }
    }
}
