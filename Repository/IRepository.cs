﻿using BlazorVNPTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Repository
***REMOVED***
    interface IRepository
    ***REMOVED***
        Task<QuestionUserExam> LayDanhSachCauHoi(int user_id, int exam_id);

        Task CapNhatCauTraLoi(int questionExamId, int userAnswerId);

        Task CapNhatDiem(int userExamId, int numOfRight, decimal score);

        Task<KetQuaBaiThi> LayBaoCaoDiem(int userExamId);
***REMOVED***
***REMOVED***
