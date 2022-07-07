using System;
using System.Collections.Generic;

#nullable disable

namespace BlazorVNPTQuiz.Repository.Entity
{
    public partial class AppVersion
    {
        public string VersionName { get; set; }
        public int VersionCode { get; set; }
        public DateTime? InsertTime { get; set; }
        public string Note { get; set; }
    }
}
