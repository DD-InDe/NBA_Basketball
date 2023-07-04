using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NBA_Basketball.Models;

public partial class BasketballContext : DbContext
{
    public BasketballContext()
    {
    }

    public BasketballContext(DbContextOptions<BasketballContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ActionType> ActionTypes { get; set; }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Conference> Conferences { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Matchup> Matchups { get; set; }

    public virtual DbSet<MatchupDetail> MatchupDetails { get; set; }

    public virtual DbSet<MatchupLog> MatchupLogs { get; set; }

    public virtual DbSet<MatchupType> MatchupTypes { get; set; }

    public virtual DbSet<Picture> Pictures { get; set; }

    public virtual DbSet<Player> Players { get; set; }

    public virtual DbSet<PlayerInTeam> PlayerInTeams { get; set; }

    public virtual DbSet<PlayerStatistic> PlayerStatistics { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PostSeason> PostSeasons { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<Team> Teams { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-OE4PBCI\\SQLEXPRESS;Database=Basketball;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ActionType>(entity =>
        {
            entity.HasKey(e => e.ActionTypeId).HasName("PK__ActionTy__62FE4C64B9DAFE3B");

            entity.ToTable("ActionType");

            entity.Property(e => e.ActionTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Jobnumber).HasName("PK__Admin__B33BB8E89AA75459");

            entity.ToTable("Admin");

            entity.Property(e => e.Jobnumber)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(1)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.RoleId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.Role).WithMany(p => p.Admins)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Admin__RoleId__34C8D9D1");
        });

        modelBuilder.Entity<Conference>(entity =>
        {
            entity.HasKey(e => e.ConferenceId).HasName("PK__Conferen__4A95F5731CBDE186");

            entity.ToTable("Conference");

            entity.Property(e => e.ConferenceId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryCode).HasName("PK__Country__5D9B0D2DEF8D00A1");

            entity.ToTable("Country");

            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CountryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.DivisionId).HasName("PK__Division__20EFC6A82E21664B");

            entity.ToTable("Division");

            entity.Property(e => e.DivisionId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Conference).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.ConferenceId)
                .HasConstraintName("FK__Division__Confer__37A5467C");
        });

        modelBuilder.Entity<Matchup>(entity =>
        {
            entity.HasKey(e => e.MatchupId).HasName("PK__Matchup__DE3C35490ADDA3DB");

            entity.ToTable("Matchup");

            entity.Property(e => e.CurrentQuarter)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StartTime).HasColumnType("datetime");

            entity.HasOne(d => d.MatchupType).WithMany(p => p.Matchups)
                .HasForeignKey(d => d.MatchupTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Matchup__Matchup__571DF1D5");

            entity.HasOne(d => d.Season).WithMany(p => p.Matchups)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Matchup__SeasonI__5629CD9C");

            entity.HasOne(d => d.TeamAwayNavigation).WithMany(p => p.MatchupTeamAwayNavigations)
                .HasForeignKey(d => d.TeamAway)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Matchup__TeamAwa__5812160E");

            entity.HasOne(d => d.TeamHomeNavigation).WithMany(p => p.MatchupTeamHomeNavigations)
                .HasForeignKey(d => d.TeamHome)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Matchup__TeamHom__59063A47");
        });

        modelBuilder.Entity<MatchupDetail>(entity =>
        {
            entity.HasKey(e => e.MatchupDetailId).HasName("PK__MatchupD__19F6375DB7B49071");

            entity.ToTable("MatchupDetail");

            entity.HasOne(d => d.Matchup).WithMany(p => p.MatchupDetails)
                .HasForeignKey(d => d.MatchupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MatchupDe__Match__02FC7413");
        });

        modelBuilder.Entity<MatchupLog>(entity =>
        {
            entity.HasKey(e => e.MatchupLogId).HasName("PK__MatchupL__007A9D0459CC0C7D");

            entity.ToTable("MatchupLog");

            entity.Property(e => e.OccurTime)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Remark)
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.HasOne(d => d.ActionType).WithMany(p => p.MatchupLogs)
                .HasForeignKey(d => d.ActionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MatchupLo__Actio__08B54D69");

            entity.HasOne(d => d.Matchup).WithMany(p => p.MatchupLogs)
                .HasForeignKey(d => d.MatchupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MatchupLo__Match__05D8E0BE");

            entity.HasOne(d => d.Player).WithMany(p => p.MatchupLogs)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MatchupLo__Playe__07C12930");

            entity.HasOne(d => d.Team).WithMany(p => p.MatchupLogs)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MatchupLo__TeamI__06CD04F7");
        });

        modelBuilder.Entity<MatchupType>(entity =>
        {
            entity.HasKey(e => e.MatchupTypeId).HasName("PK__MatchupT__F6F3D38B406B69D6");

            entity.ToTable("MatchupType");

            entity.Property(e => e.MatchupTypeId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Picture>(entity =>
        {
            entity.HasKey(e => e.PicturesId).HasName("PK__Pictures__7D943E9B4FFFC83E");

            entity.Property(e => e.CreateTime).HasColumnType("datetime");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Player>(entity =>
        {
            entity.HasKey(e => e.PlayerId).HasName("PK__Player__4A4E74C8CA3387E2");

            entity.ToTable("Player");

            entity.Property(e => e.PlayerId).ValueGeneratedNever();
            entity.Property(e => e.College)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Height).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.JoinYear).HasColumnType("date");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Photo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RetirementTime).HasColumnType("date");
            entity.Property(e => e.Weight).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CountryCodeNavigation).WithMany(p => p.Players)
                .HasForeignKey(d => d.CountryCode)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Player__CountryC__3E52440B");

            entity.HasOne(d => d.Position).WithMany(p => p.Players)
                .HasForeignKey(d => d.PositionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Player__Position__3D5E1FD2");
        });

        modelBuilder.Entity<PlayerInTeam>(entity =>
        {
            entity.HasKey(e => e.PlayerInTeam1).HasName("PK__PlayerIn__B439DC31E770FB8F");

            entity.ToTable("PlayerInTeam");

            entity.Property(e => e.PlayerInTeam1).HasColumnName("PlayerInTeam");
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerInTeams)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlayerInT__Playe__49C3F6B7");

            entity.HasOne(d => d.Season).WithMany(p => p.PlayerInTeams)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlayerInT__Seaso__4BAC3F29");

            entity.HasOne(d => d.Team).WithMany(p => p.PlayerInTeams)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlayerInT__TeamI__4AB81AF0");
        });

        modelBuilder.Entity<PlayerStatistic>(entity =>
        {
            entity.HasKey(e => e.PlayerStatisticsId).HasName("PK__PlayerSt__D4A80B8960E39FEF");

            entity.Property(e => e.Dffr).HasColumnName("DFFR");
            entity.Property(e => e.Minutes).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Offr).HasColumnName("OFFR");

            entity.HasOne(d => d.Matchup).WithMany(p => p.PlayerStatistics)
                .HasForeignKey(d => d.MatchupId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlayerSta__Match__6FE99F9F");

            entity.HasOne(d => d.Player).WithMany(p => p.PlayerStatistics)
                .HasForeignKey(d => d.PlayerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlayerSta__Playe__71D1E811");

            entity.HasOne(d => d.Team).WithMany(p => p.PlayerStatistics)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PlayerSta__TeamI__70DDC3D8");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__60BB9A79BC8F9833");

            entity.ToTable("Position");

            entity.Property(e => e.PositionId).ValueGeneratedNever();
            entity.Property(e => e.Abbr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<PostSeason>(entity =>
        {
            entity.HasKey(e => e.PostSeasonId).HasName("PK__PostSeas__032127A67F3836D2");

            entity.ToTable("PostSeason");

            entity.HasOne(d => d.Season).WithMany(p => p.PostSeasons)
                .HasForeignKey(d => d.SeasonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostSeaso__Seaso__0C85DE4D");

            entity.HasOne(d => d.Team).WithMany(p => p.PostSeasons)
                .HasForeignKey(d => d.TeamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__PostSeaso__TeamI__0B91BA14");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1A2C2A24DB");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.SeasonId).HasName("PK__Season__C1814E3882B20EB7");

            entity.ToTable("Season");

            entity.Property(e => e.SeasonId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.HasKey(e => e.TeamId).HasName("PK__Team__123AE7990F4D013C");

            entity.ToTable("Team");

            entity.Property(e => e.TeamId).ValueGeneratedNever();
            entity.Property(e => e.Abbr)
                .HasMaxLength(3)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Coach)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Logo).HasMaxLength(50);
            entity.Property(e => e.Stadiom)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TeamName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Division).WithMany(p => p.Teams)
                .HasForeignKey(d => d.DivisionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Team__DivisionId__3A81B327");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
