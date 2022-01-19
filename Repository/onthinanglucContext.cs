using System;
using BlazorVNPTQuiz.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BlazorVNPTQuiz.Repository
{
    public partial class onthinanglucContext : DbContext
    {
        public onthinanglucContext()
        {
        }

        public onthinanglucContext(DbContextOptions<onthinanglucContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccSafari> AccSafaris { get; set; }
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AppState> AppStates { get; set; }
        public virtual DbSet<AppVersion> AppVersions { get; set; }
        public virtual DbSet<DataVersion> DataVersions { get; set; }
        public virtual DbSet<DmKy> DmKies { get; set; }
        public virtual DbSet<Donvi> Donvis { get; set; }
        public virtual DbSet<DonviTag> DonviTags { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<ExamGroup> ExamGroups { get; set; }
        public virtual DbSet<ExamQuestion> ExamQuestions { get; set; }
        public virtual DbSet<ExamQuestionOfficial> ExamQuestionOfficials { get; set; }
        public virtual DbSet<ExamTag> ExamTags { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<GroupQuyen> GroupQuyens { get; set; }
        public virtual DbSet<GroupTag> GroupTags { get; set; }
        public virtual DbSet<LogExam> LogExams { get; set; }
        public virtual DbSet<LogQuestion> LogQuestions { get; set; }
        public virtual DbSet<PttbUser1406> PttbUser1406s { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionAnswer> QuestionAnswers { get; set; }
        public virtual DbSet<QuestionTag> QuestionTags { get; set; }
        public virtual DbSet<QuestionTagBk1801> QuestionTagBk1801s { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<ThongBao> ThongBaos { get; set; }
        public virtual DbSet<ThongkeDiemthi> ThongkeDiemthis { get; set; }
        public virtual DbSet<ThongkeTheongay> ThongkeTheongays { get; set; }
        public virtual DbSet<TmpAntoanLd0806> TmpAntoanLd0806s { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserDonvi> UserDonvis { get; set; }
        public virtual DbSet<UserExam> UserExams { get; set; }
        public virtual DbSet<UserGroup> UserGroups { get; set; }
        public virtual DbSet<UserOntap> UserOntaps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<AccSafari>(entity =>
            {
                entity.ToTable("acc_safari");

                entity.Property(e => e.Id)
                    .HasColumnType("int(12) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(255)
                    .HasColumnName("ho_ten");

                entity.Property(e => e.IsUsed)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("is_used")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.MaNd)
                    .HasMaxLength(36)
                    .HasColumnName("ma_nd");

                entity.Property(e => e.NgaySn)
                    .HasColumnType("datetime")
                    .HasColumnName("ngay_sn");

                entity.Property(e => e.SoDt)
                    .HasMaxLength(18)
                    .HasColumnName("so_dt");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("update_time");
            });

            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("answers");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.AnswerId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("answer_id");

                entity.Property(e => e.AnswerText)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasColumnName("answer_text");
            });

            modelBuilder.Entity<AppState>(entity =>
            {
                entity.HasKey(e => e.DonviId)
                    .HasName("PRIMARY");

                entity.ToTable("app_state");

                entity.Property(e => e.DonviId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("donvi_id");

                entity.Property(e => e.OntapStatus)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("ontap_status")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<AppVersion>(entity =>
            {
                entity.HasKey(e => e.VersionCode)
                    .HasName("PRIMARY");

                entity.ToTable("app_version");

                entity.Property(e => e.VersionCode)
                    .HasColumnType("int(12)")
                    .ValueGeneratedNever()
                    .HasColumnName("versionCode");

                entity.Property(e => e.InsertTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("insert_time")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("note");

                entity.Property(e => e.VersionName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("versionName");
            });

            modelBuilder.Entity<DataVersion>(entity =>
            {
                entity.ToTable("data_version");

                entity.HasIndex(e => new { e.Version, e.DonviId }, "unique_version_donvi")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.DonviId)
                    .HasColumnType("int(11)")
                    .HasColumnName("donvi_id")
                    .HasComment("// 1. ki thuat. 2. kinh doanh");

                entity.Property(e => e.JsonData)
                    .HasColumnType("json")
                    .HasColumnName("json_data");

                entity.Property(e => e.UpdateDate)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("update_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Version)
                    .HasColumnType("int(11)")
                    .HasColumnName("version");
            });

            modelBuilder.Entity<DmKy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("dm_ky");

                entity.Property(e => e.GiaTriChinThang)
                    .HasMaxLength(255)
                    .HasColumnName("GIA_TRI_CHIN_THANG");

                entity.Property(e => e.GiaTriNam)
                    .HasColumnType("int(11)")
                    .HasColumnName("GIA_TRI_NAM");

                entity.Property(e => e.GiaTriNamThang)
                    .HasMaxLength(255)
                    .HasColumnName("GIA_TRI_NAM_THANG");

                entity.Property(e => e.GiaTriNgay)
                    .HasColumnType("date")
                    .HasColumnName("GIA_TRI_NGAY");

                entity.Property(e => e.GiaTriNuaNam)
                    .HasMaxLength(255)
                    .HasColumnName("GIA_TRI_NUA_NAM");

                entity.Property(e => e.GiaTriQuy)
                    .HasColumnType("int(11)")
                    .HasColumnName("GIA_TRI_QUY");

                entity.Property(e => e.GiaTriThang)
                    .HasMaxLength(255)
                    .HasColumnName("GIA_TRI_THANG");

                entity.Property(e => e.HieuLucDen)
                    .HasMaxLength(255)
                    .HasColumnName("HIEU_LUC_DEN");

                entity.Property(e => e.HieuLucTu)
                    .HasMaxLength(255)
                    .HasColumnName("HIEU_LUC_TU");

                entity.Property(e => e.IdKy)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID_KY");

                entity.Property(e => e.LoaiKy)
                    .HasMaxLength(255)
                    .HasColumnName("LOAI_KY");

                entity.Property(e => e.MaKy)
                    .HasMaxLength(255)
                    .HasColumnName("MA_KY");

                entity.Property(e => e.TenKy)
                    .HasMaxLength(255)
                    .HasColumnName("TEN_KY");
            });

            modelBuilder.Entity<Donvi>(entity =>
            {
                entity.ToTable("donvi");

                entity.HasIndex(e => e.Name, "unique_topic")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(12) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.TenDv)
                    .HasMaxLength(255)
                    .HasColumnName("ten_dv");
            });

            modelBuilder.Entity<DonviTag>(entity =>
            {
                entity.HasKey(e => new { e.DonviId, e.TagId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("donvi_tag");

                entity.Property(e => e.DonviId)
                    .HasColumnType("int(11)")
                    .HasColumnName("donvi_id");

                entity.Property(e => e.TagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("tag_id");
            });

            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("exam");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.DonviId)
                    .HasColumnType("int(11)")
                    .HasColumnName("donvi_id")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Duration)
                    .HasColumnType("int(12)")
                    .HasColumnName("duration")
                    .HasComment("thời gian làm bài,tính bằng second");

                entity.Property(e => e.Enable)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("enable")
                    .HasComment("1: bật, 0 tắt");

                entity.Property(e => e.EndTime)
                    .HasColumnType("datetime")
                    .HasColumnName("end_time")
                    .HasComment("ngày kết thúc, đóng ko cho vào thi nữa");

                entity.Property(e => e.MaxTry)
                    .HasColumnType("int(5)")
                    .HasColumnName("max_try")
                    .HasComment("so lan thi\r\n");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("name")
                    .HasComment("tên đề thi");

                entity.Property(e => e.NumOfQuestion)
                    .HasColumnType("int(12)")
                    .HasColumnName("num_of_question")
                    .HasComment("so luong cau hoi");

                entity.Property(e => e.Official)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("official")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1: thi tập trung, nhiều người 1 lúc. 0 thi phân tán , ko cần tối ưu");

                entity.Property(e => e.StartTime)
                    .HasColumnType("datetime")
                    .HasColumnName("start_time")
                    .HasComment("ngày bắt đầu mở đề");

                entity.Property(e => e.Type)
                    .HasColumnType("tinyint(2)")
                    .HasColumnName("type")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1: thi thật, 0 thi thử, -1 test");
            });

            modelBuilder.Entity<ExamGroup>(entity =>
            {
                entity.HasKey(e => new { e.ExamId, e.GroupId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("exam_group");

                entity.Property(e => e.ExamId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("exam_id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("group_id");
            });

            modelBuilder.Entity<ExamQuestion>(entity =>
            {
                entity.ToTable("exam_question");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AnswerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("answer_id")
                    .HasDefaultValueSql("'0'")
                    .HasComment("// cau tra loi cua user");

                entity.Property(e => e.ExamId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("exam_id");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("question_id");

                entity.Property(e => e.TryNum)
                    .HasColumnType("int(12)")
                    .HasColumnName("try_num");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<ExamQuestionOfficial>(entity =>
            {
                entity.ToTable("exam_question_official");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.AnswerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("answer_id")
                    .HasDefaultValueSql("'0'")
                    .HasComment("// cau tra loi cua user");

                entity.Property(e => e.ExamId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("exam_id");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("question_id");

                entity.Property(e => e.TryNum)
                    .HasColumnType("int(12)")
                    .HasColumnName("try_num");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<ExamTag>(entity =>
            {
                entity.ToTable("exam_tag");

                entity.HasIndex(e => new { e.ExamId, e.TagId }, "unique")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ExamId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("exam_id");

                entity.Property(e => e.Num)
                    .HasColumnType("int(12)")
                    .HasColumnName("num")
                    .HasComment("số lượng câu hỏi loại này trong đề thi");

                entity.Property(e => e.TagId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("tag_id");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.ToTable("groups");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.DonviId)
                    .HasColumnType("int(11)")
                    .HasColumnName("donvi_id")
                    .HasDefaultValueSql("'1'")
                    .HasComment("group thuộc đơn vị nào");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<GroupQuyen>(entity =>
            {
                entity.HasKey(e => e.GroupId)
                    .HasName("PRIMARY");

                entity.ToTable("group_quyen");

                entity.HasIndex(e => new { e.GroupId, e.QuyenId }, "quyen_group")
                    .IsUnique();

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("group_id");

                entity.Property(e => e.QuyenId)
                    .HasColumnType("int(11)")
                    .HasColumnName("quyen_id");
            });

            modelBuilder.Entity<GroupTag>(entity =>
            {
                entity.ToTable("group_tag");

                entity.HasIndex(e => new { e.GroupId, e.TagId }, "group_tag")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("int(12)")
                    .HasColumnName("id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .HasColumnName("group_id");

                entity.Property(e => e.TagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("tag_id");
            });

            modelBuilder.Entity<LogExam>(entity =>
            {
                entity.ToTable("log_exam");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("id");

                entity.Property(e => e.ExamId)
                    .HasColumnType("int(12)")
                    .HasColumnName("exam_id");

                entity.Property(e => e.ImeiNumber)
                    .HasMaxLength(32)
                    .HasColumnName("imei_number");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .HasColumnName("login_time");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(32)
                    .HasColumnName("phone_number");

                entity.Property(e => e.SdkVersion)
                    .HasColumnType("int(12)")
                    .HasColumnName("sdk_version")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TryNum)
                    .HasColumnType("int(12)")
                    .HasColumnName("try_num");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(12)")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<LogQuestion>(entity =>
            {
                entity.ToTable("log_question");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("id");

                entity.Property(e => e.Action)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("action")
                    .HasComment("1 thêm mới question_id ;\r\n2 update old_question_id bởi question_id");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("created_time");

                entity.Property(e => e.OldQuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("old_question_id");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("int(11)")
                    .HasColumnName("question_id");

                entity.Property(e => e.TagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("tag_id");
            });

            modelBuilder.Entity<PttbUser1406>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("pttb_user_1406");

                entity.Property(e => e.DonviId)
                    .HasMaxLength(255)
                    .HasColumnName("DONVI_ID");

                entity.Property(e => e.MaNd)
                    .HasMaxLength(255)
                    .HasColumnName("MA_ND");

                entity.Property(e => e.TenNv)
                    .HasMaxLength(255)
                    .HasColumnName("TEN_NV");

                entity.Property(e => e.Ttvt)
                    .HasMaxLength(255)
                    .HasColumnName("ttvt");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("questions");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("question_id");

                entity.Property(e => e.Enable)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("enable")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Level)
                    .HasColumnType("int(11)")
                    .HasColumnName("level")
                    .HasDefaultValueSql("'3'");

                entity.Property(e => e.QuestionText)
                    .IsRequired()
                    .HasMaxLength(512)
                    .HasColumnName("question_text");
            });

            modelBuilder.Entity<QuestionAnswer>(entity =>
            {
                entity.HasKey(e => e.QaId)
                    .HasName("PRIMARY");

                entity.ToTable("question_answer");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.AnswerId, "index_answer_id")
                    .IsUnique();

                entity.HasIndex(e => e.QuestionId, "index_question_id");

                entity.Property(e => e.QaId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("qa_id");

                entity.Property(e => e.AnswerId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("answer_id");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("question_id");

                entity.Property(e => e.State)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("state");
            });

            modelBuilder.Entity<QuestionTag>(entity =>
            {
                entity.ToTable("question_tag");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("_id");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("question_id");

                entity.Property(e => e.TagId)
                    .HasColumnType("int(10)")
                    .HasColumnName("tag_id");
            });

            modelBuilder.Entity<QuestionTagBk1801>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("question_tag_bk1801");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("_id");

                entity.Property(e => e.QuestionId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("question_id");

                entity.Property(e => e.TagId)
                    .HasColumnType("int(10)")
                    .HasColumnName("tag_id");
            });

            modelBuilder.Entity<Quyen>(entity =>
            {
                entity.ToTable("quyen");

                entity.Property(e => e.QuyenId)
                    .HasColumnType("int(11)")
                    .HasColumnName("quyen_id");

                entity.Property(e => e.TenQuyen)
                    .HasMaxLength(255)
                    .HasColumnName("ten_quyen");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.Property(e => e.TagId)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("tag_id");

                entity.Property(e => e.DonviId)
                    .HasColumnType("int(11)")
                    .HasColumnName("donvi_id")
                    .HasDefaultValueSql("'1'")
                    .HasComment("thuoc don vi nao");

                entity.Property(e => e.Enable)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("enable")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TagName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("tag_name");
            });

            modelBuilder.Entity<ThongBao>(entity =>
            {
                entity.ToTable("thong_bao");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DaGui)
                    .HasColumnType("int(4)")
                    .HasColumnName("da_gui")
                    .HasDefaultValueSql("'0'")
                    .HasComment("// 0 chua gui, 1: da gui");

                entity.Property(e => e.DonviId)
                    .HasColumnType("int(11)")
                    .HasColumnName("donvi_id")
                    .HasComment("// thông báo cho đơn vị nào");

                entity.Property(e => e.NgayGui)
                    .HasColumnType("datetime")
                    .HasColumnName("ngay_gui");

                entity.Property(e => e.NgayTao)
                    .HasColumnType("datetime")
                    .HasColumnName("ngay_tao");

                entity.Property(e => e.NguoiGui)
                    .HasColumnType("int(11)")
                    .HasColumnName("nguoi_gui");

                entity.Property(e => e.NguoiTao)
                    .HasColumnType("int(11)")
                    .HasColumnName("nguoi_tao");

                entity.Property(e => e.NoiDung)
                    .HasColumnType("text")
                    .HasColumnName("noi_dung");

                entity.Property(e => e.TieuDe)
                    .HasMaxLength(512)
                    .HasColumnName("tieu_de");
            });

            modelBuilder.Entity<ThongkeDiemthi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("thongke_diemthi");

                entity.Property(e => e.Caudung)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("caudung")
                    .HasComment("so cau dung");

                entity.Property(e => e.ExamId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("exam_id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("group_id");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(255)
                    .HasColumnName("ho_ten")
                    .UseCollation("utf8mb4_general_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.MaxScore)
                    .HasPrecision(25, 4)
                    .HasColumnName("max_score");

                entity.Property(e => e.Ttvt)
                    .HasMaxLength(255)
                    .HasColumnName("ttvt");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<ThongkeTheongay>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("thongke_theongay");

                entity.Property(e => e.Ngay)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("ngay");

                entity.Property(e => e.Thamgia)
                    .HasPrecision(42)
                    .HasColumnName("thamgia");

                entity.Property(e => e.TongNhansu)
                    .HasColumnType("bigint(22)")
                    .HasColumnName("tong_nhansu");

                entity.Property(e => e.Ttvt)
                    .HasMaxLength(255)
                    .HasColumnName("ttvt");

                entity.Property(e => e.TyleThamgia)
                    .HasPrecision(46, 4)
                    .HasColumnName("tyle_thamgia");
            });

            modelBuilder.Entity<TmpAntoanLd0806>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tmp_antoan_ld_0806");

                entity.Property(e => e.CauHoi).HasMaxLength(255);

                entity.Property(e => e.CauHoiId)
                    .HasColumnType("int(12)")
                    .HasColumnName("CauHoi_ID");

                entity.Property(e => e.ChuDe).HasMaxLength(255);

                entity.Property(e => e.DapAn).HasMaxLength(512);

                entity.Property(e => e.DapAnDung)
                    .HasColumnType("int(11)")
                    .HasColumnName("DapAn_Dung");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_general_ci");

                entity.HasIndex(e => e.User1, "unique_user")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.DonVi)
                    .HasMaxLength(255)
                    .HasColumnName("don_vi");

                entity.Property(e => e.DonviId)
                    .HasColumnType("int(11)")
                    .HasColumnName("donvi_id");

                entity.Property(e => e.Enable)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("enable")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1: OK, 0 : khoa");

                entity.Property(e => e.HoTen)
                    .HasMaxLength(255)
                    .HasColumnName("ho_ten");

                entity.Property(e => e.LoginTime)
                    .HasColumnType("datetime")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("login_time");

                entity.Property(e => e.OntapStatus)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("ontap_status")
                    .HasDefaultValueSql("'1'")
                    .HasComment("1: cho phép chức năng ôn tập, 0: khóa chức năng ôn tập");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("pass");

                entity.Property(e => e.SoDt)
                    .HasMaxLength(255)
                    .HasColumnName("so_dt");

                entity.Property(e => e.Ttvt)
                    .HasMaxLength(255)
                    .HasColumnName("ttvt")
                    .HasDefaultValueSql("''")
                    .HasComment("trung tam vien thong");

                entity.Property(e => e.User1)
                    .IsRequired()
                    .HasColumnName("user");
            });

            modelBuilder.Entity<UserDonvi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_donvi");

                entity.HasIndex(e => new { e.UserId, e.DonviId }, "unique_user_donvi")
                    .IsUnique();

                entity.Property(e => e.DonviId)
                    .HasColumnType("int(11)")
                    .HasColumnName("donvi_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");
            });

            modelBuilder.Entity<UserExam>(entity =>
            {
                entity.ToTable("user_exam");

                entity.HasIndex(e => e.ExamId, "fk_exam_id");

                entity.Property(e => e.Id)
                    .HasColumnType("bigint(20) unsigned")
                    .HasColumnName("id");

                entity.Property(e => e.ExamId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("exam_id");

                entity.Property(e => e.FinishedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("finished_time")
                    .HasComment("thoi gian nop bai");

                entity.Property(e => e.JoinTime)
                    .HasColumnType("datetime")
                    .HasColumnName("join_time")
                    .HasComment("thoi gian bat dau thi");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("note")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.NumOfRight)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("num_of_right")
                    .HasDefaultValueSql("'0'")
                    .HasComment("so cau dung");

                entity.Property(e => e.Official)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("official")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.State)
                    .HasColumnType("tinyint(4)")
                    .HasColumnName("state")
                    .HasDefaultValueSql("'0'")
                    .HasComment("0 : mới khởi tạo đề thi, 1 đã thi xong, 2 đang thi");

                entity.Property(e => e.TryNum)
                    .HasColumnType("int(12)")
                    .HasColumnName("try_num")
                    .HasComment("lần thi");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

                entity.HasOne(d => d.Exam)
                    .WithMany(p => p.UserExams)
                    .HasForeignKey(d => d.ExamId)
                    .HasConstraintName("fk_exam_id");
            });

            modelBuilder.Entity<UserGroup>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.GroupId })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("user_group");

                entity.HasIndex(e => e.GroupId, "index_group_id");

                entity.HasIndex(e => e.UserId, "index_user_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("group_id");
            });

            modelBuilder.Entity<UserOntap>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.FinishedTime })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("user_ontap");

                entity.HasIndex(e => e.UserId, "index_user_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(12)")
                    .HasColumnName("user_id");

                entity.Property(e => e.FinishedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("finished_time");

                entity.Property(e => e.NumRight)
                    .HasColumnType("int(12)")
                    .HasColumnName("num_right")
                    .HasComment("tong so cau dung");

                entity.Property(e => e.TotalNum)
                    .HasColumnType("int(12)")
                    .HasColumnName("total_num")
                    .HasComment("tong so cau da hoc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
