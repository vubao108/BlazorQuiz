using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorVNPTQuiz.Models;

namespace BlazorVNPTQuiz.Repository
{
    public interface IRepositoryOntap
    {
        public Task<List<Donvi>> LayDanhSachDonVi(int user_id);

        public Task<List<Category>> LayDanhSachChuDeTheoDonVi(int donvi_id);

        public Task GanChuDeChoDonVi(int donvi_id, List<Category> categories);

        public void GenerateDulieuOnTap(int donvi_id);

        public Task<List<Category>> LayDanhSachChuDeTheoNguoiDung(int user_id);

        public Task<List<QuestionLevel>> LayDanhSachMucDoCauHoi();


        public Task<List<QuestionOnTap>> LayDanhSachCauHoiOnTapTheoMucDo(int user_id, string tag_ids, int level_id, int limit);

        public Task UpdateDanhGiaCauhoiOnTap(int id, int level_id);
    
    }
}
