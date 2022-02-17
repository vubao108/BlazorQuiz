using BlazorVNPTQuiz.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MySqlConnector;
using System;
using System.Collections.Generic;
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
            string sql_query = @"SELECT a.tag_id , a.tag_name, b.donvi_id,
                0 isSelected
                FROM tags a
                , donvi_tag b, users c where a.tag_id = b.tag_id AND b.donvi_id = c.donvi_id and c.id = "
                + $"{user_id}  order by  tag_name";
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
    }
}
