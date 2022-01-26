using BlazorVNPTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Repository
{
    public interface IRepository
    {
        Task<QuestionUserExam> LayDanhSachCauHoi(int user_id, int exam_id);

        Task CapNhatCauTraLoi(int questionExamId, int userAnswerId);

        Task CapNhatDiem(int userExamId, int numOfRight, decimal score);
        
        Task<KetQuaBaiThi> LayBaoCaoDiem(int userExamId);

        Task<List<ExamInfo>> LayDanhSachBaiThi(int userId);

        Task<ExamInfo> LayThongTinBaiThi(int examId);

        Task<ExamNotFinishedYet> LayBaiThiDangLam(int userId);

        Task<List<int>> LayIdBaithiDaThamGia(int userId);


    }
}
