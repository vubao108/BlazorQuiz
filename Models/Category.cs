using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsSelected { get; set; }

        public List<CategoryLevelState> LevelStates {get;set;}
    }

    public class CategoryLevelState
    {
        public int LevelId;
        public int NumOfQuestion;
    }
}
