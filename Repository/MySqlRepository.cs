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
{
    public class MySqlRepository : IRepository
    {

        private IConfiguration configuration;
        private ILogger<MySqlRepository> logger;
        public MySqlRepository(IConfiguration configuration,ILogger<MySqlRepository> logger)
        {
            this.configuration = configuration;
            this.logger = logger;

        }

        public async Task SyncCauTraLoi(int questionExamId, int userAnswerId)
        {
            string sql = $"update exam_question_official set answer_id = {userAnswerId} where id = {questionExamId}";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                
                using (var command = new MySqlCommand(sql, connection))
                {
                  
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                    
                }
            }
            stopwatch.Stop();
            Debug.Print($"SynCauTraLoi: questionExamId{questionExamId} userAnswerId:{userAnswerId} took {stopwatch.ElapsedMilliseconds}");
            logger.LogInformation("SynCauTraLoi: questionExamId={questionExamId} userAnswerId={userAnswerId} took {} ms", questionExamId, userAnswerId,stopwatch.ElapsedMilliseconds);
        }
       

        public async Task<QuestionUserExam> LayDanhSachCauHoi(int user_id, int exam_id)
        {
            QuestionUserExam questionExam = new QuestionUserExam() { UserId = user_id, ExamID = exam_id };
            questionExam.Questions = new List<QuestionDAO>();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                using (var command = new MySqlCommand($"call proc_get_question_exam_v2({exam_id},{user_id},1,' ',' ')", connection))
                {
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetInt32("id") == 0)
                        {
                            questionExam.UserExamId = 0;
                            break;
                        }
                        questionExam.UserExamId = reader.GetInt32("uet_id");

                        questionExam.TryNum = reader.GetInt32("try_num");
                        questionExam.RemainSeCond = reader.GetInt32("remain_second");
                        AnswerDAO answerDAO = new AnswerDAO()
                        {
                            AnswerId = reader.GetInt32("answer_id"),
                            AnswerText = reader.GetString("answer_text"),
                            IsCorrect = reader.GetInt32("state") == 1

                        };
                        QuestionDAO currentQuestionDAO = new QuestionDAO()
                        {
                            ExamQuestionId = reader.GetInt32("id"),
                            QuestionId = reader.GetInt32("question_id"),
                            QuestionText = reader.GetString("question_text"),
                            UserAnswerId = reader.GetInt32("user_answer_id")

                        };

                        if (!questionExam.IsContainQuestion(currentQuestionDAO))
                        {
                            questionExam.AddQuestion(currentQuestionDAO);
                        }
                        questionExam.GetQuestion(currentQuestionDAO.QuestionId).AddAnswer(answerDAO);
                    }
                }
            }
            stopwatch.Stop();
            Debug.Print($"LayDanhSachCauHoi({user_id},{exam_id}) took {stopwatch.ElapsedMilliseconds}");
            logger.LogInformation($"LayDanhSachCauHoi({user_id},{exam_id}) took {stopwatch.ElapsedMilliseconds}");
            return questionExam;

        }

        public async Task CapNhatDiem(int userExamId, int numOfRight, decimal score)
        {
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                using (var command = new MySqlCommand($"update user_exam set state = 1, num_of_right = {numOfRight}, score = {score}, finished_time = '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}' where id = {userExamId}", connection))
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<KetQuaBaiThi> LayBaoCaoDiem(int userExamId)
        {
            KetQuaBaiThi ketQuaBaiThi = new KetQuaBaiThi();
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sql = $"select  a.score, a.num_of_right, a.finished_time, a.join_time, a.try_num, " +
                    $" a.exam_id,  b.max_try, b.name, b.duration, b.num_of_question, c.user, a.user_id, c.ho_ten, c.ttvt " +
                    $" from user_exam  a, exam b, users c " +
                    $" where a.id = {userExamId} and a.exam_id = b.id and a.user_id = c.id";
                using (var command = new MySqlCommand(sql, connection))
                {
                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            ketQuaBaiThi.UserExamId = userExamId;
                            ketQuaBaiThi.Score = reader.GetDecimal("score");
                            ketQuaBaiThi.NumOfRight = reader.GetInt32("num_of_right");
                            ketQuaBaiThi.JoinTime = reader.GetDateTime("join_time");
                            ketQuaBaiThi.FinishTime = reader.GetDateTime("finished_time");
                            ketQuaBaiThi.TryNum = reader.GetInt32("try_num");
                            ketQuaBaiThi.Exam = new ExamInfo()
                            {
                                ExamId = reader.GetInt32("exam_id"),
                                ExamName = reader.GetString("name"),
                                Duration = reader.GetInt32("duration"),
                                NumOfQuestion = reader.GetInt32("num_of_question"),
                                MaxTry = reader.GetInt32("max_try")
                            };
                            ketQuaBaiThi.User = new UserInfo()
                            {
                                UserId = reader.GetInt32("user_id"),
                                UserName = reader.GetString("user"),
                                FullName = reader.GetString("ho_ten"),
                                TenDonVi = reader.GetString("ttvt")
                            };
                        }
                    }
                }
            }
            return ketQuaBaiThi;
        }

        public async Task<List<ExamInfo>> LayDanhSachBaiThi(int userId)
        {
            List<ExamInfo> examInfos = new List<ExamInfo>();
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sql = $"call proc_lay_ds_baithi_web({userId})";
                using (var command = new MySqlCommand(sql, connection))
                {
                    await connection.OpenAsync();
                    using(var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            examInfos.Add(
                                new ExamInfo()
                                {
                                    ExamId = reader.GetInt32("id"),
                                    ExamName = reader.GetString("name"),
                                    Duration = reader.GetInt32("duration"),
                                    NumOfQuestion = reader.GetInt32("num_of_question"),
                                    MaxTry = reader.GetInt32("max_try")

                                }
                            );
                        }
                        
                    }

                }
            }

            return examInfos;
        }

        public async Task<ExamInfo> LayThongTinBaiThi(int examId)
        {
            ExamInfo examInfo = null;
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                string sql = $"select * from exam where id = {examId}";
                using (var command = new MySqlCommand(sql, connection))
                {
                    await connection.OpenAsync();
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {

                            examInfo = new ExamInfo()
                            {
                                ExamId = reader.GetInt32("id"),
                                ExamName = reader.GetString("name"),
                                Duration = reader.GetInt32("duration"),
                                NumOfQuestion = reader.GetInt32("num_of_question"),
                                MaxTry = reader.GetInt32("max_try")

                            };
                            
                        }

                    }

                }
            }
            return examInfo;


        }

        public async Task<ExamNotFinishedYet> LayBaiThiDangLam(int userId)
        {
            ExamNotFinishedYet examNotFinishedYet = new ExamNotFinishedYet();
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    string sql = $"call proc_laybaithi_danglam({userId})";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        await connection.OpenAsync();
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                examNotFinishedYet.UserExamId = reader.GetInt32("user_exam_id");
                                if (examNotFinishedYet.UserExamId == 0)
                                {
                                    return examNotFinishedYet;
                                }
                                examNotFinishedYet.CurrentExam = new ExamInfo()
                                {
                                    ExamId = reader.GetInt32("id"),
                                    ExamName = reader.GetString("name"),
                                    Duration = reader.GetInt32("duration"),
                                    NumOfQuestion = reader.GetInt32("num_of_question"),
                                    MaxTry = reader.GetInt32("max_try")

                                };

                                examNotFinishedYet.JoinTime = reader.GetDateTime("join_time");
                                examNotFinishedYet.TryNum = reader.GetInt32("try_num");
                                examNotFinishedYet.RemainSecond = reader.GetInt32("remain_second");


                            }

                        }

                    }
                }
                stopwatch.Stop();
                Debug.Print($"LayBaiThiDangLam({userId}) took {stopwatch.ElapsedMilliseconds}");
                logger.LogInformation($"LayBaiThiDangLam({userId}) took {stopwatch.ElapsedMilliseconds}");
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.StackTrace);
            }
            return examNotFinishedYet;
        }


        public async Task<List<int>> LayIdBaithiDaThamGia(int userId)
        {
            List<int> listExamIds = new List<int>();
            try
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    string sql = $"select exam_id from user_exam where user_id = {userId}";
                    using (var command = new MySqlCommand(sql, connection))
                    {
                        await connection.OpenAsync();
                        using var reader = await command.ExecuteReaderAsync();
                        while (await reader.ReadAsync())
                        {
                            listExamIds.Add(reader.GetInt32("exam_id"));
                        }
                    }
                }
                stopwatch.Stop();
                logger.LogInformation($"LayIdBaithiDaThamGia({userId}) took {stopwatch.ElapsedMilliseconds}");
            }
            catch (Exception ex)
            {
               Debug.Print(ex.StackTrace);
            }
            return listExamIds;
        }


    }
}
