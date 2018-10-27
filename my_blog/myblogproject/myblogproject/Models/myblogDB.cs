namespace myblogproject.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class myblogDB : DbContext
    {
        public myblogDB()
            : base("name=myblogDB")
        {
        }

        public virtual DbSet<AnahtarKelime> AnahtarKelime { get; set; }
        public virtual DbSet<Kategori> Kategori { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<Makale> Makale { get; set; }
        public virtual DbSet<olumluOy> olumluOy { get; set; }
        public virtual DbSet<olumsuzOy> olumsuzOy { get; set; }
        public virtual DbSet<oy> oy { get; set; }
        public virtual DbSet<Yetki> Yetki { get; set; }
        public virtual DbSet<Yorum> Yorum { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnahtarKelime>()
                .Property(e => e.AnahtarKelimeAd)
                .IsFixedLength();

            modelBuilder.Entity<AnahtarKelime>()
                .HasMany(e => e.Makales)
                .WithMany(e => e.AnahtarKelime)
                .Map(m => m.ToTable("Makale_AnahtarKelime").MapLeftKey("AnahtarKelimeID").MapRightKey("MakaleID"));

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.AdSoyad)
                .IsFixedLength();

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.Eposta)
                .IsFixedLength();

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.Parola)
                .IsFixedLength();

            modelBuilder.Entity<Kullanici>()
                .Property(e => e.GirisID)
                .IsFixedLength();

            modelBuilder.Entity<oy>()
                .Property(e => e.oyTip)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<oy>()
                .HasOptional(e => e.olumluOy)
                .WithRequired(e => e.oy);

            modelBuilder.Entity<oy>()
                .HasOptional(e => e.olumsuzOy)
                .WithRequired(e => e.oy);

            modelBuilder.Entity<Yetki>()
                .Property(e => e.YetkiHali)
                .IsFixedLength();
        }
    }
}
