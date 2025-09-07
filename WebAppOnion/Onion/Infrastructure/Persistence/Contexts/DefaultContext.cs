using System.Reflection;
using Domain.Entities;
using Domain.Entities.Auth;
using Domain.Entities.Concrete;
using Domain.Entities.File.Common;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts;


public class DefaultContext : DbContext {
    //! Auth
    public DbSet<ApplicationUser> ApplicationUser => this.Set<ApplicationUser>();
    public DbSet<ApplicationRole> ApplicationRole => this.Set<ApplicationRole>();
    public DbSet<ApplicationEndpoint> ApplicationEndpoint => this.Set<ApplicationEndpoint>();
    public DbSet<ApplicationMenu> ApplicationMenu => this.Set<ApplicationMenu>();
    public DbSet<ApplicationUserRole> ApplicationUserRole => this.Set<ApplicationUserRole>();
    public DbSet<ApplicationUserClaim> ApplicationUserClaim => this.Set<ApplicationUserClaim>();
    public DbSet<ApplicationUserLogin> ApplicationUserLogin => this.Set<ApplicationUserLogin>();

    //! Concrete
    public DbSet<Cooperative> Cooperatives => this.Set<Cooperative>();
    public DbSet<CooperativeCategory> CooperativeCategories => this.Set<CooperativeCategory>();
    public DbSet<GrantSupport> GrantSupports => this.Set<GrantSupport>();
    public DbSet<GrantSupportCategory> GrantSupportCategories => this.Set<GrantSupportCategory>();
    public DbSet<NewsAnnouncement> NewsAnnouncements => this.Set<NewsAnnouncement>();
    public DbSet<NewsAnnouncementCategory> NewsAnnouncementCategories => this.Set<NewsAnnouncementCategory>();
    public DbSet<ProductGrowingSuggestion> ProductGrowingSuggestions => this.Set<ProductGrowingSuggestion>();
    public DbSet<ProductGrowingSuggestionCategory> ProductGrowingSuggestionCategories => this.Set<ProductGrowingSuggestionCategory>();

    //! File
    public DbSet<Domain.Entities.File.File> File => this.Set<Domain.Entities.File.File>();
    public DbSet<ImageFile> ImageFile => this.Set<ImageFile>();
    public DbSet<VideoFile> VideoFile => this.Set<VideoFile>();
    public DbSet<DocumentFile> DocumentFile => this.Set<DocumentFile>();
    public DbSet<InvoiceFile> InvoiceFile => this.Set<InvoiceFile>();
    public DbSet<OtherFile> OtherFile => this.Set<OtherFile>();

    public DefaultContext(DbContextOptions<DefaultContext> options) : base(options) {
        //AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);  //Postgresql,in timestamp değişkeni için bir UTC ayarı.
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.HasAnnotation("Relational:Collation", "en_US.utf8");
        //? Bilgi: "newsequentialid()" : Postgresql fonksiyonudur ve Guid değer üretir. Tablolara manuel ekleme yapılacaksa, Id sütununa default value olarak bu fonksiyon verilebilir. EFCore zaten hallediyor.

        //! Configurations
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()); // Otomatik Tüm Configuration'ları dahil et

        base.OnModelCreating(modelBuilder);
    }


    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) {
        // Tüm Modified veya Added state'ine sahip Entity'lerin tarihlerini SaveChangesAsync çağrıldığında otomatik olarak güncelle.
        var datas = ChangeTracker.Entries<BaseEntity>();

        foreach (var data in datas) {
            var _ = data.State switch {
                EntityState.Added => data.Entity.CreatedTime = DateTime.UtcNow,
                EntityState.Modified => data.Entity.ModifiedTime = DateTime.UtcNow,
                _ => DateTime.UtcNow
            };
        }

        return await base.SaveChangesAsync(cancellationToken);
    }
}