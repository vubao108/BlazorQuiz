using BlazorVNPTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Microsoft.Extensions.Configuration;
using System.Diagnostics;
using Serilog;
using Microsoft.Extensions.Logging;

namespace BlazorVNPTQuiz.Repository
***REMOVED***
    public class MySqlRepository : IRepository
    ***REMOVED***

        private IConfiguration configuration;
        private ILogger<MySqlRepository> logger;
        public MySqlRepository(IConfiguration configuration,ILogger<MySqlRepository> logger)
        ***REMOVED***
            this.configuration = configuration;
            this.logger = logger;

    ***REMOVED***

        public async Task CapNhatCauTraLoi(int questionExamId, int userAnswerId)
        ***REMOVED***

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            ***REMOVED***
                using (var command = new MySqlCommand($"update exam_question_official set answer_id = ***REMOVED***userAnswerId***REMOVED*** where id = ***REMOVED***questionExamId***REMOVED***", connection))
                ***REMOVED***
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***
       

        public async Task<QuestionUserExam> LayDanhSachCauHoi(int user_id, int exam_id)
        ***REMOVED***
            QuestionUserExam questionExam = new QuestionUserExam() ***REMOVED*** UserId = user_id, ExamID = exam_id ***REMOVED***;
            questionExam.Questions = new List<QuestionDAO>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            ***REMOVED***
                using (var command = new MySqlCommand($"call proc_get_question_exam_v2(***REMOVED***exam_id***REMOVED***,***REMOVED***user_id***REMOVED***,1,' ',' ')", connection))
                ***REMOVED***
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    ***REMOVED***
                        if (reader.GetInt32("id") == 0)
                        ***REMOVED***
                            questionExam.UserExamId = 0;
                            break;
                    ***REMOVED***
                        questionExam.UserExamId = reader.GetInt32("uet_id");

                        questionExam.TryNum = reader.GetInt32("try_num");
                        questionExam.RemainSeCond = reader.GetInt32("remain_second");
                        AnswerDAO answerDAO = new AnswerDAO()
                        ***REMOVED***
                            AnswerId = reader.GetInt32("answer_id"),
                            AnswerText = reader.GetString("answer_text"),
                            IsCorrect = reader.GetInt32("state") == 1

                    ***REMOVED***;
                        QuestionDAO currentQuestionDAO = new QuestionDAO()
                        ***REMOVED***
                            ExamQuestionId = reader.GetInt32("id"),
                            QuestionId = reader.GetInt32("question_id"),
                            QuestionText = reader.GetString("question_text"),
                            UserAnswerId = reader.GetInt32("user_answer_id")

                    ***REMOVED***;

                        if (!questionExam.IsContainQuestion(currentQuestionDAO))
                        ***REMOVED***
                            questionExam.AddQuestion(currentQuestionDAO);
                    ***REMOVED***
                        questionExam.GetQuestion(currentQuestionDAO.QuestionId).AddAnswer(answerDAO);
                ***REMOVED***
            ***REMOVED***
        ***REMOVED***
            stopwatch.Stop();
            Debug.Print($"LayDanhSachCauHoi(***REMOVED***user_id***REMOVED***,***REMOVED***exam_id***REMOVED***) took ***REMOVED***stopwatch.ElapsedMilliseconds***REMOVED***");
            logger.LogInformation($"LayDanhSachCauHoi(***REMOVED***user_id***REMOVED***,***REMOVED***exam_id***REMOVED***) took ***REMOVED***stopwatch.ElapsedMilliseconds***REMOVED***");
            return questionExam;

    ***REMOVED***

        public async Task CapNhatDiem(int userExamId, int numOfRight, decimal score)
        ***REMOVED***
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            ***REMOVED***
                using (var command = new MySqlCommand($"update user_exam set state = 1, num_of_right = ***REMOVED***numOfRight***REMOVED***, score = ***REMOVED***score***REMOVED***, finished_time = '***REMOVED***DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")***REMOVED***' where id = ***REMOVED***userExamId***REMOVED***", connection))
                ***REMOVED***
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***

        public async Task<KetQuaBaiThi> LayBaoCaoDiem(int userExamId)
        ***REMOVED***
            KetQuaBaiThi ketQuaBaiThi = new KetQuaBaiThi();
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            ***REMOVED***
                string sql = $"select  a.score, a.num_of_right, a.finished_time, a.join_time, a.try_num, " +
                    $" a.exam_id,  b.max_try, b.name, b.duration, b.num_of_question, c.user, a.user_id, c.ho_ten, c.ttvt " +
                    $" from user_exam  a, exam b, users c " +
                    $" where a.id = ***REMOVED***userExamId***REMOVED*** and a.exam_id = b.id and a.user_id = c.id";
                using (var command = new MySqlCommand(sql, connection))
                ***REMOVED***
                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    ***REMOVED***
                        while (await reader.ReadAsync())
                        ***REMOVED***
                            ketQuaBaiThi.UserExamId = userExamId;
                            ketQuaBaiThi.Score = reader.GetDecimal("score");
                            ketQuaBaiThi.NumOfRight = reader.GetInt32("num_of_right");
                            ketQuaBaiThi.JoinTime = reader.GetDateTime("join_time");
                            ketQuaBaiThi.FinishTime = reader.GetDateTime("finished_time");
                            ketQuaBaiThi.TryNum = reader.GetInt32("try_num");
                            ketQuaBaiThi.Exam = new ExamInfo()
                            ***REMOVED***
                                ExamId = reader.GetInt32("exam_id"),
                                ExamName = reader.GetString("name"),
                                Duration = reader.GetInt32("duration"),
                                NumOfQuestion = reader.GetInt32("num_of_question"),
                                MaxTry = reader.GetInt32("max_try")
                        ***REMOVED***;
                            ketQuaBaiThi.User = new UserInfo()
                            ***REMOVED***
                                UserId = reader.GetInt32("user_id"),
                                UserName = reader.GetString("user"),
                                FullName = reader.GetString("ho_ten"),
                                TenDonVi = reader.GetString("ttvt")
                        ***REMOVED***;
                    ***REMOVED***
                ***REMOVED***
            ***REMOVED***
        ***REMOVED***
            return ketQuaBaiThi;
    ***REMOVED***

        public async Task<List<ExamInfo>> LayDanhSachBaiThi(int userId)
        ***REMOVED***
            List<ExamInfo> examInfos = new List<ExamInfo>();
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            ***REMOVED***
                string sql = $"call proc_lay_ds_baithi_web(***REMOVED***userId***REMOVED***)";
                using (var command = new MySqlCommand(sql, connection))
                ***REMOVED***
                    await connection.OpenAsync();
                    using(var reader = await command.ExecuteReaderAsync())
                    ***REMOVED***
                        while (await reader.ReadAsync())
                        ***REMOVED***
                            examInfos.Add(
                                new ExamInfo()
                                ***REMOVED***
                                    ExamId = reader.GetInt32("id"),
                                    ExamName = reader.GetString("name"),
                                    Duration = reader.GetInt32("duration"),
                                    NumOfQuestion = reader.GetInt32("num_of_question"),
                                    MaxTry = reader.GetInt32("max_try")

                            ***REMOVED***
                            );
                    ***REMOVED***
                        
                ***REMOVED***

            ***REMOVED***
        ***REMOVED***

            return examInfos;
    ***REMOVED***

        public async Task<ExamInfo> LayThongTinBaiThi(int examId)
        ***REMOVED***
            ExamInfo examInfo = null;
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            ***REMOVED***
                string sql = $"select * from exam where id = ***REMOVED***examId***REMOVED***";
                using (var command = new MySqlCommand(sql, connection))
                ***REMOVED***
                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    ***REMOVED***
                        while (await reader.ReadAsync())
                        ***REMOVED***

                            examInfo = new ExamInfo()
                            ***REMOVED***
                                ExamId = reader.GetInt32("id"),
                                ExamName = reader.GetString("name"),
                                Duration = reader.GetInt32("duration"),
                                NumOfQuestion = reader.GetInt32("num_of_question"),
                                MaxTry = reader.GetInt32("max_try")

                        ***REMOVED***;
                            
                    ***REMOVED***

                ***REMOVED***

            ***REMOVED***
        ***REMOVED***
            return examInfo;


    ***REMOVED***

        public async Task<ExamNotFinishedYet> LayBaiThiDangLam(int userId)
        ***REMOVED***
            ExamNotFinishedYet examNotFinishedYet = new ExamNotFinishedYet();
            try
            ***REMOVED***
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
                ***REMOVED***
                    string sql = $"call proc_laybaithi_danglam(***REMOVED***userId***REMOVED***)";
                    using (var command = new MySqlCommand(sql, connection))
                    ***REMOVED***
                        await connection.OpenAsync();
                        using (var reader = await command.ExecuteReaderAsync())
                        ***REMOVED***
                            while (await reader.ReadAsync())
                            ***REMOVED***
                                examNotFinishedYet.UserExamId = reader.GetInt32("user_exam_id");
                                if (examNotFinishedYet.UserExamId == 0)
                                ***REMOVED***
                                    return examNotFinishedYet;
                            ***REMOVED***
                                examNotFinishedYet.CurrentExam = new ExamInfo()
                                ***REMOVED***
                                    ExamId = reader.GetInt32("id"),
                                    ExamName = reader.GetString("name"),
                                    Duration = reader.GetInt32("duration"),
                                    NumOfQuestion = reader.GetInt32("num_of_question"),
                                    MaxTry = reader.GetInt32("max_try")

                            ***REMOVED***;

                                examNotFinishedYet.JoinTime = reader.GetDateTime("join_time");
                                examNotFinishedYet.TryNum = reader.GetInt32("try_num");
                                examNotFinishedYet.RemainSecond = reader.GetInt32("remain_second");


                        ***REMOVED***

                    ***REMOVED***

                ***REMOVED***
            ***REMOVED***
                stopwatch.Stop();
                Debug.Print($"LayBaiThiDangLam(***REMOVED***userId***REMOVED***) took ***REMOVED***stopwatch.ElapsedMilliseconds***REMOVED***");
                logger.LogInformation($"LayBaiThiDangLam(***REMOVED***userId***REMOVED***) took ***REMOVED***stopwatch.ElapsedMilliseconds***REMOVED***");
        ***REMOVED***
            catch(Exception ex)
            ***REMOVED***
                System.Diagnostics.Debug.Print(ex.StackTrace);
        ***REMOVED***
            return examNotFinishedYet;
    ***REMOVED***


        public async Task<List<int>> LayIdBaithiDaThamGia(int userId)
        ***REMOVED***
            List<int> listExamIds = new List<int>();
            try
            ***REMOVED***
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
                ***REMOVED***
                    string sql = $"select exam_id from user_exam where user_id = ***REMOVED***userId***REMOVED***";
                    using (var command = new MySqlCommand(sql, connection))
                    ***REMOVED***
                        await connection.OpenAsync();
                        using var reader = await command.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        ***REMOVED***
                            listExamIds.Add(reader.GetInt32("exam_id"));
                    ***REMOVED***
                ***REMOVED***
            ***REMOVED***
                stopwatch.Stop();
                logger.LogInformation($"LayIdBaithiDaThamGia(***REMOVED***userId***REMOVED***) took ***REMOVED***stopwatch.ElapsedMilliseconds***REMOVED***");
        ***REMOVED***
            catch (Exception ex)
            ***REMOVED***
               Debug.Print(ex.StackTrace);
        ***REMOVED***
            return listExamIds;
    ***REMOVED***


***REMOVED***
***REMOVED***
