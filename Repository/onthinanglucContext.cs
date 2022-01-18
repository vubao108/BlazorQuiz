using System;
using BlazorVNPTQuiz.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BlazorVNPTQuiz.Repository
***REMOVED***
    public partial class onthinanglucContext : DbContext
    ***REMOVED***
        public onthinanglucContext()
        ***REMOVED***
    ***REMOVED***

        public onthinanglucContext(DbContextOptions<onthinanglucContext> options)
            : base(options)
        ***REMOVED***
    ***REMOVED***

        public virtual DbSet<AccSafari> AccSafaris ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<Answer> Answers ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<AppState> AppStates ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<AppVersion> AppVersions ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<DataVersion> DataVersions ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<DmKy> DmKies ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<Donvi> Donvis ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<DonviTag> DonviTags ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<Exam> Exams ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<ExamGroup> ExamGroups ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<ExamQuestion> ExamQuestions ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<ExamQuestionOfficial> ExamQuestionOfficials ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<ExamTag> ExamTags ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<Group> Groups ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<GroupQuyen> GroupQuyens ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<GroupTag> GroupTags ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<LogExam> LogExams ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<LogQuestion> LogQuestions ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<PttbUser1406> PttbUser1406s ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<Question> Questions ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<QuestionAnswer> QuestionAnswers ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<QuestionTag> QuestionTags ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<QuestionTagBk1801> QuestionTagBk1801s ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<Quyen> Quyens ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<Tag> Tags ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<ThongBao> ThongBaos ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<ThongkeDiemthi> ThongkeDiemthis ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<ThongkeTheongay> ThongkeTheongays ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<TmpAntoanLd0806> TmpAntoanLd0806s ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<User> Users ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<UserDonvi> UserDonvis ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<UserExam> UserExams ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<UserGroup> UserGroups ***REMOVED*** get; set; ***REMOVED***
        public virtual DbSet<UserOntap> UserOntaps ***REMOVED*** get; set; ***REMOVED***

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        ***REMOVED***
            if (!optionsBuilder.IsConfigured)
            ***REMOVED***

        ***REMOVED***
    ***REMOVED***

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        ***REMOVED***
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<AccSafari>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<Answer>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<AppState>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<AppVersion>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<DataVersion>(entity =>
            ***REMOVED***
                entity.ToTable("data_version");

                entity.HasIndex(e => new ***REMOVED*** e.Version, e.DonviId ***REMOVED***, "unique_version_donvi")
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
        ***REMOVED***);

            modelBuilder.Entity<DmKy>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<Donvi>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<DonviTag>(entity =>
            ***REMOVED***
                entity.HasKey(e => new ***REMOVED*** e.DonviId, e.TagId ***REMOVED***)
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] ***REMOVED*** 0, 0 ***REMOVED***);

                entity.ToTable("donvi_tag");

                entity.Property(e => e.DonviId)
                    .HasColumnType("int(11)")
                    .HasColumnName("donvi_id");

                entity.Property(e => e.TagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("tag_id");
        ***REMOVED***);

            modelBuilder.Entity<Exam>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<ExamGroup>(entity =>
            ***REMOVED***
                entity.HasKey(e => new ***REMOVED*** e.ExamId, e.GroupId ***REMOVED***)
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] ***REMOVED*** 0, 0 ***REMOVED***);

                entity.ToTable("exam_group");

                entity.Property(e => e.ExamId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("exam_id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("group_id");
        ***REMOVED***);

            modelBuilder.Entity<ExamQuestion>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<ExamQuestionOfficial>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<ExamTag>(entity =>
            ***REMOVED***
                entity.ToTable("exam_tag");

                entity.HasIndex(e => new ***REMOVED*** e.ExamId, e.TagId ***REMOVED***, "unique")
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
        ***REMOVED***);

            modelBuilder.Entity<Group>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<GroupQuyen>(entity =>
            ***REMOVED***
                entity.HasKey(e => e.GroupId)
                    .HasName("PRIMARY");

                entity.ToTable("group_quyen");

                entity.HasIndex(e => new ***REMOVED*** e.GroupId, e.QuyenId ***REMOVED***, "quyen_group")
                    .IsUnique();

                entity.Property(e => e.GroupId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever()
                    .HasColumnName("group_id");

                entity.Property(e => e.QuyenId)
                    .HasColumnType("int(11)")
                    .HasColumnName("quyen_id");
        ***REMOVED***);

            modelBuilder.Entity<GroupTag>(entity =>
            ***REMOVED***
                entity.ToTable("group_tag");

                entity.HasIndex(e => new ***REMOVED*** e.GroupId, e.TagId ***REMOVED***, "group_tag")
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
        ***REMOVED***);

            modelBuilder.Entity<LogExam>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<LogQuestion>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<PttbUser1406>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<Question>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<QuestionAnswer>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<QuestionTag>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<QuestionTagBk1801>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<Quyen>(entity =>
            ***REMOVED***
                entity.ToTable("quyen");

                entity.Property(e => e.QuyenId)
                    .HasColumnType("int(11)")
                    .HasColumnName("quyen_id");

                entity.Property(e => e.TenQuyen)
                    .HasMaxLength(255)
                    .HasColumnName("ten_quyen");
        ***REMOVED***);

            modelBuilder.Entity<Tag>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<ThongBao>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<ThongkeDiemthi>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<ThongkeTheongay>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<TmpAntoanLd0806>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<User>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<UserDonvi>(entity =>
            ***REMOVED***
                entity.HasNoKey();

                entity.ToTable("user_donvi");

                entity.HasIndex(e => new ***REMOVED*** e.UserId, e.DonviId ***REMOVED***, "unique_user_donvi")
                    .IsUnique();

                entity.Property(e => e.DonviId)
                    .HasColumnType("int(11)")
                    .HasColumnName("donvi_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("int(11)")
                    .HasColumnName("user_id");
        ***REMOVED***);

            modelBuilder.Entity<UserExam>(entity =>
            ***REMOVED***
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
        ***REMOVED***);

            modelBuilder.Entity<UserGroup>(entity =>
            ***REMOVED***
                entity.HasKey(e => new ***REMOVED*** e.UserId, e.GroupId ***REMOVED***)
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] ***REMOVED*** 0, 0 ***REMOVED***);

                entity.ToTable("user_group");

                entity.HasIndex(e => e.GroupId, "index_group_id");

                entity.HasIndex(e => e.UserId, "index_user_id");

                entity.Property(e => e.UserId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("user_id");

                entity.Property(e => e.GroupId)
                    .HasColumnType("bigint(20)")
                    .HasColumnName("group_id");
        ***REMOVED***);

            modelBuilder.Entity<UserOntap>(entity =>
            ***REMOVED***
                entity.HasKey(e => new ***REMOVED*** e.UserId, e.FinishedTime ***REMOVED***)
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] ***REMOVED*** 0, 0 ***REMOVED***);

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
        ***REMOVED***);

            OnModelCreatingPartial(modelBuilder);
    ***REMOVED***

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
***REMOVED***
***REMOVED***
