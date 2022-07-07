using BlazorVNPTQuiz.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorVNPTQuiz.Repository
{
    public class MySqlRepositoryOntap : IRepositoryOntap
    {

        private IConfiguration configuration;
        private ILogger<MySqlRepositoryOntap> logger;
        public MySqlRepositoryOntap(IConfiguration configuration, ILogger<MySqlRepositoryOntap> logger)
        {
            this.configuration = configuration;
            this.logger = logger;

        }

        public async Task  GanChuDeChoDonVi(int donvi_id, List<Category> categories)
        {
            string sql_update = $"delete from donvi_tag where donvi_id = {donvi_id} ;";
            foreach(Category category in categories)
            {
                sql_update += $" insert into donvi_tag(donvi_id, tag_id) values({donvi_id}, {category.Id}); ";
            }

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                using (var command = new MySqlCommand(sql_update, connection))
                {
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        void IRepositoryOntap.GenerateDulieuOnTap(int donvi_id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> LayDanhSachChuDeTheoDonVi(int donvi_id)
        {
            string sql_query = @"SELECT a.tag_id , a.tag_name, b.donvi_id,
                CASE WHEN b.donvi_id IS  NULL THEN 0 ELSE 1 END isSelected 
                FROM tags a
                LEFT JOIN donvi_tag b ON a.tag_id = b.tag_id AND b.donvi_id = " 
                + $"{donvi_id}  order by isSelected desc, tag_name";
            List<Category> categories = new List<Category>();
 
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                using (var command = new MySqlCommand(sql_query, connection))
                {
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int tag_id = reader.GetInt32("tag_id");
                        String tag_name = reader.GetString("tag_name");
                        bool IsSelected = reader.GetInt32("isSelected") == 1;
                        categories.Add(new Category() { Id = tag_id, Name = tag_name, IsSelected = IsSelected });
                    }
                }
            }

            return categories;
        }

        public async Task<List<Donvi>> LayDanhSachDonVi(int user_id)
        {
            string sql_query = $"SELECT a.donvi_id, b.ten_dv FROM user_donvi a, donvi b WHERE a.donvi_id = b.id AND a.user_id = {user_id} ";
            List<Donvi> donvis = new List<Donvi>();

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                using (var command = new MySqlCommand(sql_query, connection))
                {
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int donvi_id = reader.GetInt32("donvi_id");
                        String name = reader.GetString("ten_dv");
                        
                        donvis.Add(new Donvi() { Id = donvi_id, Name = name });
                    }
                }
            }

            return donvis;
        }

        public async Task<List<Category>> LayDanhSachChuDeTheoNguoiDung(int user_id)
        {
            string sql_query = @"SELECT a.tag_id, tag_name, level_id, level_name , count(1) as num_of_question
                                from user_question a, tags b , question_level c " +
                              $"  where user_id = {user_id} and a.tag_id = b.tag_id  and a.level_id = c.id " +
                                   " group by a.tag_id, tag_name, level_id";
            List<Category> categories = new List<Category>();

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                using (var command = new MySqlCommand(sql_query, connection))
                {
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int tag_id = reader.GetInt32("tag_id");
                        String tag_name = reader.GetString("tag_name");
                        String level_name = reader.GetString("level_name");
                        int level_id = reader.GetInt32("level_id");
                        int num_of_question = reader.GetInt32("num_of_question");
                        bool IsSelected = false;
                        var category = categories.FirstOrDefault(item => item.Id == tag_id);
                        var categoryState = new CategoryLevelState()
                        {
                            LevelId = level_id,
                            LevelName = level_name,
                            NumOfQuestion = num_of_question
                        };
                        if (category == null)
                        {
                            categories.Add(new Category()
                            {
                                Id = tag_id,
                                Name = tag_name,
                                IsSelected = IsSelected,
                                LevelStates = new List<CategoryLevelState>() {
                                    categoryState

                                }
                            });

                        }
                        else
                        {
                            category.LevelStates.Add(categoryState);
                        }
                       
                    }
                }
            }

            return categories;
        }

        public async Task<List<QuestionLevel>> LayDanhSachMucDoCauHoi()
        {
           
            string sql_query = @"select id,level from question_level  ";
              
            List<QuestionLevel> levels = new List<QuestionLevel>();

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                using (var command = new MySqlCommand(sql_query, connection))
                {
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int level_id = reader.GetInt32("id");
                        String level = reader.GetString("level");

                        levels.Add(new QuestionLevel() { Id = level_id, Level = level });
                    }
                 }
             }
           

            return levels;
        }

        public async Task<List<QuestionOnTap>> LayDanhSachCauHoiOnTapTheoMucDo(int user_id, string tag_ids, int level_id, int limit)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //string tag_ids_str = String.Join(',', tag_ids.ToArray());
            string sql_query = $" call  proc_lay_cauhoi_ontap_web({user_id},'{tag_ids}', {level_id}, {limit})";

            List<QuestionOnTap> questionOnTaps = new List<QuestionOnTap>();

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                using (var command = new MySqlCommand(sql_query, connection))
                {
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        AnswerDAO answerDAO = new AnswerDAO()
                        {
                            AnswerId = reader.GetInt32("answer_id"),
                            AnswerText = reader.GetString("answer_text"),
                            IsCorrect = reader.GetInt32("state") == 1

                        };
                        if (String.IsNullOrWhiteSpace(answerDAO.AnswerText))
                        {
                            continue;
                        }
                        QuestionOnTap questionOnTap = new QuestionOnTap()
                        {
                            Id = reader.GetInt32("id"),
                            QuestionId = reader.GetInt32("question_id"),
                            QuestionText = reader.GetString("question_text"),
                            IsMultipleChoice = reader.GetInt32("is_multiple_choice") == 1,
                            TagId = reader.GetInt32("tag_id"),
                            LevelId = reader.GetInt32("level_id"),
                            UserId = user_id
                        };
                        QuestionOnTap currentQuestionOntap = questionOnTaps.FirstOrDefault(item => item.QuestionId == questionOnTap.QuestionId);
                        if(currentQuestionOntap == null)
                        {
                            questionOnTap.Answers = new List<AnswerDAO> { answerDAO };
                            questionOnTaps.Add(questionOnTap);
                        }
                        else
                        {
                            currentQuestionOntap.Answers.Add(answerDAO);
                        }
                        
                    }
                }
            }
            stopwatch.Stop();
            logger.LogInformation($"LayDanhSachCauHoiOnTapTheoMucDo(user_id={user_id},tags={tag_ids},level_id={level_id}) took {stopwatch.ElapsedMilliseconds} ms");

            return questionOnTaps;
        }

        public async Task UpdateDanhGiaCauhoiOnTap(int id, int level_id)
        {
            Stopwatch stopwatch = null;
            try
            {
                 stopwatch = new Stopwatch();

                stopwatch.Start();
                string sql_update = $"update  user_question set level_id = {level_id}, update_time = sysdate()  where id = {id};";


                using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
                {
                    using (var command = new MySqlCommand(sql_update, connection))
                    {
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                    }
                }
                
                
            }catch(Exception ex)
            {
                logger.LogError(ex.StackTrace);
            }
            finally
            {
                stopwatch?.Stop();
                logger.LogInformation($"UpdateDanhGiaCauhoiOnTap(id={id},level_id={level_id}) took {stopwatch?.ElapsedMilliseconds} ms");
            }

        }

    }
}
