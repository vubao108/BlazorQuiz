using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Models
***REMOVED***
    public class Category
    ***REMOVED***
        public int Id ***REMOVED*** get; set; ***REMOVED***
        public string Name ***REMOVED*** get; set; ***REMOVED***

        public bool IsSelected ***REMOVED*** get; set; ***REMOVED***

        public List<CategoryLevelState> LevelStates ***REMOVED***get;set;***REMOVED***
***REMOVED***

    public class CategoryLevelState
    ***REMOVED***
        public int LevelId;
        public int NumOfQuestion;
***REMOVED***
***REMOVED***
