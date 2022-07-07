using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class User
    {
        public ulong Id { get; set; }
        public string User1 { get; set; }
        public string Pass { get; set; }
        public string HoTen { get; set; }
        public string DonVi { get; set; }
        public sbyte? Enable { get; set; }
        public string SoDt { get; set; }
        public sbyte? OntapStatus { get; set; }
        public string Ttvt { get; set; }
        public DateTime? LoginTime { get; set; }
        public int? DonviId { get; set; }
    }
}
