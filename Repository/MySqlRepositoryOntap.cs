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

        void IRepositoryOntap.GanChuDeChoDonVi(int donvi_id, List<Category> categories)
        {
            throw new NotImplementedException();
        }

        void IRepositoryOntap.GenerateDulieuOnTap(int donvi_id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Category>> LayDanhSachChuDeTheoDonVi(int donvi_id)
        {
            string sql_query = @"select SELECT a.tag_id , a.tag_name, b.donvi_id,
                CASE WHEN b.donvi_id IS  NULL THEN 0 ELSE 1 END isSelected 
                FROM tags a
                LEFT JOIN donvi_tag b ON a.tag_id = b.tag_id AND b.donvi_id = " 
                + $"{donvi_id}";
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
            string sql_query = $"SELECT b.donvi_id, b.ten_dv FROM user_donvi a, donvi b WHERE a.donvi_id = b.id AND a.user_id = {user_id} ";
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
    }
}
