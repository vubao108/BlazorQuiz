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
***REMOVED***
    public class MySqlRepositoryOntap : IRepositoryOntap
    ***REMOVED***

        private IConfiguration configuration;
        private ILogger<MySqlRepositoryOntap> logger;
        public MySqlRepositoryOntap(IConfiguration configuration, ILogger<MySqlRepositoryOntap> logger)
        ***REMOVED***
            this.configuration = configuration;
            this.logger = logger;

    ***REMOVED***

        public async Task  GanChuDeChoDonVi(int donvi_id, List<Category> categories)
        ***REMOVED***
            string sql_update = $"delete from donvi_tag where donvi_id = ***REMOVED***donvi_id***REMOVED*** ;";
            foreach(Category category in categories)
            ***REMOVED***
                sql_update += $" insert into donvi_tag(donvi_id, tag_id) values(***REMOVED***donvi_id***REMOVED***, ***REMOVED***category.Id***REMOVED***); ";
        ***REMOVED***

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            ***REMOVED***
                using (var command = new MySqlCommand(sql_update, connection))
                ***REMOVED***
                    await connection.OpenAsync();
                    await command.ExecuteNonQueryAsync();
            ***REMOVED***
        ***REMOVED***
    ***REMOVED***

        void IRepositoryOntap.GenerateDulieuOnTap(int donvi_id)
        ***REMOVED***
            throw new NotImplementedException();
    ***REMOVED***

        public async Task<List<Category>> LayDanhSachChuDeTheoDonVi(int donvi_id)
        ***REMOVED***
            string sql_query = @"SELECT a.tag_id , a.tag_name, b.donvi_id,
                CASE WHEN b.donvi_id IS  NULL THEN 0 ELSE 1 END isSelected 
                FROM tags a
                LEFT JOIN donvi_tag b ON a.tag_id = b.tag_id AND b.donvi_id = " 
                + $"***REMOVED***donvi_id***REMOVED***  order by isSelected desc, tag_name";
            List<Category> categories = new List<Category>();
 
            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            ***REMOVED***
                using (var command = new MySqlCommand(sql_query, connection))
                ***REMOVED***
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    ***REMOVED***
                        int tag_id = reader.GetInt32("tag_id");
                        String tag_name = reader.GetString("tag_name");
                        bool IsSelected = reader.GetInt32("isSelected") == 1;
                        categories.Add(new Category() ***REMOVED*** Id = tag_id, Name = tag_name, IsSelected = IsSelected ***REMOVED***);
                ***REMOVED***
            ***REMOVED***
        ***REMOVED***

            return categories;
    ***REMOVED***

        public async Task<List<Donvi>> LayDanhSachDonVi(int user_id)
        ***REMOVED***
            string sql_query = $"SELECT a.donvi_id, b.ten_dv FROM user_donvi a, donvi b WHERE a.donvi_id = b.id AND a.user_id = ***REMOVED***user_id***REMOVED*** ";
            List<Donvi> donvis = new List<Donvi>();

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            ***REMOVED***
                using (var command = new MySqlCommand(sql_query, connection))
                ***REMOVED***
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    ***REMOVED***
                        int donvi_id = reader.GetInt32("donvi_id");
                        String name = reader.GetString("ten_dv");
                        
                        donvis.Add(new Donvi() ***REMOVED*** Id = donvi_id, Name = name ***REMOVED***);
                ***REMOVED***
            ***REMOVED***
        ***REMOVED***

            return donvis;
    ***REMOVED***

        public async Task<List<Category>> LayDanhSachChuDeTheoNguoiDung(int user_id)
        ***REMOVED***
            string sql_query = @"SELECT a.tag_id, tag_name, level_id, level_name , count(1) as num_of_question
                                from user_question a, tags b , question_level c " +
                              $"  where user_id = ***REMOVED***user_id***REMOVED*** and a.tag_id = b.tag_id  and a.level_id = c.id " +
                                   " group by a.tag_id, tag_name, level_id";
            List<Category> categories = new List<Category>();

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            ***REMOVED***
                using (var command = new MySqlCommand(sql_query, connection))
                ***REMOVED***
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    ***REMOVED***
                        int tag_id = reader.GetInt32("tag_id");
                        String tag_name = reader.GetString("tag_name");
                        String level_name = reader.GetString("level_name");
                        int level_id = reader.GetInt32("level_id");
                        int num_of_question = reader.GetInt32("num_of_question");
                        bool IsSelected = false;
                        var category = categories.FirstOrDefault(item => item.Id == tag_id);
                        var categoryState = new CategoryLevelState()
                        ***REMOVED***
                            LevelId = level_id,
                            LevelName = level_name,
                            NumOfQuestion = num_of_question
                    ***REMOVED***;
                        if (category == null)
                        ***REMOVED***
                            categories.Add(new Category()
                            ***REMOVED***
                                Id = tag_id,
                                Name = tag_name,
                                IsSelected = IsSelected,
                                LevelStates = new List<CategoryLevelState>() ***REMOVED***
                                    categoryState

                            ***REMOVED***
                        ***REMOVED***);

                    ***REMOVED***
                        else
                        ***REMOVED***
                            category.LevelStates.Add(categoryState);
                    ***REMOVED***
                       
                ***REMOVED***
            ***REMOVED***
        ***REMOVED***

            return categories;
    ***REMOVED***

        public async Task<List<QuestionLevel>> LayDanhSachMucDoCauHoi()
        ***REMOVED***
           
            string sql_query = @"select id,level from question_level  ";
              
            List<QuestionLevel> levels = new List<QuestionLevel>();

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            ***REMOVED***
                using (var command = new MySqlCommand(sql_query, connection))
                ***REMOVED***
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    ***REMOVED***
                        int level_id = reader.GetInt32("id");
                        String level = reader.GetString("level");

                        levels.Add(new QuestionLevel() ***REMOVED*** Id = level_id, Level = level ***REMOVED***);
                ***REMOVED***
             ***REMOVED***
         ***REMOVED***
           

            return levels;
    ***REMOVED***

        public async Task<List<QuestionOnTap>> LayDanhSachCauHoiOnTapTheoMucDo(int user_id, string tag_ids, int level_id, int limit)
        ***REMOVED***
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //string tag_ids_str = String.Join(',', tag_ids.ToArray());
            string sql_query = $" call  proc_lay_cauhoi_ontap_web(***REMOVED***user_id***REMOVED***,'***REMOVED***tag_ids***REMOVED***', ***REMOVED***level_id***REMOVED***, ***REMOVED***limit***REMOVED***)";

            List<QuestionOnTap> questionOnTaps = new List<QuestionOnTap>();

            using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
            ***REMOVED***
                using (var command = new MySqlCommand(sql_query, connection))
                ***REMOVED***
                    await connection.OpenAsync();
                    using var reader = command.ExecuteReader();
                    while (reader.Read())
                    ***REMOVED***
                        AnswerDAO answerDAO = new AnswerDAO()
                        ***REMOVED***
                            AnswerId = reader.GetInt32("answer_id"),
                            AnswerText = reader.GetString("answer_text"),
                            IsCorrect = reader.GetInt32("state") == 1

                    ***REMOVED***;
                        if (String.IsNullOrWhiteSpace(answerDAO.AnswerText))
                        ***REMOVED***
                            continue;
                    ***REMOVED***
                        QuestionOnTap questionOnTap = new QuestionOnTap()
                        ***REMOVED***
                            Id = reader.GetInt32("id"),
                            QuestionId = reader.GetInt32("question_id"),
                            QuestionText = reader.GetString("question_text"),
                            IsMultipleChoice = reader.GetInt32("is_multiple_choice") == 1,
                            TagId = reader.GetInt32("tag_id"),
                            LevelId = reader.GetInt32("level_id"),
                            UserId = user_id
                    ***REMOVED***;
                        QuestionOnTap currentQuestionOntap = questionOnTaps.FirstOrDefault(item => item.QuestionId == questionOnTap.QuestionId);
                        if(currentQuestionOntap == null)
                        ***REMOVED***
                            questionOnTap.Answers = new List<AnswerDAO> ***REMOVED*** answerDAO ***REMOVED***;
                            questionOnTaps.Add(questionOnTap);
                    ***REMOVED***
                        else
                        ***REMOVED***
                            currentQuestionOntap.Answers.Add(answerDAO);
                    ***REMOVED***
                        
                ***REMOVED***
            ***REMOVED***
        ***REMOVED***
            stopwatch.Stop();
            logger.LogInformation($"LayDanhSachCauHoiOnTapTheoMucDo(user_id=***REMOVED***user_id***REMOVED***,tags=***REMOVED***tag_ids***REMOVED***,level_id=***REMOVED***level_id***REMOVED***) took ***REMOVED***stopwatch.ElapsedMilliseconds***REMOVED*** ms");

            return questionOnTaps;
    ***REMOVED***

        public async Task UpdateDanhGiaCauhoiOnTap(int id, int level_id)
        ***REMOVED***
            Stopwatch stopwatch = null;
            try
            ***REMOVED***
                 stopwatch = new Stopwatch();

                stopwatch.Start();
                string sql_update = $"update  user_question set level_id = ***REMOVED***level_id***REMOVED***, update_time = sysdate()  where id = ***REMOVED***id***REMOVED***;";


                using (var connection = new MySqlConnection(configuration.GetConnectionString("DefaultConnection")))
                ***REMOVED***
                    using (var command = new MySqlCommand(sql_update, connection))
                    ***REMOVED***
                        await connection.OpenAsync();
                        await command.ExecuteNonQueryAsync();
                ***REMOVED***
            ***REMOVED***
                
                
        ***REMOVED***catch(Exception ex)
            ***REMOVED***
                logger.LogError(ex.StackTrace);
        ***REMOVED***
            finally
            ***REMOVED***
                stopwatch?.Stop();
                logger.LogInformation($"UpdateDanhGiaCauhoiOnTap(id=***REMOVED***id***REMOVED***,level_id=***REMOVED***level_id***REMOVED***) took ***REMOVED***stopwatch?.ElapsedMilliseconds***REMOVED*** ms");
        ***REMOVED***

    ***REMOVED***

***REMOVED***
***REMOVED***
