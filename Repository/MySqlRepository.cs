using BlazorVNPTQuiz.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using Microsoft.Extensions.Configuration;

namespace BlazorVNPTQuiz.Repository
{
    public class MySqlRepository : IRepository
    {

        private IConfiguration configuration;
        public MySqlRepository( IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task CapNhatCauTraLoi(int questionExamId, int userAnswerId)
        {

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                using (var command = new MySqlCommand($"update exam_question_official set answer_id = {userAnswerId} where id = {questionExamId}", connection))
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<QuestionUserExam> LayDanhSachCauHoi(int user_id, int exam_id)
        {
            QuestionUserExam questionExam = new QuestionUserExam() { UserId = user_id, ExamID = exam_id};
            questionExam.Questions = new List<QuestionDAO>();

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                using (var command = new MySqlCommand($"call proc_get_question_exam_v2({exam_id},{user_id},1,' ',' ')", connection))
                {
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
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
            return questionExam;

        }

        public async Task CapNhatDiem(int userExamId,int numOfRight, decimal score)
        {
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                using (var command = new MySqlCommand($"update user_exam set num_of_right = {numOfRight}, score = {score}, finished_time = {DateTime.Now}", connection))
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        
    }
}
